using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class AssetBundleDownload : MonoBehaviour
{
	//에셋번들을 다운로드하는데에는 두 가지 방법이 있다. 캐싱과 논캐싱
	//캐싱은 한번 다운로드받으면 두 번째부터는 이미 다운로드 받은 것을 불러오는 것.
	//논캐싱은 매번 받는 것.
	//유니티에서는 캐싱을 권함. 매번 받게되면 네트워크의 속도 저하가 발생할 수 있음.
	public string bundleURL;
	public string assetName;
	public int version;

    private void Awake()
    {
		assetName = "bundlecube";
		bundleURL = "file:///C:/Users/shwuo/practice/Assets/AssetBundles/AssetBundles";
	}
    void Start()
	{
		StartCoroutine(Download());
	}
	
	IEnumerator Download()
	{
		// cache 폴더에 AssetBundle을 담을 것이므로 캐싱시스템이 준비 될 때까지 기다림
		while (!Caching.ready)
			yield return null;
		UnityWebRequest request = UnityWebRequest.Get(bundleURL);
		//WWW.LoadFromCacheOrDownload(에셋번들을 다운로드 받을 서버 주소, 번들버전) 에셋번들이 캐시에 있으면 로드하고, 없으면 다운로드하여 캐시폴더에 저장
			yield return request.Send();

		AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
			
				Instantiate(bundle.LoadAsset<GameObject>(assetName));

			//bundle.Unload(false);
		
	}// 2022.12.20 현재 에셋번들을 빌드하고 다운로드하는 것까지는 성공했지만 로드하는 코드를 지원하지 않는 경우가 많아서 최신 방법을 다시 찾아보아야 함.
}

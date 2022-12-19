using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AssetBundleDownload : MonoBehaviour
{
	//에셋번들을 다운로드하는데에는 두 가지 방법이 있다. 캐싱과 논캐싱
	//캐싱은 한번 다운로드받으면 두 번째부터는 이미 다운로드 받은 것을 불러오는 것.
	//논캐싱은 매번 받는 것.
	//유니티에서는 캐싱을 권함. 매번 받게되면 네트워크의 속도 저하가 발생할 수 있음.
	
	public int version; // 번들의 버전

    void Start()
	{
		StartCoroutine(Download());
	}

	IEnumerator Download()
	{
		// cache 폴더에 AssetBundle을 담을 것이므로 캐싱시스템이 준비 될 때까지 기다림
		while (!Caching.ready)
			yield return null;
		// 에셋번들이 캐시에 있으면 로드하고, 없으면 다운로드하여 캐시폴더에 저장합니다.
		using (WWW www = WWW.LoadFromCacheOrDownload("file://C:/Users/shwuo/practice/Assets/AssetBundles", version))
		{
			//WWW.LoadFromCacheOrDownload(에셋번들을 다운로드 받을 서버 주소. 서버는 없으니 로컬폴더경로를 사용할 예정, 번들버전)
			yield return www;
			if (www.error != null)
				throw new Exception("WWW 다운로드에 에러가 생겼습니다.:" + www.error);

		} // using문은 File 및 Font 처럼 컴퓨터 에서 관리되는 리소스들을 쓰고 나서 쉽게 자원을 되돌려줄수 있도록 기능을 제공
	}
}

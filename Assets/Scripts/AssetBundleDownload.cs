using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class AssetBundleDownload : MonoBehaviour
{
	//���¹����� �ٿ�ε��ϴµ����� �� ���� ����� �ִ�. ĳ�̰� ��ĳ��
	//ĳ���� �ѹ� �ٿ�ε������ �� ��°���ʹ� �̹� �ٿ�ε� ���� ���� �ҷ����� ��.
	//��ĳ���� �Ź� �޴� ��.
	//����Ƽ������ ĳ���� ����. �Ź� �ްԵǸ� ��Ʈ��ũ�� �ӵ� ���ϰ� �߻��� �� ����.
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
		// cache ������ AssetBundle�� ���� ���̹Ƿ� ĳ�̽ý����� �غ� �� ������ ��ٸ�
		while (!Caching.ready)
			yield return null;
		UnityWebRequest request = UnityWebRequest.Get(bundleURL);
		//WWW.LoadFromCacheOrDownload(���¹����� �ٿ�ε� ���� ���� �ּ�, �������) ���¹����� ĳ�ÿ� ������ �ε��ϰ�, ������ �ٿ�ε��Ͽ� ĳ�������� ����
			yield return request.Send();

		AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
			
				Instantiate(bundle.LoadAsset<GameObject>(assetName));

			//bundle.Unload(false);
		
	}// 2022.12.20 ���� ���¹����� �����ϰ� �ٿ�ε��ϴ� �ͱ����� ���������� �ε��ϴ� �ڵ带 �������� �ʴ� ��찡 ���Ƽ� �ֽ� ����� �ٽ� ã�ƺ��ƾ� ��.
}

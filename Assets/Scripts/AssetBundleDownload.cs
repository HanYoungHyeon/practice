using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AssetBundleDownload : MonoBehaviour
{
	//���¹����� �ٿ�ε��ϴµ����� �� ���� ����� �ִ�. ĳ�̰� ��ĳ��
	//ĳ���� �ѹ� �ٿ�ε������ �� ��°���ʹ� �̹� �ٿ�ε� ���� ���� �ҷ����� ��.
	//��ĳ���� �Ź� �޴� ��.
	//����Ƽ������ ĳ���� ����. �Ź� �ްԵǸ� ��Ʈ��ũ�� �ӵ� ���ϰ� �߻��� �� ����.
	
	public int version; // ������ ����

    void Start()
	{
		StartCoroutine(Download());
	}

	IEnumerator Download()
	{
		// cache ������ AssetBundle�� ���� ���̹Ƿ� ĳ�̽ý����� �غ� �� ������ ��ٸ�
		while (!Caching.ready)
			yield return null;
		// ���¹����� ĳ�ÿ� ������ �ε��ϰ�, ������ �ٿ�ε��Ͽ� ĳ�������� �����մϴ�.
		using (WWW www = WWW.LoadFromCacheOrDownload("file://C:/Users/shwuo/practice/Assets/AssetBundles", version))
		{
			//WWW.LoadFromCacheOrDownload(���¹����� �ٿ�ε� ���� ���� �ּ�. ������ ������ ����������θ� ����� ����, �������)
			yield return www;
			if (www.error != null)
				throw new Exception("WWW �ٿ�ε忡 ������ ������ϴ�.:" + www.error);

		} // using���� File �� Font ó�� ��ǻ�� ���� �����Ǵ� ���ҽ����� ���� ���� ���� �ڿ��� �ǵ����ټ� �ֵ��� ����� ����
	}
}

using UnityEngine;
using UnityEditor; //����Ƽ �����ͳ��ӽ����̽��� ����Ϸ��� ������Ʈ �������� Editor��� ���� �ȿ� �ش� ��ũ��Ʈ�� ����־�� ��.
public class AssetBundleTest : MonoBehaviour
{
	[MenuItem("Bundles/Bulid AssetBundles")]//������ ���ӽ����̽��� ����ϸ� MenuItem�� ���� ������ �� �޴��� �߰��� �� �ִ�
	static void BuildAllAssetBundles()//�� static�� ����ұ�? �Ƹ� ���¹����� ���� ���ۺ��� ������ �ʿ��ϱ� ������ �����Ϳ����� �Ҵ��Ϸ��� ���� �� ����. �� �κ��� ���� ã�ƺ���.
	{
		BuildPipeline.BuildAssetBundles("Assets/AssetBundles", BuildAssetBundleOptions.None, BuildTarget.Android);
		//BuildPipeline.BuildAssetBundles �޼���� ���¹���� �����ִ� ��. ("������ ����������" , �����ϰų� �׳��ϰų� ���������� �����ִ� �ɼ�, ���¹����� ������ ��� �÷������� ����� ������ �����÷��� ���� )
		//�׽�Ʈ��� �� ���������.
	}
}

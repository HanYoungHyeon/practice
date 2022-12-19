using UnityEngine;
using UnityEditor; //유니티 에디터네임스페이스를 사용하려면 프로젝트 폴더에서 Editor라는 폴더 안에 해당 스크립트가 들어있어야 함.
public class AssetBundleTest : MonoBehaviour
{
	[MenuItem("Bundles/Bulid AssetBundles")]//에디터 네임스페이스를 사용하면 MenuItem을 통해 에디터 내 메뉴를 추가할 수 있다
	static void BuildAllAssetBundles()//왜 static을 사용할까? 아마 에셋번들은 게임 시작부터 끝까지 필요하기 때문에 데이터영역에 할당하려고 쓰는 것 같다. 이 부분은 따로 찾아보자.
	{
		BuildPipeline.BuildAssetBundles("Assets/AssetBundles", BuildAssetBundleOptions.None, BuildTarget.Android);
		//BuildPipeline.BuildAssetBundles 메서드는 에셋번들로 구워주는 것. ("구워서 저장할폴더" , 압축하거나 그냥하거나 여러가지를 정해주는 옵션, 에셋번들을 구워서 어느 플랫폼에서 사용할 것인지 전용플랫폼 선택 )
		//테스트결과 잘 만들어졌음.
	}
}

using UnityEngine;
using UnityEditor;
using System.Collections;


public class ImportAssetBundles : MonoBehaviour
{
    private static AssetBundleBuild[] buildMap;
    private static string url;
    private static bool isLoad = false;

    // Use this for initialization
    void Start()
    {

    }


    void OnGUI()
    {
        if (GUI.Button(new Rect(20, 35, 100, 25), "Load GameObject"))
        {
            url = "file://" + Application.dataPath + "/StreamingAssets/testassetbunlde2.unity3d";
            StartCoroutine(LoadAssetsBunldeByWWW(url));
        }
    }

    [MenuItem("Custom Editor/Builde Assetunldes")]
    static void CreateAssetBuildAssetBundleMain() {

        //Object[] selects = Selection.GetFiltered(typeof(object),SelectionMode.DeepAssets);
        //int i = 0;
        //buildMap = new AssetBundleBuild[selects.Length];
        //foreach (Object item in selects) {
        //    buildMap[i].assetBundleName = "thingsbundle"+i;
        //    string[] url = new string[1];
        //    url[0] = "Assets/Prefabs/" + item.name+ ".prefab";
        //    buildMap[i].assetNames = url;
        //    print(url[0]);
        //    //BuildPipeline.BuildAssetBundles(item, null, "Assets/StreamingAssets",BuildAssetBundleOptions.None,BuildTarget.Android);
        //    i++;
        //}
        //print(buildMap.Length);
        BuildPipeline.BuildAssetBundles("Assets/StreamingAssets", BuildAssetBundleOptions.UncompressedAssetBundle);

    }
    //[MenuItem("Custom Editor/Load  Assetunldes")]
    //static void LoadAssetBuildAssetBundleMain()
    //{
    //    //print(Application.dataPath);
    //    url = "file: //" +Application.dataPath + "/StreamingAssets/StreamingAssets.assetbundle";
    //    print(url);
    //    isLoad = true;
    //    print("LoadAssetBuildAssetBundleMain"+ url);
    //}

    IEnumerator LoadAssetsBunldeByWWW(string path)
    {
        print(path);
        //WWW bunlde = new WWW(path);
        //if (bunlde.error !=null) {
        //    print("error");
        //}
        //else { 
        //yield return bunlde;
        //yield return Instantiate(bunlde.assetBundle.LoadAsset("explosion_player"),new Vector3(0,0,0), Quaternion.identity);
        //bunlde.assetBundle.Unload(false);
        //}
        AssetBundle bunlde = AssetBundle.LoadFromFile(Application.dataPath + "/StreamingAssets/testassetbunlde2.unity3d");
        if (bunlde !=null) {
            yield return Instantiate(bunlde.LoadAsset("Goblin"), new Vector3(0, 0, 0), Quaternion.identity);
        }
        bunlde.Unload(false);
    }
}

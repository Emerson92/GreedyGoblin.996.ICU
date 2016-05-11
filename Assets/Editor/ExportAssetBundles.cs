using UnityEngine;
using System.Collections;
using UnityEditor;

public class ExportAssetBundler : MonoBehaviour
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
            url = "file ://" + Application.dataPath + "testassetbunlde2.unity3d";
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
        BuildPipeline.BuildAssetBundles("Assets/StreamingAssets");

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
        WWW bunlde = new WWW(path);
        yield return bunlde;
        yield return Instantiate(bunlde.assetBundle.LoadAsset("GoldDargon"));
        bunlde.assetBundle.Unload(false);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class BuildBundle : MonoBehaviour {

    [MenuItem("MyMenu/Build Assetbundle")]
    static private void BuildAssetBundle()
    {
        string dir = Application.dataPath + "/StreamingAssets";

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        //DirectoryInfo rootDirInfo = new DirectoryInfo(Application.dataPath + "/test_atlas");
        //List<Sprite> assets = new List<Sprite>();
        //foreach (FileInfo pngFile in rootDirInfo.GetFiles("*.png", SearchOption.AllDirectories))
        //{
        //    string allPath = pngFile.FullName;
        //    string assetPath = allPath.Substring(allPath.IndexOf("Assets"));
        //    assets.Add(AssetDatabase.LoadAssetAtPath<Sprite>(assetPath));
        //}
        BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.UncompressedAssetBundle, GetBuildTarget());
        
    }
    static private BuildTarget GetBuildTarget()
    {
        BuildTarget target = new BuildTarget();
#if UNITY_STANDALONE
        target = BuildTarget.StandaloneWindows;
#elif UNITY_IPHONE
			target = BuildTarget.iPhone;
#elif UNITY_ANDROID
			target = BuildTarget.Android;
#endif
        return target;
    }
}

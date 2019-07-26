using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIMain : MonoBehaviour
{
    AssetBundle assetbundle = null;
    AssetBundle assetbundle1 = null;
    AssetBundle assetbundle2 = null;
    GameObject go1;
    GameObject go2;
    GameObject go3;
    GameObject go4;
    void Start()
    {
        go1 = CreatImage(loadSprite("test_1"));
        go2 = CreatImage(loadSprite("test_2"));
        assetbundle1 = loadGameobject("prefanone");
        go3 = Instantiate(assetbundle1.LoadAsset("prefab1") as GameObject);
        go3.transform.parent = transform;
        assetbundle2 = loadGameobject("prefabtwo");
        go4 = Instantiate(assetbundle2.LoadAsset("prefab2") as GameObject);
        go4.transform.parent = transform;
        Invoke("DestoryImage", 3);
    }

    private void DestoryImage()
    {
        Destroy(go1);
        Destroy(go2);
        Destroy(go3);
        Destroy(go4);
        assetbundle.Unload(false);
        assetbundle1.Unload(false);
        assetbundle2.Unload(false);
        Resources.UnloadUnusedAssets();
    }

    private GameObject CreatImage(Sprite sprite)
    {
        GameObject go = new GameObject(sprite.name);
        go.layer = LayerMask.NameToLayer("UI");
        go.transform.parent = transform;
        go.transform.localScale = Vector3.one;
        Image image = go.AddComponent<Image>();
        image.sprite = sprite;
        image.SetNativeSize();
        return go;
    }

    private Sprite loadSprite(string spriteName)
    {
        if (assetbundle == null)
            assetbundle = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/test.u3d");
        return assetbundle.LoadAsset(spriteName) as Sprite;
    }

    private AssetBundle loadGameobject(string bundlename)
    {
        AssetBundle asset = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/" + bundlename + ".u3d");
        return asset;
    }

}
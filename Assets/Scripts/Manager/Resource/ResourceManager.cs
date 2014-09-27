using UnityEngine;
using System.Collections;
using System.IO;

public class ResourceManager : MonoBehaviour {
    private AssetBundle shared;

    string AssetPath {
        get {
            string target = string.Empty;
            if (Application.platform == RuntimePlatform.OSXEditor ||
                Application.platform == RuntimePlatform.IPhonePlayer ||
                Application.platform == RuntimePlatform.OSXEditor) {
                target = "iphone";
            } else {
                target = "android";
            }
            return Util.GetDataDir() + "/StreamingAssets/asset/" + target + "/";
        }
    }

    void Awake() {
        initialize();
    }
	
    /// <summary>
    /// 初始化
    /// </summary>
    void initialize() {
        byte[] stream;
        string uri = string.Empty;
        //------------------------------------Shared--------------------------------------
        uri = AssetPath + "shared.assetbundle";
        Debug.LogWarning("LoadFile::>> " + uri);

        stream = File.ReadAllBytes(uri);
        shared = AssetBundle.CreateFromMemoryImmediate(stream); 

        shared.Load("Dialog", typeof(GameObject));
        io.gameManager.OnResourceInited();    //资源初始化完成，回调游戏管理器，执行后续操作 
    }

    /// <summary>
    /// 载入对象
    /// </summary>
    public void RequestResource(string name) {
        string uri = AssetPath + name.ToLower() + ".assetbundle";
        byte[] stream = File.ReadAllBytes(uri);
        AssetBundle bundle = AssetBundle.CreateFromMemoryImmediate(stream); //关联数据的素材绑定

        io.panelManager.OnRequestResource(name, bundle);  //回传给面板管理器
        Debug.LogWarning("LoadFile::>> " + uri + " " + bundle);
    }

    /// <summary>
    /// 销毁资源
    /// </summary>
    void OnDestroy() {
        if (shared != null) shared.Unload(true);
        Debug.Log("~ResourceManager was destroy!");
    }
}

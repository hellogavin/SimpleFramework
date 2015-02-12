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
    /// ��ʼ��
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
        ioo.gameManager.OnResourceInited();    //��Դ��ʼ����ɣ��ص���Ϸ��������ִ�к������� 
    }

    /// <summary>
    /// �����ز�
    /// </summary>
    public AssetBundle LoadBundle(string name) {
        byte[] stream = null;
        AssetBundle bundle = null;
        string uri = AssetPath + name.ToLower() + ".assetbundle";
        stream = File.ReadAllBytes(uri);
        bundle = AssetBundle.CreateFromMemoryImmediate(stream); //�������ݵ��زİ�
        return bundle;
    }

    /// <summary>
    /// ������Դ
    /// </summary>
    void OnDestroy() {
        if (shared != null) shared.Unload(true);
        Debug.Log("~ResourceManager was destroy!");
    }
}

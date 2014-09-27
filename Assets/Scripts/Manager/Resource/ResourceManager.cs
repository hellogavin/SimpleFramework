using UnityEngine;
using System.Collections;
using System.IO;

public class ResourceManager : MonoBehaviour {
    private AssetBundle common;
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
        StartCoroutine(OnInitialize());
    }
	
    /// <summary>
    /// ��ʼ��
    /// </summary>
    IEnumerator OnInitialize() {
        byte[] stream;
        string uri = string.Empty;
        AssetBundleCreateRequest request;
        //------------------------------------Common--------------------------------------
        uri = AssetPath + "common.assetbundle";
        if (Debug.isDebugBuild) Debug.LogWarning("LoadFile::>> " + uri);

        stream = File.ReadAllBytes(uri);
        request = AssetBundle.CreateFromMemory(stream);
        yield return request;
        common = request.assetBundle;

        Const.luaScripts = new TextAsset[2];
        Const.luaScripts[0] = LoadScript("define.lua");
        Const.luaScripts[1] = LoadScript("functions.lua");

        //------------------------------------Shared--------------------------------------
        uri = AssetPath + "shared.assetbundle";
        if (Debug.isDebugBuild) Debug.LogWarning("LoadFile::>> " + uri);

        stream = File.ReadAllBytes(uri);
        request = AssetBundle.CreateFromMemory(stream);
        yield return request;
        shared = request.assetBundle;

        shared.Load("Dialog", typeof(GameObject));
        io.gameManager.OnResourceInited();    //��Դ��ʼ����ɣ��ص���Ϸ��������ִ�к������� 
    }

    /// <summary>
    /// ����Lua�ű�
    /// </summary>
    public TextAsset LoadScript(string name) {
        return common.Load(name) as TextAsset;
    }

    /// <summary>
    /// �������
    /// </summary>
    public void RequestResource(string name) {
        StartCoroutine(OnLoadObject(name));
    }

    /// <summary>
    /// �������
    /// </summary>
    /// <returns></returns>
    IEnumerator OnLoadObject(string name, string text = null) {
        string uri = AssetPath + name.ToLower() + ".assetbundle";
        byte[] stream = File.ReadAllBytes(uri);
        AssetBundleCreateRequest request = AssetBundle.CreateFromMemory(stream); //�������ݵ��زİ�
        yield return request;
        io.panelManager.OnRequestResource(name, request.assetBundle);  //�ش�����������
        if (Debug.isDebugBuild) Debug.LogWarning("LoadFile::>> " + uri + " " + request.assetBundle);
    }

    /// <summary>
    /// ������Դ
    /// </summary>
    void OnDestroy() {
        if (shared != null) shared.Unload(true);
        if (common != null) common.Unload(true);
        print("~ResourceManager was destroy!");
    }
}

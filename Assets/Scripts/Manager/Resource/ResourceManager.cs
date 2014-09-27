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
        initialize();
    }
	
    /// <summary>
    /// ��ʼ��
    /// </summary>
    void initialize() {
        byte[] stream;
        string uri = string.Empty;
        //------------------------------------Common--------------------------------------
        uri = AssetPath + "common.assetbundle";
        Debuger.LogWarning("LoadFile::>> " + uri);

        stream = File.ReadAllBytes(uri);
        common = AssetBundle.CreateFromMemoryImmediate(stream); 

        Const.luaScripts = new TextAsset[2];
        Const.luaScripts[0] = LoadScript("define.lua");
        Const.luaScripts[1] = LoadScript("functions.lua");

        //------------------------------------Shared--------------------------------------
        uri = AssetPath + "shared.assetbundle";
        Debuger.LogWarning("LoadFile::>> " + uri);

        stream = File.ReadAllBytes(uri);
        shared = AssetBundle.CreateFromMemoryImmediate(stream); 

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
        string uri = AssetPath + name.ToLower() + ".assetbundle";
        byte[] stream = File.ReadAllBytes(uri);
        AssetBundle bundle = AssetBundle.CreateFromMemoryImmediate(stream); //�������ݵ��زİ�

        io.panelManager.OnRequestResource(name, bundle);  //�ش�����������
        Debuger.LogWarning("LoadFile::>> " + uri + " " + bundle);
    }

    /// <summary>
    /// ������Դ
    /// </summary>
    void OnDestroy() {
        if (shared != null) shared.Unload(true);
        if (common != null) common.Unload(true);
        Debuger.Log("~ResourceManager was destroy!");
    }
}

using UnityEngine;
using LuaInterface;
using System.Collections;
using System.Collections.Generic;

public class BaseLua : MonoBehaviour {
    private string data = null;
    private bool initialize = false;
    private LuaState lua = null;
    private AssetBundle bundle;
    /// <summary>
    /// lua���
    /// </summary>
    public static List<string> luaNames = new List<string>();
    Dictionary<string, LuaFunction> functions = new Dictionary<string, LuaFunction>();

    protected void Start() {
        CallMethod("Start");
    }

    protected void OnClick() {
        CallMethod("OnClick");
    }

    protected void OnClickEvent(GameObject go) {
        CallMethod("OnClick", go);
    }

    public void OnWeb(int key, object value) {
        CallMethod("OnWeb", key, value);
    }

    public void OnSocket(int key, ByteBuffer buffer) {
        CallMethod("OnSocket", key, buffer);
    }

    /// <summary>
    /// ��ʼ�����
    /// </summary>
    public void OnInit(AssetBundle bundle, string text = null) {
        InitPanel(); this.bundle = bundle; //��ʼ��
        this.data = text;   //��ʼ�����Ӳ���
        if (Debug.isDebugBuild) Debug.LogWarning("OnInit---->>>text:>" + text);
    }

    /// <summary>
    /// ��ȡһ��GameObject��Դ
    /// </summary>
    /// <param name="name"></param>
    public GameObject GetGameObject(string name) {
        if (bundle == null) return null;
        return bundle.Load(name, typeof(GameObject)) as GameObject;
    }

    /// <summary>
    /// ��ȡһ����������Դ
    /// </summary>
    public UnityEngine.Object GetUntypeObject(string name) {
        if (bundle == null) return null;
        return bundle.Load(name);
    }

    /// <summary>
    /// �ȴ�ʱ��
    /// </summary>
    /// <param name="time"></param>
    public void Wait(float time) {
        StartCoroutine(OnWait(time));
    }

    IEnumerator OnWait(float time) {
        yield return new WaitForSeconds(time);
        CallMethod("resume");
    }

    //-----------------------------------------------
    /// <summary>
    /// ��ʼ��
    /// </summary>
    protected void InitObject() {
        if (initialize) return;  //��ʼ�������˳�
        initialize = true;

        lua = new LuaState();
        TextAsset[] scripts = Const.luaScripts;
        foreach (TextAsset code in scripts) {
            lua.DoString(code.text);
            if (Debug.isDebugBuild) Debug.LogWarning("LoadLua---->>>>" + code.name);
        }
        SetLuaData(lua);
    }

    /// <summary>
    /// ��ʼ�����
    /// </summary>
    protected void InitPanel() {
        if (initialize) return;  //��ʼ�������˳�
        initialize = true;
        if (luaNames.Count == 0) return;

        bool runLua = false;
        string name = gameObject.name;

        for (int i = 0; i < luaNames.Count; i++) {
            if (luaNames[i].Equals(name)) {
                runLua = true;
                break;
            }
        }
        if (!runLua) return;    //��������lua

        object o = Global.LuaObjects[name];
        if (o == null) return;
        lua = o as LuaState;
        SetLuaData(lua);    //��transform��gameObject���ݸ�Lua    

        ///�������������а�ť��Ϣ
        UIButton[] buttons = GetComponentsInChildren<UIButton>();
        for (int i = 0; i < buttons.Length; i++) {
            EventDelegate.Add(buttons[i].onClick, OnClick);
        }
    }

    /// <summary>
    /// ��ʼ��lua�ű�
    /// </summary>
    public void InitScript(TextAsset code) {
        lua.DoString(code.text);
    }

    /// <summary>
    /// ����Lua����
    /// </summary>
    protected void SetLuaData(LuaState lua) {
        lua["transform"] = transform;
        lua["gameObject"] = gameObject;
    }

    /// <summary>
    /// ִ��Lua����-�޲���
    /// </summary>
    protected object[] CallMethod(string func) {
        if (lua == null) return null;
        if (!functions.ContainsKey(func)) {
            functions[func] = lua.GetFunction(func);
        }
        if (functions[func] != null) {
            return functions[func].Call();
        }
        return null;
    }

    /// <summary>
    /// ִ��Lua����-Socket��Ϣ
    /// </summary>
    protected object[] CallMethod(string func, GameObject go) {
        if (lua == null) return null;
        if (!functions.ContainsKey(func)) {
            functions[func] = lua.GetFunction(func);
        }
        if (functions[func] != null) {
            return functions[func].Call(go);
        }
        return null;
    }

    /// <summary>
    /// ִ��Lua����-Socket��Ϣ
    /// </summary>
    protected object[] CallMethod(string func, int key, ByteBuffer buffer) {
        if (lua == null) return null;
        if (!functions.ContainsKey(func)) {
            functions[func] = lua.GetFunction(func);
        }
        if (functions[func] != null) {
            return functions[func].Call(key, buffer);
        }
        return null;
    }

    /// <summary>
    /// ִ��Lua����-Web��Ϣ
    /// </summary>
    protected object[] CallMethod(string func, int key, object value) {
        if (lua == null) return null;
        if (!functions.ContainsKey(func)) {
            functions[func] = lua.GetFunction(func);
        }
        if (functions[func] != null) {
            return functions[func].Call(key, value);
        }
        return null;
    }

    //-----------------------------------------------------------------
    protected void OnDestroy() {
        CallMethod("OnDestroy");
        if (bundle) {
            bundle.Unload(true);
            bundle = null;  //�����ز�
        }
        Util.ClearMemory();
    }
}
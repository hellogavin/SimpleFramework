using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using System.Reflection;

public class GameManager : BaseLua {
    public LuaScriptMgr luaMgr;

    /// <summary>
    /// 初始化游戏管理器
    /// </summary>
    void Awake () {
        Init();
    }

    /// <summary>
    /// 初始化
    /// </summary>
    void Init() {
        InitGui();
        InitManagers();
        DontDestroyOnLoad(gameObject);  //防止销毁自己
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Application.targetFrameRate = Const.GameFrameRate;
    }

    /// <summary>
    /// 初始化GUI
    /// </summary>
    public void InitGui() {
        string name = "GUI";
        GameObject gui = GameObject.Find(name);
        if (gui != null) return;

        GameObject prefab = io.LoadPrefab(name);
        gui = Instantiate(prefab) as GameObject;
        gui.name = name;
    }

    /// <summary>
    /// 初始化管理器
    /// </summary>
    public void InitManagers() {
        Util.Add<PanelManager>(gameObject);
        Util.Add<MusicManager>(gameObject);
        Util.Add<TimerManager>(gameObject);
        Util.Add<ResourceManager>(gameObject);
    }

    /// <summary>
    /// 初始化Lua管理器
    /// </summary>
    public void InitLuaManager() {
        luaMgr = new LuaScriptMgr();

        Assembly assembly = Assembly.GetExecutingAssembly();
        Type[] types = assembly.GetTypes();
        List<Type> wrapList = new List<Type>();
        Type wrapType = typeof(ILuaWrap);

        for (int i = 0; i < types.Length; i++) {
            Type t = types[i];

            if (wrapType.IsAssignableFrom(t) && !t.IsAbstract) {
                wrapList.Add(t);
            }
        }
        luaMgr.LuaBinding(wrapList);
    }

    /// <summary>
    /// 资源初始化结束
    /// </summary>
    public void OnResourceInited() {
        InitLuaManager();
        luaMgr.DoFile("game");      //加载游戏
        luaMgr.DoFile("network");   //加载网络

        object[] panels = CallMethod("LuaPanel");
        //---------------------Lua面板---------------------------
        foreach (object o in panels) {
            string name = o.ToString().Trim();
            if (string.IsNullOrEmpty(name)) continue;
            name += "Panel";    //添加

            luaMgr.DoFile(name);
            Debug.LogWarning("LoadLua---->>>>" + name + ".lua"); 
        }
        //------------------------------------------------------------
        CallMethod("OnInitOK");   //初始化完成
    }

    /// <summary>
    /// 初始化场景
    /// </summary>
    public void OnInitScene() {
        Debug.Log("OnInitScene-->>" + Application.loadedLevelName);
    }

    /// <summary>
    /// 析构函数
    /// </summary>
    void OnDestroy() {
        Debug.Log("~GameManager was destroyed");
    }
}

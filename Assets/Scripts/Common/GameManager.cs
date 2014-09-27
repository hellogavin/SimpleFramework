using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;

public class GameManager : BaseLua {

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
        PrintDebugInfo();
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
    /// 打印调试信息
    /// </summary>
    public void PrintDebugInfo() {
        Debuger.EnableLog = false;
        if (!Const.DebugMode) return;
        Debuger.EnableLog = true;
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
    /// 资源初始化结束
    /// </summary>
    public void OnResourceInited() {
        InitObject();
        string text = "BackupPanel";
        string[] luapanels = text.Split(',');   //分割lua面板

        //---------------------Lua面板---------------------------
        Global.LuaObjects.Clear();  //加载预先的对象并初始化Lua脚本
        foreach (string panel in luapanels) {
            string name = panel.Trim();
            if (string.IsNullOrEmpty(name)) continue;
            BaseLua.luaNames.Add(name);  //缓存起来

            LuaState lua = new LuaState();
            TextAsset[] scripts = Const.luaScripts;
            foreach (TextAsset code in scripts) {
                lua.DoString(code.text);
            }
            TextAsset script = io.resourceManager.LoadScript(name + ".lua");
            if (script != null) lua.DoString(script.text);  //加载对象Lua脚本
            Global.LuaObjects.Add(name, lua);   //加入对象池

            Debuger.LogWarning("LoadLua---->>>>" + name + ".lua");
        }
        //------------------------------------------------------------
        io.panelManager.CreatePanel("Backup");  //创建面板
    }

    /// <summary>
    /// 初始化场景
    /// </summary>
    public void OnInitScene() {
        Debuger.Log("OnInitScene-->>" + Application.loadedLevelName);
    }

    /// <summary>
    /// 析构函数
    /// </summary>
    void OnDestroy() {
        Debuger.Log("~GameManager was destroyed");
    }
}

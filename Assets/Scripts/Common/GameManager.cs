using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;

public class GameManager : BaseLua {

    /// <summary>
    /// ��ʼ����Ϸ������
    /// </summary>
    void Awake () {
        Init();
    }

    /// <summary>
    /// ��ʼ��
    /// </summary>
    void Init() {
        InitGui();
        InitManagers();
        PrintDebugInfo();
        DontDestroyOnLoad(gameObject);  //��ֹ�����Լ�
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Application.targetFrameRate = Const.GameFrameRate;
    }

    /// <summary>
    /// ��ʼ��GUI
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
    /// ��ӡ������Ϣ
    /// </summary>
    public void PrintDebugInfo() {
        Debuger.EnableLog = false;
        if (!Const.DebugMode) return;
        Debuger.EnableLog = true;
    }

    /// <summary>
    /// ��ʼ��������
    /// </summary>
    public void InitManagers() {
        Util.Add<PanelManager>(gameObject);
        Util.Add<MusicManager>(gameObject);
        Util.Add<TimerManager>(gameObject);
        Util.Add<ResourceManager>(gameObject);
    }

    /// <summary>
    /// ��Դ��ʼ������
    /// </summary>
    public void OnResourceInited() {
        InitObject();
        string text = "BackupPanel";
        string[] luapanels = text.Split(',');   //�ָ�lua���

        //---------------------Lua���---------------------------
        Global.LuaObjects.Clear();  //����Ԥ�ȵĶ��󲢳�ʼ��Lua�ű�
        foreach (string panel in luapanels) {
            string name = panel.Trim();
            if (string.IsNullOrEmpty(name)) continue;
            BaseLua.luaNames.Add(name);  //��������

            LuaState lua = new LuaState();
            TextAsset[] scripts = Const.luaScripts;
            foreach (TextAsset code in scripts) {
                lua.DoString(code.text);
            }
            TextAsset script = io.resourceManager.LoadScript(name + ".lua");
            if (script != null) lua.DoString(script.text);  //���ض���Lua�ű�
            Global.LuaObjects.Add(name, lua);   //��������

            Debuger.LogWarning("LoadLua---->>>>" + name + ".lua");
        }
        //------------------------------------------------------------
        io.panelManager.CreatePanel("Backup");  //�������
    }

    /// <summary>
    /// ��ʼ������
    /// </summary>
    public void OnInitScene() {
        Debuger.Log("OnInitScene-->>" + Application.loadedLevelName);
    }

    /// <summary>
    /// ��������
    /// </summary>
    void OnDestroy() {
        Debuger.Log("~GameManager was destroyed");
    }
}

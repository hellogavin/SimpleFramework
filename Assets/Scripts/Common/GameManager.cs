using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using System.Reflection;

public class GameManager : BaseLua {
    public LuaScriptMgr luaMgr;

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

        GameObject prefab = ioo.LoadPrefab(name);
        gui = Instantiate(prefab) as GameObject;
        gui.name = name;
    }

    /// <summary>
    /// ��ʼ��������
    /// </summary>
    public void InitManagers() {
        Util.Add<PanelManager>(gameObject);
        Util.Add<MusicManager>(gameObject);
        Util.Add<TimerManager>(gameObject);
        Util.Add<SocketClient>(gameObject);
        Util.Add<NetworkManager>(gameObject);
        Util.Add<ResourceManager>(gameObject);
    }

    /// <summary>
    /// ��Դ��ʼ������
    /// </summary>
    public void OnResourceInited() {
        luaMgr = new LuaScriptMgr();
        luaMgr.Start();

        luaMgr.DoFile("game");      //������Ϸ
        luaMgr.DoFile("network");   //��������

        object[] panels = CallMethod("LuaScriptPanel");
        //---------------------Lua���---------------------------
        foreach (object o in panels) {
            string name = o.ToString().Trim();
            if (string.IsNullOrEmpty(name)) continue;
            name += "Panel";    //���

            luaMgr.DoFile(name);
            Debug.LogWarning("LoadLua---->>>>" + name + ".lua"); 
        }
        //------------------------------------------------------------
        CallMethod("OnInitOK");   //��ʼ�����
    }

    /// <summary>
    /// ��ʼ������
    /// </summary>
    public void OnInitScene() {
        Debug.Log("OnInitScene-->>" + Application.loadedLevelName);
    }

    /// <summary>
    /// ��������
    /// </summary>
    void OnDestroy() {
        Debug.Log("~GameManager was destroyed");
    }
}

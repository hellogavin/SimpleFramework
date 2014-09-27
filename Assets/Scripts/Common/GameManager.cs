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
        InitManagers(); 
        DontDestroyOnLoad(gameObject);  //��ֹ�����Լ�
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    /// <summary>
    /// ֡Ƶ����
    /// </summary>
    void Update() {
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
        StartCoroutine(OnReqLuainfo()); //���ط�������Lua����
    }

    /// <summary>
    /// ���������Lua��Ϣ
    /// </summary>
    IEnumerator OnReqLuainfo() {
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

            if (Debug.isDebugBuild) Debug.LogWarning("LoadLua---->>>>" + name + ".lua");
            yield return 0;
        }
        //------------------------------------------------------------
        io.panelManager.CreatePanel("Backup");  //�������
    }

    /// <summary>
    /// ��������
    /// </summary>
    void OnDestroy() {
        if (Debug.isDebugBuild) print("~GameManager was destroyed");
    }
}

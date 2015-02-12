using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;
using System.Reflection;
using System.IO;

public class GameManager : BaseLua {
    public LuaScriptMgr luaMgr;
    private string message;

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
        DontDestroyOnLoad(gameObject);  //防止销毁自己

        Util.Add<PanelManager>(gameObject);
        Util.Add<MusicManager>(gameObject);
        Util.Add<TimerManager>(gameObject);
        Util.Add<SocketClient>(gameObject);
        Util.Add<NetworkManager>(gameObject);

        CheckExtractResource(); //释放资源
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

        GameObject prefab = ioo.LoadPrefab(name);
        gui = Instantiate(prefab) as GameObject;
        gui.name = name;
    }

    /// <summary>
    /// 释放资源
    /// </summary>
    public void CheckExtractResource() {
        bool isExists = Directory.Exists(Util.DataPath) &&
          Directory.Exists(Util.DataPath + "lua/") && File.Exists(Util.DataPath + "files.txt");
        if (isExists || Const.DebugMode) {
            Util.Add<ResourceManager>(gameObject);
            return;   //文件已经解压过了，自己可添加检查文件列表逻辑
        }
        StartCoroutine(OnExtractResource());    //启动释放协成 
    }

    IEnumerator OnExtractResource() {
        string dataPath = Util.DataPath;  //数据目录
        string resPath = Util.AppContentPath(); //游戏包资源目录

        if (Directory.Exists(dataPath)) Directory.Delete(dataPath);
        Directory.CreateDirectory(dataPath);

        string infile = resPath + "/files.txt";
        string outfile = dataPath + "files.txt";
        if (File.Exists(outfile)) File.Delete(outfile);

        message = "正在解包文件:>files.txt";
        Debug.Log(message);
        if (Application.platform == RuntimePlatform.Android) {
            WWW www = new WWW(infile);
            yield return www;

            if (www.isDone) {
                File.WriteAllBytes(outfile, www.bytes);
            }
            yield return 0;
        } else File.Copy(infile, outfile, true);
        yield return new WaitForEndOfFrame();

        //释放所有文件到数据目录
        string[] files = File.ReadAllLines(outfile);
        foreach (var file in files) {
            infile = resPath + file;  //
            outfile = dataPath + file;
            message = "正在解包文件:>" + file;
            Debug.Log("正在解包文件:>" + infile);

            string dir = Path.GetDirectoryName(outfile);
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            if (Application.platform == RuntimePlatform.Android) {
                WWW www = new WWW(infile);
                yield return www;

                if (www.isDone) {
                    File.WriteAllBytes(outfile, www.bytes);
                }
                yield return 0;
            } else File.Copy(infile, outfile, true);
            yield return new WaitForEndOfFrame();
        }
        message = "解包完成!!!";
        yield return new WaitForSeconds(0.1f);
        message = string.Empty;

        //释放完成，开始启动资源管理器(此处可添加更新代码)
        Util.Add<ResourceManager>(gameObject);
    }

    void OnGUI() {
        GUI.Label(new Rect(10, 120, 960, 50), message);
    }

    /// <summary>
    /// 资源初始化结束
    /// </summary>
    public void OnResourceInited() {
        luaMgr = new LuaScriptMgr();
        luaMgr.Start();

        luaMgr.DoFile("game");      //加载游戏
        luaMgr.DoFile("network");   //加载网络

        object[] panels = CallMethod("LuaScriptPanel");
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

using UnityEngine;
using LuaInterface;
using System.Collections;
using System.Collections.Generic;
using System;

public class BaseLua : MonoBehaviour {
    private string data = null;
    private bool initialize = false;
    private LuaScriptMgr mgr = null;
    private AssetBundle bundle = null;
    /// <summary>
    /// Lua管理器
    /// </summary>
    protected LuaScriptMgr luaMgr {
        get {
            if (mgr == null) {
                mgr = io.gameManager.luaMgr;
            }
            return mgr;
        }
    }

    protected void Start() {
        CallMethod("Start");
    }

    protected void OnClick() {
        CallMethod("OnClick");
    }

    protected void OnClickEvent(GameObject go) {
        CallMethod("OnClick", go);
    }

    /// <summary>
    /// 初始化面板
    /// </summary>
    public void OnInit(AssetBundle bundle, string text = null) {
        this.data = text;   //初始化附加参数
        this.bundle = bundle; //初始化
        Debug.LogWarning("OnInit---->>>"+ name +" text:>" + text);
    }

    /// <summary>
    /// 获取一个GameObject资源
    /// </summary>
    /// <param name="name"></param>
    public GameObject GetGameObject(string name) {
        if (bundle == null) return null;
        return bundle.Load(name, typeof(GameObject)) as GameObject;
    }

    //-----------------------------------------------
    /// <summary>
    /// 执行Lua方法-无参数
    /// </summary>
    protected object[] CallMethod(string func) {
        if (luaMgr == null) return null;
        string funcName = name + "." + func;
        funcName = funcName.Replace("(Clone)", "");
        return mgr.CallLuaFunction(funcName);
    }

    /// <summary>
    /// 执行Lua方法
    /// </summary>
    protected object[] CallMethod(string func, GameObject go) {
        if (luaMgr == null) return null;
        string funcName = name + "." + func;
        funcName = funcName.Replace("(Clone)", "");
        return mgr.CallLuaFunction(funcName, go);
    }

    /// <summary>
    /// 执行Lua方法-Socket消息
    /// </summary>
    protected object[] CallMethod(string func, int key, ByteBuffer buffer) {
        if (luaMgr == null) return null;
        string funcName = "network." + func;
        funcName = funcName.Replace("(Clone)", "");
        return mgr.CallLuaFunction(funcName, key, buffer);
    }

    //-----------------------------------------------------------------
    protected void OnDestroy() {
        if (bundle) {
            bundle.Unload(true);
            bundle = null;  //销毁素材
        }
        mgr = null;
        Debug.Log("~" + name + " was destroy!");
    }
}
using System;
using UnityEngine;
using LuaInterface;

public class ioWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("f", f),
		new LuaMethod("c", c),
		new LuaMethod("AddPrefab", AddPrefab),
		new LuaMethod("GetPrefab", GetPrefab),
		new LuaMethod("RemovePrefab", RemovePrefab),
		new LuaMethod("LoadPrefab", LoadPrefab),
		new LuaMethod("New", Create),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("manager", get_manager, null),
		new LuaField("gameManager", get_gameManager, null),
		new LuaField("panelManager", get_panelManager, null),
		new LuaField("resourceManager", get_resourceManager, null),
		new LuaField("timerManager", get_timerManager, null),
		new LuaField("musicManager", get_musicManager, null),
		new LuaField("networkManager", get_networkManager, null),
		new LuaField("MainUI", get_MainUI, null),
		new LuaField("guiCamera", get_guiCamera, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		LuaDLL.luaL_error(L, "io class does not have a constructor function");
		return 0;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "io", typeof(io), regs, fields, "io");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_manager(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, io.manager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_gameManager(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, io.gameManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_panelManager(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, io.panelManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_resourceManager(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, io.resourceManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_timerManager(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, io.timerManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_musicManager(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, io.musicManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_networkManager(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, io.networkManager);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_MainUI(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, io.MainUI);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_guiCamera(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, io.guiCamera);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int f(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		object[] objs1 = LuaScriptMgr.GetParamsObject(L, 2, count - 1);
		string o = io.f(arg0,objs1);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int c(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		object[] objs0 = LuaScriptMgr.GetParamsObject(L, 1, count);
		string o = io.c(objs0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddPrefab(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		GameObject arg1 = (GameObject)LuaScriptMgr.GetNetObject(L, 2);
		io.AddPrefab(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPrefab(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		GameObject o = io.GetPrefab(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemovePrefab(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		io.RemovePrefab(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadPrefab(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		GameObject o = io.LoadPrefab(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}
}


using System;
using UnityEngine;
using LuaInterface;

public class PanelManagerWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("CreatePanel", CreatePanel),
		new LuaMethod("OnRequestResource", OnRequestResource),
		new LuaMethod("New", _CreatePanelManager),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreatePanelManager(IntPtr L)
	{
		LuaDLL.luaL_error(L, "PanelManager class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(PanelManager));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "PanelManager", typeof(PanelManager), regs, fields, "UnityEngine.MonoBehaviour");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CreatePanel(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		PanelManager obj = LuaScriptMgr.GetNetObject<PanelManager>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		obj.CreatePanel(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnRequestResource(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 4);
		PanelManager obj = LuaScriptMgr.GetNetObject<PanelManager>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		AssetBundle arg1 = LuaScriptMgr.GetNetObject<AssetBundle>(L, 3);
		string arg2 = LuaScriptMgr.GetLuaString(L, 4);
		obj.OnRequestResource(arg0,arg1,arg2);
		return 0;
	}
}


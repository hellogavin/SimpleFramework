using System;
using UnityEngine;
using LuaInterface;

public class LuaHelperWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("GetType", GetType),
		new LuaMethod("GetComponentInChildren", GetComponentInChildren),
		new LuaMethod("GetComponent", GetComponent),
		new LuaMethod("GetComponentsInChildren", GetComponentsInChildren),
		new LuaMethod("GetAllChild", GetAllChild),
		new LuaMethod("Action", Action),
		new LuaMethod("VoidDelegate", VoidDelegate),
		new LuaMethod("New", Create),
	};

	static LuaField[] fields = new LuaField[]
	{
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		LuaDLL.luaL_error(L, "LuaHelper class does not have a constructor function");
		return 0;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "LuaHelper", typeof(LuaHelper), regs, fields, "LuaHelper");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetType(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Type o = LuaHelper.GetType(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentInChildren(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject arg0 = (GameObject)LuaScriptMgr.GetNetObject(L, 1);
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		Component o = LuaHelper.GetComponentInChildren(arg0,arg1);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponent(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject arg0 = (GameObject)LuaScriptMgr.GetNetObject(L, 1);
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		Component o = LuaHelper.GetComponent(arg0,arg1);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentsInChildren(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject arg0 = (GameObject)LuaScriptMgr.GetNetObject(L, 1);
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		Component[] o = LuaHelper.GetComponentsInChildren(arg0,arg1);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAllChild(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		GameObject arg0 = (GameObject)LuaScriptMgr.GetNetObject(L, 1);
		Transform[] o = LuaHelper.GetAllChild(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Action(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction arg0 = LuaScriptMgr.GetLuaFunction(L, 1);
		Action o = LuaHelper.Action(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int VoidDelegate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		LuaFunction arg0 = LuaScriptMgr.GetLuaFunction(L, 1);
		UIEventListener.VoidDelegate o = LuaHelper.VoidDelegate(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}
}


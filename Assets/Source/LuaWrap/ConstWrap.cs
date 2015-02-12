﻿using System;
using UnityEngine;
using LuaInterface;

public class ConstWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", _CreateConst),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("DebugMode", get_DebugMode, set_DebugMode),
		new LuaField("TimerInterval", get_TimerInterval, set_TimerInterval),
		new LuaField("GameFrameRate", get_GameFrameRate, set_GameFrameRate),
		new LuaField("luaScripts", get_luaScripts, set_luaScripts),
		new LuaField("UserId", get_UserId, set_UserId),
		new LuaField("AppName", get_AppName, set_AppName),
		new LuaField("AppPrefix", get_AppPrefix, set_AppPrefix),
		new LuaField("WebUrl", get_WebUrl, set_WebUrl),
		new LuaField("SocketPort", get_SocketPort, set_SocketPort),
		new LuaField("SocketAddress", get_SocketAddress, set_SocketAddress),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateConst(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			Const obj = new Const();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Const.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Const));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "Const", typeof(Const), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DebugMode(IntPtr L)
	{
		LuaScriptMgr.Push(L, Const.DebugMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TimerInterval(IntPtr L)
	{
		LuaScriptMgr.Push(L, Const.TimerInterval);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GameFrameRate(IntPtr L)
	{
		LuaScriptMgr.Push(L, Const.GameFrameRate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_luaScripts(IntPtr L)
	{
		LuaScriptMgr.PushArray(L, Const.luaScripts);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UserId(IntPtr L)
	{
		LuaScriptMgr.Push(L, Const.UserId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AppName(IntPtr L)
	{
		LuaScriptMgr.Push(L, Const.AppName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AppPrefix(IntPtr L)
	{
		LuaScriptMgr.Push(L, Const.AppPrefix);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_WebUrl(IntPtr L)
	{
		LuaScriptMgr.Push(L, Const.WebUrl);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SocketPort(IntPtr L)
	{
		LuaScriptMgr.Push(L, Const.SocketPort);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SocketAddress(IntPtr L)
	{
		LuaScriptMgr.Push(L, Const.SocketAddress);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_DebugMode(IntPtr L)
	{
		Const.DebugMode = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_TimerInterval(IntPtr L)
	{
		Const.TimerInterval = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_GameFrameRate(IntPtr L)
	{
		Const.GameFrameRate = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_luaScripts(IntPtr L)
	{
		Const.luaScripts = LuaScriptMgr.GetNetObject<TextAsset[]>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_UserId(IntPtr L)
	{
		Const.UserId = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_AppName(IntPtr L)
	{
		Const.AppName = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_AppPrefix(IntPtr L)
	{
		Const.AppPrefix = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_WebUrl(IntPtr L)
	{
		Const.WebUrl = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_SocketPort(IntPtr L)
	{
		Const.SocketPort = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_SocketAddress(IntPtr L)
	{
		Const.SocketAddress = LuaScriptMgr.GetString(L, 3);
		return 0;
	}
}


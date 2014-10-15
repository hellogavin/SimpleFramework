using System;
using UnityEngine;
using LuaInterface;

public class ConstWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("New", Create),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("BetaMode", get_BetaMode, set_BetaMode),
		new LuaField("DebugMode", get_DebugMode, set_DebugMode),
		new LuaField("InnerNetMode", get_InnerNetMode, set_InnerNetMode),
		new LuaField("TimerInterval", get_TimerInterval, set_TimerInterval),
		new LuaField("GameFrameRate", get_GameFrameRate, set_GameFrameRate),
		new LuaField("luaScripts", get_luaScripts, set_luaScripts),
		new LuaField("UserId", get_UserId, set_UserId),
		new LuaField("AppName", get_AppName, set_AppName),
		new LuaField("AppPrefix", get_AppPrefix, set_AppPrefix),
		new LuaField("ResDirectory", get_ResDirectory, set_ResDirectory),
		new LuaField("WebUrl", get_WebUrl, set_WebUrl),
		new LuaField("SocketAddress", get_SocketAddress, set_SocketAddress),
		new LuaField("SocketPort", get_SocketPort, set_SocketPort),
		new LuaField("uid", get_uid, set_uid),
		new LuaField("sid", get_sid, set_sid),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		object obj = null;

		if (count == 0)
		{
			obj = new Const();
			LuaScriptMgr.PushResult(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Const.New");
		}

		return 0;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "Const", typeof(Const), regs, fields, "Const");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_BetaMode(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, Const.BetaMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DebugMode(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, Const.DebugMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_InnerNetMode(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, Const.InnerNetMode);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_TimerInterval(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, Const.TimerInterval);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_GameFrameRate(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, Const.GameFrameRate);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_luaScripts(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, Const.luaScripts);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_UserId(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, Const.UserId);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AppName(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, Const.AppName);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AppPrefix(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, Const.AppPrefix);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ResDirectory(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, Const.ResDirectory);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_WebUrl(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, Const.WebUrl);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SocketAddress(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, Const.SocketAddress);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SocketPort(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, Const.SocketPort);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_uid(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, Const.uid);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sid(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, Const.sid);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_BetaMode(IntPtr L)
	{
		Const.BetaMode = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_DebugMode(IntPtr L)
	{
		Const.DebugMode = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_InnerNetMode(IntPtr L)
	{
		Const.InnerNetMode = LuaScriptMgr.GetBoolean(L, 3);
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
		Const.luaScripts = (TextAsset[])LuaScriptMgr.GetNetObject(L, 3);
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
	static int set_ResDirectory(IntPtr L)
	{
		Const.ResDirectory = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_WebUrl(IntPtr L)
	{
		Const.WebUrl = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_SocketAddress(IntPtr L)
	{
		Const.SocketAddress = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_SocketPort(IntPtr L)
	{
		Const.SocketPort = (int)LuaScriptMgr.GetNumber(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_uid(IntPtr L)
	{
		Const.uid = LuaScriptMgr.GetString(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_sid(IntPtr L)
	{
		Const.sid = LuaScriptMgr.GetString(L, 3);
		return 0;
	}
}


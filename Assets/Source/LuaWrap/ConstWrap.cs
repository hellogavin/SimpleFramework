using UnityEngine;
using System;
using LuaInterface;
using Object = UnityEngine.Object;

public class ConstWrap : ILuaWrap
{
	public static LuaScriptMgr luaMgr = null;
	public static int reference = -1;

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
	static int Create(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);
		object obj = null;

		if (count == 0)
		{
			obj = new Const();
			luaMgr.PushResult(obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Const.New' has some invalid arguments");
		}

		return 0;
	}

	public void Register()
	{
		LuaMethod[] metas = new LuaMethod[]
		{
			new LuaMethod("__index", Lua_Index),
			new LuaMethod("__newindex", Lua_NewIndex),
		};

		luaMgr = LuaScriptMgr.Instance;
		reference = luaMgr.RegisterLib("Const", regs);
		luaMgr.CreateMetaTable("Const", metas, typeof(Const));
		luaMgr.RegisterField(typeof(Const), fields);
	}

	static bool get_BetaMode(IntPtr l)
	{
		luaMgr.PushResult(Const.BetaMode);
		return true;
	}

	static bool get_DebugMode(IntPtr l)
	{
		luaMgr.PushResult(Const.DebugMode);
		return true;
	}

	static bool get_InnerNetMode(IntPtr l)
	{
		luaMgr.PushResult(Const.InnerNetMode);
		return true;
	}

	static bool get_TimerInterval(IntPtr l)
	{
		luaMgr.PushResult(Const.TimerInterval);
		return true;
	}

	static bool get_GameFrameRate(IntPtr l)
	{
		luaMgr.PushResult(Const.GameFrameRate);
		return true;
	}

	static bool get_luaScripts(IntPtr l)
	{
		luaMgr.PushResult(Const.luaScripts);
		return true;
	}

	static bool get_UserId(IntPtr l)
	{
		luaMgr.PushResult(Const.UserId);
		return true;
	}

	static bool get_AppName(IntPtr l)
	{
		luaMgr.PushResult(Const.AppName);
		return true;
	}

	static bool get_AppPrefix(IntPtr l)
	{
		luaMgr.PushResult(Const.AppPrefix);
		return true;
	}

	static bool get_ResDirectory(IntPtr l)
	{
		luaMgr.PushResult(Const.ResDirectory);
		return true;
	}

	static bool get_WebUrl(IntPtr l)
	{
		luaMgr.PushResult(Const.WebUrl);
		return true;
	}

	static bool get_SocketAddress(IntPtr l)
	{
		luaMgr.PushResult(Const.SocketAddress);
		return true;
	}

	static bool get_SocketPort(IntPtr l)
	{
		luaMgr.PushResult(Const.SocketPort);
		return true;
	}

	static bool get_uid(IntPtr l)
	{
		luaMgr.PushResult(Const.uid);
		return true;
	}

	static bool get_sid(IntPtr l)
	{
		luaMgr.PushResult(Const.sid);
		return true;
	}

	public static bool TryLuaIndex(IntPtr l)
	{
		string str = luaMgr.GetString(2);

		if (luaMgr.Index(reference, str, fields))
		{
			return true;
		}

		return ConstWrap.TryLuaIndex(l);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Index(IntPtr l)
	{
		if (TryLuaIndex(l))
		{
			return 1;
		}

		string str = luaMgr.GetString(2);
		LuaDLL.luaL_error(l, string.Format("'Const' does not contain a definition for '{0}'", str));
		return 0;
	}

	static bool set_BetaMode(IntPtr l)
	{
		Const.BetaMode = luaMgr.GetBoolean(3);
		return true;
	}

	static bool set_DebugMode(IntPtr l)
	{
		Const.DebugMode = luaMgr.GetBoolean(3);
		return true;
	}

	static bool set_InnerNetMode(IntPtr l)
	{
		Const.InnerNetMode = luaMgr.GetBoolean(3);
		return true;
	}

	static bool set_TimerInterval(IntPtr l)
	{
		Const.TimerInterval = (int)luaMgr.GetNumber(3);
		return true;
	}

	static bool set_GameFrameRate(IntPtr l)
	{
		Const.GameFrameRate = (int)luaMgr.GetNumber(3);
		return true;
	}

	static bool set_luaScripts(IntPtr l)
	{
		Const.luaScripts = (TextAsset[])luaMgr.GetNetObject(3);
		return true;
	}

	static bool set_UserId(IntPtr l)
	{
		Const.UserId = luaMgr.GetString(3);
		return true;
	}

	static bool set_AppName(IntPtr l)
	{
		Const.AppName = luaMgr.GetString(3);
		return true;
	}

	static bool set_AppPrefix(IntPtr l)
	{
		Const.AppPrefix = luaMgr.GetString(3);
		return true;
	}

	static bool set_ResDirectory(IntPtr l)
	{
		Const.ResDirectory = luaMgr.GetString(3);
		return true;
	}

	static bool set_WebUrl(IntPtr l)
	{
		Const.WebUrl = luaMgr.GetString(3);
		return true;
	}

	static bool set_SocketAddress(IntPtr l)
	{
		Const.SocketAddress = luaMgr.GetString(3);
		return true;
	}

	static bool set_SocketPort(IntPtr l)
	{
		Const.SocketPort = (int)luaMgr.GetNumber(3);
		return true;
	}

	static bool set_uid(IntPtr l)
	{
		Const.uid = luaMgr.GetString(3);
		return true;
	}

	static bool set_sid(IntPtr l)
	{
		Const.sid = luaMgr.GetString(3);
		return true;
	}

	public static bool TryLuaNewIndex(IntPtr l)
	{
		string str = luaMgr.GetString(2);

		if (luaMgr.NewIndex(reference, str, fields))
		{
			return true;
		}

		return ConstWrap.TryLuaNewIndex(l);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_NewIndex(IntPtr l)
	{
		if (TryLuaNewIndex(l))
		{
			return 0;
		}

		string str = luaMgr.GetString(2);
		LuaDLL.luaL_error(l, string.Format("'Const' does not contain a definition for '{0}'", str));
		return 0;
	}
}


using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class ioWrap : ILuaWrap
{
	public static LuaScriptMgr luaMgr = null;
	public static int reference = -1;

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
	static int Create(IntPtr l)
	{
		LuaDLL.luaL_error(l, "io class does not have a constructor function");
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
		reference = luaMgr.RegisterLib("io", regs);
		luaMgr.CreateMetaTable("io", metas, typeof(io));
		luaMgr.RegisterField(typeof(io), fields);
	}

	static bool get_manager(IntPtr l)
	{
		luaMgr.PushResult(io.manager);
		return true;
	}

	static bool get_gameManager(IntPtr l)
	{
		luaMgr.PushResult(io.gameManager);
		return true;
	}

	static bool get_panelManager(IntPtr l)
	{
		luaMgr.PushResult(io.panelManager);
		return true;
	}

	static bool get_resourceManager(IntPtr l)
	{
		luaMgr.PushResult(io.resourceManager);
		return true;
	}

	static bool get_timerManager(IntPtr l)
	{
		luaMgr.PushResult(io.timerManager);
		return true;
	}

	static bool get_musicManager(IntPtr l)
	{
		luaMgr.PushResult(io.musicManager);
		return true;
	}

	static bool get_networkManager(IntPtr l)
	{
		luaMgr.PushResult(io.networkManager);
		return true;
	}

	static bool get_MainUI(IntPtr l)
	{
		luaMgr.PushResult(io.MainUI);
		return true;
	}

	static bool get_guiCamera(IntPtr l)
	{
		luaMgr.PushResult(io.guiCamera);
		return true;
	}

	public static bool TryLuaIndex(IntPtr l)
	{
		string str = luaMgr.GetString(2);

		if (luaMgr.Index(reference, str, fields))
		{
			return true;
		}

		return ioWrap.TryLuaIndex(l);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Index(IntPtr l)
	{
		if (TryLuaIndex(l))
		{
			return 1;
		}

		string str = luaMgr.GetString(2);
		LuaDLL.luaL_error(l, string.Format("'io' does not contain a definition for '{0}'", str));
		return 0;
	}

	public static bool TryLuaNewIndex(IntPtr l)
	{
		string str = luaMgr.GetString(2);

		if (luaMgr.NewIndex(reference, str, fields))
		{
			return true;
		}

		return ioWrap.TryLuaNewIndex(l);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_NewIndex(IntPtr l)
	{
		if (TryLuaNewIndex(l))
		{
			return 0;
		}

		string str = luaMgr.GetString(2);
		LuaDLL.luaL_error(l, string.Format("'io' does not contain a definition for '{0}'", str));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int f(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);
		string arg0 = luaMgr.GetString(1);
		object[] objs1 = luaMgr.GetParamsObject<object>(2, count - 1);
		string o = io.f(arg0,objs1);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int c(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);
		object[] objs0 = luaMgr.GetParamsObject<object>(1, count - 0);
		string o = io.c(objs0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddPrefab(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		string arg0 = luaMgr.GetString(1);
		GameObject arg1 = (GameObject)luaMgr.GetNetObject(2);
		io.AddPrefab(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetPrefab(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		string arg0 = luaMgr.GetString(1);
		GameObject o = io.GetPrefab(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemovePrefab(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		string arg0 = luaMgr.GetString(1);
		io.RemovePrefab(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadPrefab(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		string arg0 = luaMgr.GetString(1);
		GameObject o = io.LoadPrefab(arg0);
		luaMgr.PushResult(o);
		return 1;
	}
}


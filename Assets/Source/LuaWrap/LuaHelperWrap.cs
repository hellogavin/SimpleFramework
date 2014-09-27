using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class LuaHelperWrap : ILuaWrap
{
	public static LuaScriptMgr luaMgr = null;
	public static int reference = -1;

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
	static int Create(IntPtr l)
	{
		LuaDLL.luaL_error(l, "LuaHelper class does not have a constructor function");
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
		reference = luaMgr.RegisterLib("LuaHelper", regs);
		luaMgr.CreateMetaTable("LuaHelper", metas, typeof(LuaHelper));
		luaMgr.RegisterField(typeof(LuaHelper), fields);
	}

	public static bool TryLuaIndex(IntPtr l)
	{
		string str = luaMgr.GetString(2);

		if (luaMgr.Index(reference, str, fields))
		{
			return true;
		}

		return LuaHelperWrap.TryLuaIndex(l);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Index(IntPtr l)
	{
		if (TryLuaIndex(l))
		{
			return 1;
		}

		string str = luaMgr.GetString(2);
		LuaDLL.luaL_error(l, string.Format("'LuaHelper' does not contain a definition for '{0}'", str));
		return 0;
	}

	public static bool TryLuaNewIndex(IntPtr l)
	{
		string str = luaMgr.GetString(2);

		if (luaMgr.NewIndex(reference, str, fields))
		{
			return true;
		}

		return LuaHelperWrap.TryLuaNewIndex(l);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_NewIndex(IntPtr l)
	{
		if (TryLuaNewIndex(l))
		{
			return 0;
		}

		string str = luaMgr.GetString(2);
		LuaDLL.luaL_error(l, string.Format("'LuaHelper' does not contain a definition for '{0}'", str));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetType(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		string arg0 = luaMgr.GetString(1);
		Type o = LuaHelper.GetType(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentInChildren(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		GameObject arg0 = (GameObject)luaMgr.GetNetObject(1);
		string arg1 = luaMgr.GetString(2);
		Component o = LuaHelper.GetComponentInChildren(arg0,arg1);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponent(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		GameObject arg0 = (GameObject)luaMgr.GetNetObject(1);
		string arg1 = luaMgr.GetString(2);
		Component o = LuaHelper.GetComponent(arg0,arg1);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetComponentsInChildren(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		GameObject arg0 = (GameObject)luaMgr.GetNetObject(1);
		string arg1 = luaMgr.GetString(2);
		Component[] o = LuaHelper.GetComponentsInChildren(arg0,arg1);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetAllChild(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		GameObject arg0 = (GameObject)luaMgr.GetNetObject(1);
		Transform[] o = LuaHelper.GetAllChild(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Action(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		LuaFunction arg0 = luaMgr.GetLuaFunction(1);
		Action o = LuaHelper.Action(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int VoidDelegate(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		LuaFunction arg0 = luaMgr.GetLuaFunction(1);
		UIEventListener.VoidDelegate o = LuaHelper.VoidDelegate(arg0);
		luaMgr.PushResult(o);
		return 1;
	}
}


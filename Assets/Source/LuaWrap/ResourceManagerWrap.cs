using System;
using UnityEngine;
using LuaInterface;

public class ResourceManagerWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("LoadBundle", LoadBundle),
		new LuaMethod("New", _CreateResourceManager),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateResourceManager(IntPtr L)
	{
		LuaDLL.luaL_error(L, "ResourceManager class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(ResourceManager));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "ResourceManager", typeof(ResourceManager), regs, fields, "UnityEngine.MonoBehaviour");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LoadBundle(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		ResourceManager obj = LuaScriptMgr.GetNetObject<ResourceManager>(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 2);
		AssetBundle o = obj.LoadBundle(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}


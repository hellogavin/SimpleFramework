using System;
using LuaInterface;

public class NetworkManagerWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("AddEvent", AddEvent),
		new LuaMethod("SendConnect", SendConnect),
		new LuaMethod("SendMessage", SendMessage),
		new LuaMethod("New", _CreateNetworkManager),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateNetworkManager(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 0)
		{
			NetworkManager obj = new NetworkManager();
			LuaScriptMgr.Push(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: NetworkManager.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(NetworkManager));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "NetworkManager", typeof(NetworkManager), regs, fields, "BaseLua");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddEvent(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
		ByteBuffer arg1 = LuaScriptMgr.GetNetObject<ByteBuffer>(L, 2);
		NetworkManager.AddEvent(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendConnect(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		NetworkManager obj = LuaScriptMgr.GetNetObject<NetworkManager>(L, 1);
		obj.SendConnect();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendMessage(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		NetworkManager obj = LuaScriptMgr.GetNetObject<NetworkManager>(L, 1);
		ByteBuffer arg0 = LuaScriptMgr.GetNetObject<ByteBuffer>(L, 2);
		obj.SendMessage(arg0);
		return 0;
	}
}


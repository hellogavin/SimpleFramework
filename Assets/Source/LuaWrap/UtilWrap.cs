using System;
using UnityEngine;
using LuaInterface;

public class UtilWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Int", Int),
		new LuaMethod("Float", Float),
		new LuaMethod("Long", Long),
		new LuaMethod("Random", Random),
		new LuaMethod("Uid", Uid),
		new LuaMethod("GetTime", GetTime),
		new LuaMethod("Child", Child),
		new LuaMethod("Peer", Peer),
		new LuaMethod("Vibrate", Vibrate),
		new LuaMethod("Encode", Encode),
		new LuaMethod("Decode", Decode),
		new LuaMethod("IsNumeric", IsNumeric),
		new LuaMethod("HashToMD5Hex", HashToMD5Hex),
		new LuaMethod("md5", md5),
		new LuaMethod("md5file", md5file),
		new LuaMethod("CompressFile", CompressFile),
		new LuaMethod("DecompressFile", DecompressFile),
		new LuaMethod("Compress", Compress),
		new LuaMethod("Decompress", Decompress),
		new LuaMethod("ClearChild", ClearChild),
		new LuaMethod("GetKey", GetKey),
		new LuaMethod("GetInt", GetInt),
		new LuaMethod("HasKey", HasKey),
		new LuaMethod("SetInt", SetInt),
		new LuaMethod("GetString", GetString),
		new LuaMethod("SetString", SetString),
		new LuaMethod("RemoveData", RemoveData),
		new LuaMethod("ClearMemory", ClearMemory),
		new LuaMethod("IsNumber", IsNumber),
		new LuaMethod("GetFileText", GetFileText),
		new LuaMethod("GetDataDir", GetDataDir),
		new LuaMethod("AppContentPath", AppContentPath),
		new LuaMethod("AddClick", AddClick),
		new LuaMethod("LuaPath", LuaPath),
		new LuaMethod("Log", Log),
		new LuaMethod("LogWarning", LogWarning),
		new LuaMethod("LogError", LogError),
		new LuaMethod("New", Create),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("AppContentDataUri", get_AppContentDataUri, null),
		new LuaField("DataPath", get_DataPath, null),
		new LuaField("NetAvailable", get_NetAvailable, null),
		new LuaField("IsWifi", get_IsWifi, null),
		new LuaField("isLogin", get_isLogin, null),
		new LuaField("isMain", get_isMain, null),
		new LuaField("isFight", get_isFight, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		object obj = null;

		if (count == 0)
		{
			obj = new Util();
			LuaScriptMgr.PushResult(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Util.New");
		}

		return 0;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "Util", typeof(Util), regs, fields, "Util");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_AppContentDataUri(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, Util.AppContentDataUri);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_DataPath(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, Util.DataPath);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_NetAvailable(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, Util.NetAvailable);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsWifi(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, Util.IsWifi);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isLogin(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, Util.isLogin);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isMain(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, Util.isMain);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_isFight(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, Util.isFight);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Int(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 1);
		int o = Util.Int(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Float(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 1);
		float o = Util.Float(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Long(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 1);
		long o = Util.Long(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Random(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(float), typeof(float)};
		Type[] types1 = {typeof(int), typeof(int)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			float o = Util.Random(arg0,arg1);
			LuaScriptMgr.PushResult(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
			int o = Util.Random(arg0,arg1);
			LuaScriptMgr.PushResult(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Util.Random");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Uid(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string o = Util.Uid(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTime(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		long o = Util.GetTime();
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Child(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(Transform), typeof(string)};
		Type[] types1 = {typeof(GameObject), typeof(string)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			Transform arg0 = (Transform)LuaScriptMgr.GetNetObject(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			GameObject o = Util.Child(arg0,arg1);
			LuaScriptMgr.PushResult(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			GameObject arg0 = (GameObject)LuaScriptMgr.GetNetObject(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			GameObject o = Util.Child(arg0,arg1);
			LuaScriptMgr.PushResult(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Util.Child");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Peer(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(Transform), typeof(string)};
		Type[] types1 = {typeof(GameObject), typeof(string)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			Transform arg0 = (Transform)LuaScriptMgr.GetNetObject(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			GameObject o = Util.Peer(arg0,arg1);
			LuaScriptMgr.PushResult(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			GameObject arg0 = (GameObject)LuaScriptMgr.GetNetObject(L, 1);
			string arg1 = LuaScriptMgr.GetString(L, 2);
			GameObject o = Util.Peer(arg0,arg1);
			LuaScriptMgr.PushResult(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Util.Peer");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Vibrate(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Util.Vibrate();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Encode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string o = Util.Encode(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Decode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string o = Util.Decode(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsNumeric(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		bool o = Util.IsNumeric(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HashToMD5Hex(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string o = Util.HashToMD5Hex(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int md5(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string o = Util.md5(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int md5file(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string o = Util.md5file(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CompressFile(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		Util.CompressFile(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DecompressFile(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string o = Util.DecompressFile(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Compress(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string o = Util.Compress(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Decompress(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string o = Util.Decompress(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearChild(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Transform arg0 = (Transform)LuaScriptMgr.GetNetObject(L, 1);
		Util.ClearChild(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetKey(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string o = Util.GetKey(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInt(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		int o = Util.GetInt(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HasKey(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		bool o = Util.HasKey(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetInt(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 2);
		Util.SetInt(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string o = Util.GetString(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetString(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string arg1 = LuaScriptMgr.GetLuaString(L, 2);
		Util.SetString(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Util.RemoveData(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearMemory(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		Util.ClearMemory();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsNumber(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		bool o = Util.IsNumber(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetFileText(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string o = Util.GetFileText(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetDataDir(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		string o = Util.GetDataDir();
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AppContentPath(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 0);
		string o = Util.AppContentPath();
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddClick(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		GameObject arg0 = (GameObject)LuaScriptMgr.GetNetObject(L, 1);
		object arg1 = LuaScriptMgr.GetVarObject(L, 2);
		Util.AddClick(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaPath(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		string o = Util.LuaPath(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Log(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Util.Log(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogWarning(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Util.LogWarning(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogError(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		Util.LogError(arg0);
		return 0;
	}
}


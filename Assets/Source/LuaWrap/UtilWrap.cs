using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class UtilWrap : ILuaWrap
{
	public static LuaScriptMgr luaMgr = null;
	public static int reference = -1;

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
	static int Create(IntPtr l)
	{
		LuaDLL.luaL_error(l, "Util class does not have a constructor function");
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
		reference = luaMgr.RegisterLib("Util", regs);
		luaMgr.CreateMetaTable("Util", metas, typeof(Util));
		luaMgr.RegisterField(typeof(Util), fields);
	}

	static bool get_AppContentDataUri(IntPtr l)
	{
		luaMgr.PushResult(Util.AppContentDataUri);
		return true;
	}

	static bool get_DataPath(IntPtr l)
	{
		luaMgr.PushResult(Util.DataPath);
		return true;
	}

	static bool get_NetAvailable(IntPtr l)
	{
		luaMgr.PushResult(Util.NetAvailable);
		return true;
	}

	static bool get_IsWifi(IntPtr l)
	{
		luaMgr.PushResult(Util.IsWifi);
		return true;
	}

	static bool get_isLogin(IntPtr l)
	{
		luaMgr.PushResult(Util.isLogin);
		return true;
	}

	static bool get_isMain(IntPtr l)
	{
		luaMgr.PushResult(Util.isMain);
		return true;
	}

	static bool get_isFight(IntPtr l)
	{
		luaMgr.PushResult(Util.isFight);
		return true;
	}

	public static bool TryLuaIndex(IntPtr l)
	{
		string str = luaMgr.GetString(2);

		if (luaMgr.Index(reference, str, fields))
		{
			return true;
		}

		return UtilWrap.TryLuaIndex(l);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Index(IntPtr l)
	{
		if (TryLuaIndex(l))
		{
			return 1;
		}

		string str = luaMgr.GetString(2);
		LuaDLL.luaL_error(l, string.Format("'Util' does not contain a definition for '{0}'", str));
		return 0;
	}

	public static bool TryLuaNewIndex(IntPtr l)
	{
		string str = luaMgr.GetString(2);

		if (luaMgr.NewIndex(reference, str, fields))
		{
			return true;
		}

		return UtilWrap.TryLuaNewIndex(l);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_NewIndex(IntPtr l)
	{
		if (TryLuaNewIndex(l))
		{
			return 0;
		}

		string str = luaMgr.GetString(2);
		LuaDLL.luaL_error(l, string.Format("'Util' does not contain a definition for '{0}'", str));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Int(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		object arg0 = (object)luaMgr.GetNetObject(1);
		int o = Util.Int(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Float(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		object arg0 = (object)luaMgr.GetNetObject(1);
		float o = Util.Float(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Long(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		object arg0 = (object)luaMgr.GetNetObject(1);
		long o = Util.Long(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Random(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		Type[] types0 = {typeof(float), typeof(float)};
		Type[] types1 = {typeof(int), typeof(int)};

		if (count == 2 && luaMgr.CheckTypes(types0, 1))
		{
			float arg0 = (float)luaMgr.GetNumber(1);
			float arg1 = (float)luaMgr.GetNumber(2);
			float o = Util.Random(arg0,arg1);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 2 && luaMgr.CheckTypes(types1, 1))
		{
			int arg0 = (int)luaMgr.GetNumber(1);
			int arg1 = (int)luaMgr.GetNumber(2);
			int o = Util.Random(arg0,arg1);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Util.Random' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Uid(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		string arg0 = luaMgr.GetString(1);
		string o = Util.Uid(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetTime(IntPtr l)
	{
		luaMgr.CheckArgsCount(0);
		long o = Util.GetTime();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Child(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		Type[] types0 = {typeof(Transform), typeof(string)};
		Type[] types1 = {typeof(GameObject), typeof(string)};

		if (count == 2 && luaMgr.CheckTypes(types0, 1))
		{
			Transform arg0 = (Transform)luaMgr.GetNetObject(1);
			string arg1 = luaMgr.GetString(2);
			GameObject o = Util.Child(arg0,arg1);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 2 && luaMgr.CheckTypes(types1, 1))
		{
			GameObject arg0 = (GameObject)luaMgr.GetNetObject(1);
			string arg1 = luaMgr.GetString(2);
			GameObject o = Util.Child(arg0,arg1);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Util.Child' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Peer(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);

		Type[] types0 = {typeof(Transform), typeof(string)};
		Type[] types1 = {typeof(GameObject), typeof(string)};

		if (count == 2 && luaMgr.CheckTypes(types0, 1))
		{
			Transform arg0 = (Transform)luaMgr.GetNetObject(1);
			string arg1 = luaMgr.GetString(2);
			GameObject o = Util.Peer(arg0,arg1);
			luaMgr.PushResult(o);
			return 1;
		}
		else if (count == 2 && luaMgr.CheckTypes(types1, 1))
		{
			GameObject arg0 = (GameObject)luaMgr.GetNetObject(1);
			string arg1 = luaMgr.GetString(2);
			GameObject o = Util.Peer(arg0,arg1);
			luaMgr.PushResult(o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'Util.Peer' has some invalid arguments");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Vibrate(IntPtr l)
	{
		luaMgr.CheckArgsCount(0);
		Util.Vibrate();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Encode(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		string arg0 = luaMgr.GetString(1);
		string o = Util.Encode(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Decode(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		string arg0 = luaMgr.GetString(1);
		string o = Util.Decode(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsNumeric(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		string arg0 = luaMgr.GetString(1);
		bool o = Util.IsNumeric(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HashToMD5Hex(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		string arg0 = luaMgr.GetString(1);
		string o = Util.HashToMD5Hex(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int md5(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		string arg0 = luaMgr.GetString(1);
		string o = Util.md5(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int md5file(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		string arg0 = luaMgr.GetString(1);
		string o = Util.md5file(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CompressFile(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		string arg0 = luaMgr.GetString(1);
		string arg1 = luaMgr.GetString(2);
		Util.CompressFile(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DecompressFile(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		string arg0 = luaMgr.GetString(1);
		string o = Util.DecompressFile(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Compress(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		string arg0 = luaMgr.GetString(1);
		string o = Util.Compress(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Decompress(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		string arg0 = luaMgr.GetString(1);
		string o = Util.Decompress(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearChild(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		Transform arg0 = (Transform)luaMgr.GetNetObject(1);
		Util.ClearChild(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetKey(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		string arg0 = luaMgr.GetString(1);
		string o = Util.GetKey(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetInt(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		string arg0 = luaMgr.GetString(1);
		int o = Util.GetInt(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int HasKey(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		string arg0 = luaMgr.GetString(1);
		bool o = Util.HasKey(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetInt(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		string arg0 = luaMgr.GetString(1);
		int arg1 = (int)luaMgr.GetNumber(2);
		Util.SetInt(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetString(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		string arg0 = luaMgr.GetString(1);
		string o = Util.GetString(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetString(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		string arg0 = luaMgr.GetString(1);
		string arg1 = luaMgr.GetString(2);
		Util.SetString(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RemoveData(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		string arg0 = luaMgr.GetString(1);
		Util.RemoveData(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClearMemory(IntPtr l)
	{
		luaMgr.CheckArgsCount(0);
		Util.ClearMemory();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IsNumber(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		string arg0 = luaMgr.GetString(1);
		bool o = Util.IsNumber(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetFileText(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		string arg0 = luaMgr.GetString(1);
		string o = Util.GetFileText(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetDataDir(IntPtr l)
	{
		luaMgr.CheckArgsCount(0);
		string o = Util.GetDataDir();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AppContentPath(IntPtr l)
	{
		luaMgr.CheckArgsCount(0);
		string o = Util.AppContentPath();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddClick(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		GameObject arg0 = (GameObject)luaMgr.GetNetObject(1);
		object arg1 = (object)luaMgr.GetNetObject(2);
		Util.AddClick(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LuaPath(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		string arg0 = luaMgr.GetString(1);
		string o = Util.LuaPath(arg0);
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Log(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		string arg0 = luaMgr.GetString(1);
		Util.Log(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogWarning(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		string arg0 = luaMgr.GetString(1);
		Util.LogWarning(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogError(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		string arg0 = luaMgr.GetString(1);
		Util.LogError(arg0);
		return 0;
	}
}


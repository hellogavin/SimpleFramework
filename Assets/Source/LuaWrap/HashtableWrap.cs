using System.Collections;
using System;
using System.Runtime.Serialization;
using LuaInterface;

public class HashtableWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("get_Item", get_Item),
		new LuaMethod("set_Item", set_Item),
		new LuaMethod("CopyTo", CopyTo),
		new LuaMethod("Add", Add),
		new LuaMethod("Clear", Clear),
		new LuaMethod("Contains", Contains),
		new LuaMethod("GetEnumerator", GetEnumerator),
		new LuaMethod("Remove", Remove),
		new LuaMethod("ContainsKey", ContainsKey),
		new LuaMethod("ContainsValue", ContainsValue),
		new LuaMethod("Clone", Clone),
		new LuaMethod("GetObjectData", GetObjectData),
		new LuaMethod("OnDeserialization", OnDeserialization),
		new LuaMethod("Synchronized", Synchronized),
		new LuaMethod("New", _CreateHashtable),
		new LuaMethod("GetClassType", GetClassType),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("Count", get_Count, null),
		new LuaField("IsSynchronized", get_IsSynchronized, null),
		new LuaField("SyncRoot", get_SyncRoot, null),
		new LuaField("IsFixedSize", get_IsFixedSize, null),
		new LuaField("IsReadOnly", get_IsReadOnly, null),
		new LuaField("Keys", get_Keys, null),
		new LuaField("Values", get_Values, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateHashtable(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types1 = {typeof(IDictionary)};
		Type[] types2 = {typeof(IEqualityComparer)};
		Type[] types3 = {typeof(int)};
		Type[] types4 = {typeof(int), typeof(float)};
		Type[] types5 = {typeof(int), typeof(IEqualityComparer)};
		Type[] types6 = {typeof(IDictionary), typeof(float)};
		Type[] types7 = {typeof(IDictionary), typeof(IEqualityComparer)};
		Type[] types8 = {typeof(int), typeof(float), typeof(IEqualityComparer)};
		Type[] types9 = {typeof(IDictionary), typeof(float), typeof(IEqualityComparer)};

		if (count == 0)
		{
			Hashtable obj = new Hashtable();
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			IDictionary arg0 = LuaScriptMgr.GetNetObject<IDictionary>(L, 1);
			Hashtable obj = new Hashtable(arg0);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, types2, 1))
		{
			IEqualityComparer arg0 = LuaScriptMgr.GetNetObject<IEqualityComparer>(L, 1);
			Hashtable obj = new Hashtable(arg0);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 1 && LuaScriptMgr.CheckTypes(L, types3, 1))
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			Hashtable obj = new Hashtable(arg0);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types4, 1))
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Hashtable obj = new Hashtable(arg0,arg1);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types5, 1))
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			IEqualityComparer arg1 = LuaScriptMgr.GetNetObject<IEqualityComparer>(L, 2);
			Hashtable obj = new Hashtable(arg0,arg1);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types6, 1))
		{
			IDictionary arg0 = LuaScriptMgr.GetNetObject<IDictionary>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Hashtable obj = new Hashtable(arg0,arg1);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types7, 1))
		{
			IDictionary arg0 = LuaScriptMgr.GetNetObject<IDictionary>(L, 1);
			IEqualityComparer arg1 = LuaScriptMgr.GetNetObject<IEqualityComparer>(L, 2);
			Hashtable obj = new Hashtable(arg0,arg1);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types8, 1))
		{
			int arg0 = (int)LuaScriptMgr.GetNumber(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			IEqualityComparer arg2 = LuaScriptMgr.GetNetObject<IEqualityComparer>(L, 3);
			Hashtable obj = new Hashtable(arg0,arg1,arg2);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else if (count == 3 && LuaScriptMgr.CheckTypes(L, types9, 1))
		{
			IDictionary arg0 = LuaScriptMgr.GetNetObject<IDictionary>(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			IEqualityComparer arg2 = LuaScriptMgr.GetNetObject<IEqualityComparer>(L, 3);
			Hashtable obj = new Hashtable(arg0,arg1,arg2);
			LuaScriptMgr.PushObject(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Hashtable.New");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(Hashtable));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "System.Collections.Hashtable", typeof(Hashtable), regs, fields, "System.Object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Count(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Count");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Count on a nil value");
			}
		}

		Hashtable obj = (Hashtable)o;
		LuaScriptMgr.Push(L, obj.Count);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsSynchronized(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name IsSynchronized");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index IsSynchronized on a nil value");
			}
		}

		Hashtable obj = (Hashtable)o;
		LuaScriptMgr.Push(L, obj.IsSynchronized);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SyncRoot(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name SyncRoot");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index SyncRoot on a nil value");
			}
		}

		Hashtable obj = (Hashtable)o;
		LuaScriptMgr.PushVarObject(L, obj.SyncRoot);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsFixedSize(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name IsFixedSize");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index IsFixedSize on a nil value");
			}
		}

		Hashtable obj = (Hashtable)o;
		LuaScriptMgr.Push(L, obj.IsFixedSize);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsReadOnly(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name IsReadOnly");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index IsReadOnly on a nil value");
			}
		}

		Hashtable obj = (Hashtable)o;
		LuaScriptMgr.Push(L, obj.IsReadOnly);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Keys(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Keys");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Keys on a nil value");
			}
		}

		Hashtable obj = (Hashtable)o;
		LuaScriptMgr.PushObject(L, obj.Keys);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Values(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name Values");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index Values on a nil value");
			}
		}

		Hashtable obj = (Hashtable)o;
		LuaScriptMgr.PushObject(L, obj.Values);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Item(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Hashtable obj = LuaScriptMgr.GetNetObject<Hashtable>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		object o = obj[arg0];
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Item(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Hashtable obj = LuaScriptMgr.GetNetObject<Hashtable>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		object arg1 = LuaScriptMgr.GetVarObject(L, 3);
		obj[arg0] = arg1;
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CopyTo(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Hashtable obj = LuaScriptMgr.GetNetObject<Hashtable>(L, 1);
		Array arg0 = LuaScriptMgr.GetNetObject<Array>(L, 2);
		int arg1 = (int)LuaScriptMgr.GetNumber(L, 3);
		obj.CopyTo(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Add(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Hashtable obj = LuaScriptMgr.GetNetObject<Hashtable>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		object arg1 = LuaScriptMgr.GetVarObject(L, 3);
		obj.Add(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Clear(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Hashtable obj = LuaScriptMgr.GetNetObject<Hashtable>(L, 1);
		obj.Clear();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Contains(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Hashtable obj = LuaScriptMgr.GetNetObject<Hashtable>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.Contains(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetEnumerator(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Hashtable obj = LuaScriptMgr.GetNetObject<Hashtable>(L, 1);
		IDictionaryEnumerator o = obj.GetEnumerator();
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Remove(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Hashtable obj = LuaScriptMgr.GetNetObject<Hashtable>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		obj.Remove(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ContainsKey(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Hashtable obj = LuaScriptMgr.GetNetObject<Hashtable>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.ContainsKey(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ContainsValue(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Hashtable obj = LuaScriptMgr.GetNetObject<Hashtable>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.ContainsValue(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Clone(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Hashtable obj = LuaScriptMgr.GetNetObject<Hashtable>(L, 1);
		object o = obj.Clone();
		LuaScriptMgr.PushVarObject(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetObjectData(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Hashtable obj = LuaScriptMgr.GetNetObject<Hashtable>(L, 1);
		SerializationInfo arg0 = LuaScriptMgr.GetNetObject<SerializationInfo>(L, 2);
		StreamingContext arg1 = LuaScriptMgr.GetNetObject<StreamingContext>(L, 3);
		obj.GetObjectData(arg0,arg1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int OnDeserialization(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Hashtable obj = LuaScriptMgr.GetNetObject<Hashtable>(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		obj.OnDeserialization(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Synchronized(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Hashtable arg0 = LuaScriptMgr.GetNetObject<Hashtable>(L, 1);
		Hashtable o = Hashtable.Synchronized(arg0);
		LuaScriptMgr.PushObject(L, o);
		return 1;
	}
}


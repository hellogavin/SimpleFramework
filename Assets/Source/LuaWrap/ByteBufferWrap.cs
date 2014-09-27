using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class ByteBufferWrap : ILuaWrap
{
	public static LuaScriptMgr luaMgr = null;
	public static int reference = -1;

	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Close", Close),
		new LuaMethod("WriteByte", WriteByte),
		new LuaMethod("WriteInt", WriteInt),
		new LuaMethod("WriteShort", WriteShort),
		new LuaMethod("WriteLong", WriteLong),
		new LuaMethod("WriteFloat", WriteFloat),
		new LuaMethod("WriteDouble", WriteDouble),
		new LuaMethod("WriteString", WriteString),
		new LuaMethod("ReadByte", ReadByte),
		new LuaMethod("ReadInt", ReadInt),
		new LuaMethod("ReadShort", ReadShort),
		new LuaMethod("ReadLong", ReadLong),
		new LuaMethod("ReadFloat", ReadFloat),
		new LuaMethod("ReadDouble", ReadDouble),
		new LuaMethod("ReadString", ReadString),
		new LuaMethod("ToBytes", ToBytes),
		new LuaMethod("Flush", Flush),
		new LuaMethod("New", Create),
	};

	static LuaField[] fields = new LuaField[]
	{
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);
		object obj = null;

		if (count == 0)
		{
			obj = new ByteBuffer();
			luaMgr.PushResult(obj);
			return 1;
		}
		else if (count == 1)
		{
			byte[] objs0 = luaMgr.GetArrayNumber<byte>(1);
			obj = new ByteBuffer(objs0);
			luaMgr.PushResult(obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'ByteBuffer.New' has some invalid arguments");
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
		reference = luaMgr.RegisterLib("ByteBuffer", regs);
		luaMgr.CreateMetaTable("ByteBuffer", metas, typeof(ByteBuffer));
		luaMgr.RegisterField(typeof(ByteBuffer), fields);
	}

	public static bool TryLuaIndex(IntPtr l)
	{
		string str = luaMgr.GetString(2);

		if (luaMgr.Index(reference, str, fields))
		{
			return true;
		}

		return ByteBufferWrap.TryLuaIndex(l);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Index(IntPtr l)
	{
		if (TryLuaIndex(l))
		{
			return 1;
		}

		string str = luaMgr.GetString(2);
		LuaDLL.luaL_error(l, string.Format("'ByteBuffer' does not contain a definition for '{0}'", str));
		return 0;
	}

	public static bool TryLuaNewIndex(IntPtr l)
	{
		string str = luaMgr.GetString(2);

		if (luaMgr.NewIndex(reference, str, fields))
		{
			return true;
		}

		return ByteBufferWrap.TryLuaNewIndex(l);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_NewIndex(IntPtr l)
	{
		if (TryLuaNewIndex(l))
		{
			return 0;
		}

		string str = luaMgr.GetString(2);
		LuaDLL.luaL_error(l, string.Format("'ByteBuffer' does not contain a definition for '{0}'", str));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Close(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		ByteBuffer obj = (ByteBuffer)luaMgr.GetNetObject(1);
		obj.Close();
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WriteByte(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		ByteBuffer obj = (ByteBuffer)luaMgr.GetNetObject(1);
		int arg0 = (int)luaMgr.GetNumber(2);
		obj.WriteByte(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WriteInt(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		ByteBuffer obj = (ByteBuffer)luaMgr.GetNetObject(1);
		int arg0 = (int)luaMgr.GetNumber(2);
		obj.WriteInt(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WriteShort(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		ByteBuffer obj = (ByteBuffer)luaMgr.GetNetObject(1);
		ushort arg0 = (ushort)luaMgr.GetNumber(2);
		obj.WriteShort(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WriteLong(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		ByteBuffer obj = (ByteBuffer)luaMgr.GetNetObject(1);
		long arg0 = (long)luaMgr.GetNumber(2);
		obj.WriteLong(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WriteFloat(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		ByteBuffer obj = (ByteBuffer)luaMgr.GetNetObject(1);
		float arg0 = (float)luaMgr.GetNumber(2);
		obj.WriteFloat(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WriteDouble(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		ByteBuffer obj = (ByteBuffer)luaMgr.GetNetObject(1);
		double arg0 = (double)luaMgr.GetNumber(2);
		obj.WriteDouble(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int WriteString(IntPtr l)
	{
		luaMgr.CheckArgsCount(2);
		ByteBuffer obj = (ByteBuffer)luaMgr.GetNetObject(1);
		string arg0 = luaMgr.GetString(2);
		obj.WriteString(arg0);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReadByte(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		ByteBuffer obj = (ByteBuffer)luaMgr.GetNetObject(1);
		int o = obj.ReadByte();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReadInt(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		ByteBuffer obj = (ByteBuffer)luaMgr.GetNetObject(1);
		int o = obj.ReadInt();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReadShort(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		ByteBuffer obj = (ByteBuffer)luaMgr.GetNetObject(1);
		ushort o = obj.ReadShort();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReadLong(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		ByteBuffer obj = (ByteBuffer)luaMgr.GetNetObject(1);
		long o = obj.ReadLong();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReadFloat(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		ByteBuffer obj = (ByteBuffer)luaMgr.GetNetObject(1);
		float o = obj.ReadFloat();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReadDouble(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		ByteBuffer obj = (ByteBuffer)luaMgr.GetNetObject(1);
		double o = obj.ReadDouble();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ReadString(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		ByteBuffer obj = (ByteBuffer)luaMgr.GetNetObject(1);
		string o = obj.ReadString();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToBytes(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		ByteBuffer obj = (ByteBuffer)luaMgr.GetNetObject(1);
		byte[] o = obj.ToBytes();
		luaMgr.PushResult(o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Flush(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		ByteBuffer obj = (ByteBuffer)luaMgr.GetNetObject(1);
		obj.Flush();
		return 0;
	}
}


﻿using UnityEngine;
using System;
using LuaInterface;

public class Vector2Wrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Set", Set),
		new LuaMethod("Lerp", Lerp),
		new LuaMethod("MoveTowards", MoveTowards),
		new LuaMethod("Scale", Scale),
		new LuaMethod("Normalize", Normalize),
		new LuaMethod("ToString", ToString),
		new LuaMethod("GetHashCode", GetHashCode),
		new LuaMethod("Equals", Equals),
		new LuaMethod("Dot", Dot),
		new LuaMethod("Angle", Angle),
		new LuaMethod("Distance", Distance),
		new LuaMethod("ClampMagnitude", ClampMagnitude),
		new LuaMethod("SqrMagnitude", SqrMagnitude),
		new LuaMethod("Min", Min),
		new LuaMethod("Max", Max),
		new LuaMethod("New", Create),
		new LuaMethod("__tostring", Lua_ToString),
		new LuaMethod("__add", Lua_Add),
		new LuaMethod("__sub", Lua_Sub),
		new LuaMethod("__mul", Lua_Mul),
		new LuaMethod("__div", Lua_Div),
		new LuaMethod("__eq", Lua_Eq),
		new LuaMethod("__unm", Lua_Neg),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("kEpsilon", get_kEpsilon, null),
		new LuaField("x", get_x, set_x),
		new LuaField("y", get_y, set_y),
		new LuaField("normalized", get_normalized, null),
		new LuaField("magnitude", get_magnitude, null),
		new LuaField("sqrMagnitude", get_sqrMagnitude, null),
		new LuaField("zero", get_zero, null),
		new LuaField("one", get_one, null),
		new LuaField("up", get_up, null),
		new LuaField("right", get_right, null),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		object obj = null;

		if (count == 2)
		{
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			obj = new Vector2(arg0,arg1);
			LuaScriptMgr.PushResult(L, obj);
			return 1;
		}
		else if (count == 0)
		{
			obj = new Vector2();
			LuaScriptMgr.PushResult(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Vector2.New");
		}

		return 0;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "Vector2", typeof(Vector2), regs, fields, "object");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_kEpsilon(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, Vector2.kEpsilon);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_x(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name x");
		}

		Vector2 obj = (Vector2)o;
		LuaScriptMgr.PushResult(L, obj.x);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_y(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name y");
		}

		Vector2 obj = (Vector2)o;
		LuaScriptMgr.PushResult(L, obj.y);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_normalized(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name normalized");
		}

		Vector2 obj = (Vector2)o;
		LuaScriptMgr.PushResult(L, obj.normalized);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_magnitude(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name magnitude");
		}

		Vector2 obj = (Vector2)o;
		LuaScriptMgr.PushResult(L, obj.magnitude);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_sqrMagnitude(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name sqrMagnitude");
		}

		Vector2 obj = (Vector2)o;
		LuaScriptMgr.PushResult(L, obj.sqrMagnitude);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_zero(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, Vector2.zero);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_one(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, Vector2.one);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_up(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, Vector2.up);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_right(IntPtr L)
	{
		LuaScriptMgr.PushResult(L, Vector2.right);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_x(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name x");
		}

		Vector2 obj = (Vector2)o;
		obj.x = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_y(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name y");
		}

		Vector2 obj = (Vector2)o;
		obj.y = (float)LuaScriptMgr.GetNumber(L, 3);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_ToString(IntPtr L)
	{
		Vector2 obj = (Vector2)LuaScriptMgr.GetNetObject(L, 1);
		LuaScriptMgr.PushResult(L, obj.ToString());
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Set(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Vector2 obj = (Vector2)LuaScriptMgr.GetNetObject(L, 1);
		float arg0 = (float)LuaScriptMgr.GetNumber(L, 2);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 3);
		obj.Set(arg0,arg1);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lerp(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Vector2 arg0 = (Vector2)LuaScriptMgr.GetNetObject(L, 1);
		Vector2 arg1 = (Vector2)LuaScriptMgr.GetNetObject(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		Vector2 o = Vector2.Lerp(arg0,arg1,arg2);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int MoveTowards(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 3);
		Vector2 arg0 = (Vector2)LuaScriptMgr.GetNetObject(L, 1);
		Vector2 arg1 = (Vector2)LuaScriptMgr.GetNetObject(L, 2);
		float arg2 = (float)LuaScriptMgr.GetNumber(L, 3);
		Vector2 o = Vector2.MoveTowards(arg0,arg1,arg2);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Scale(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector2 obj = (Vector2)LuaScriptMgr.GetNetObject(L, 1);
		Vector2 arg0 = (Vector2)LuaScriptMgr.GetNetObject(L, 2);
		obj.Scale(arg0);
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Normalize(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Vector2 obj = (Vector2)LuaScriptMgr.GetNetObject(L, 1);
		obj.Normalize();
		LuaScriptMgr.SetValueObject(L, 1, obj);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ToString(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		if (count == 1)
		{
			Vector2 obj = (Vector2)LuaScriptMgr.GetNetObject(L, 1);
			string o = obj.ToString();
			LuaScriptMgr.PushResult(L, o);
			return 1;
		}
		else if (count == 2)
		{
			Vector2 obj = (Vector2)LuaScriptMgr.GetNetObject(L, 1);
			string arg0 = LuaScriptMgr.GetLuaString(L, 2);
			string o = obj.ToString(arg0);
			LuaScriptMgr.PushResult(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Vector2.ToString");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetHashCode(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Vector2 obj = (Vector2)LuaScriptMgr.GetNetObject(L, 1);
		int o = obj.GetHashCode();
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Equals(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector2 obj = (Vector2)LuaScriptMgr.GetNetObject(L, 1);
		object arg0 = LuaScriptMgr.GetVarObject(L, 2);
		bool o = obj.Equals(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Dot(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector2 arg0 = (Vector2)LuaScriptMgr.GetNetObject(L, 1);
		Vector2 arg1 = (Vector2)LuaScriptMgr.GetNetObject(L, 2);
		float o = Vector2.Dot(arg0,arg1);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Angle(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector2 arg0 = (Vector2)LuaScriptMgr.GetNetObject(L, 1);
		Vector2 arg1 = (Vector2)LuaScriptMgr.GetNetObject(L, 2);
		float o = Vector2.Angle(arg0,arg1);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Distance(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector2 arg0 = (Vector2)LuaScriptMgr.GetNetObject(L, 1);
		Vector2 arg1 = (Vector2)LuaScriptMgr.GetNetObject(L, 2);
		float o = Vector2.Distance(arg0,arg1);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ClampMagnitude(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector2 arg0 = (Vector2)LuaScriptMgr.GetNetObject(L, 1);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
		Vector2 o = Vector2.ClampMagnitude(arg0,arg1);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SqrMagnitude(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Vector2 obj = (Vector2)LuaScriptMgr.GetNetObject(L, 1);
		float o = obj.SqrMagnitude();
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Min(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector2 arg0 = (Vector2)LuaScriptMgr.GetNetObject(L, 1);
		Vector2 arg1 = (Vector2)LuaScriptMgr.GetNetObject(L, 2);
		Vector2 o = Vector2.Min(arg0,arg1);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Max(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector2 arg0 = (Vector2)LuaScriptMgr.GetNetObject(L, 1);
		Vector2 arg1 = (Vector2)LuaScriptMgr.GetNetObject(L, 2);
		Vector2 o = Vector2.Max(arg0,arg1);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Add(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector2 arg0 = (Vector2)LuaScriptMgr.GetNetObject(L, 1);
		Vector2 arg1 = (Vector2)LuaScriptMgr.GetNetObject(L, 2);
		Vector2 o = arg0 + arg1;
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Sub(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector2 arg0 = (Vector2)LuaScriptMgr.GetNetObject(L, 1);
		Vector2 arg1 = (Vector2)LuaScriptMgr.GetNetObject(L, 2);
		Vector2 o = arg0 - arg1;
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Neg(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		Vector2 arg0 = (Vector2)LuaScriptMgr.GetNetObject(L, 1);
		Vector2 o = -arg0;
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Mul(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);

		Type[] types0 = {typeof(float), typeof(Vector2)};
		Type[] types1 = {typeof(Vector2), typeof(float)};

		if (count == 2 && LuaScriptMgr.CheckTypes(L, types0, 1))
		{
			float arg0 = (float)LuaScriptMgr.GetNumber(L, 1);
			Vector2 arg1 = (Vector2)LuaScriptMgr.GetNetObject(L, 2);
			Vector2 o = arg0 * arg1;
			LuaScriptMgr.PushResult(L, o);
			return 1;
		}
		else if (count == 2 && LuaScriptMgr.CheckTypes(L, types1, 1))
		{
			Vector2 arg0 = (Vector2)LuaScriptMgr.GetNetObject(L, 1);
			float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
			Vector2 o = arg0 * arg1;
			LuaScriptMgr.PushResult(L, o);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: Vector2.op_Multiply");
		}

		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Div(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector2 arg0 = (Vector2)LuaScriptMgr.GetNetObject(L, 1);
		float arg1 = (float)LuaScriptMgr.GetNumber(L, 2);
		Vector2 o = arg0 / arg1;
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Eq(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 2);
		Vector2 arg0 = (Vector2)LuaScriptMgr.GetNetObject(L, 1);
		Vector2 arg1 = (Vector2)LuaScriptMgr.GetNetObject(L, 2);
		bool o = arg0 == arg1;
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}
}


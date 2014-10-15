using System;
using UnityEngine;
using LuaInterface;

public class UIEventListenerWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Get", Get),
		new LuaMethod("New", Create),
	};

	static LuaField[] fields = new LuaField[]
	{
		new LuaField("parameter", get_parameter, set_parameter),
		new LuaField("onSubmit", get_onSubmit, set_onSubmit),
		new LuaField("onClick", get_onClick, set_onClick),
		new LuaField("onDoubleClick", get_onDoubleClick, set_onDoubleClick),
		new LuaField("onHover", get_onHover, set_onHover),
		new LuaField("onPress", get_onPress, set_onPress),
		new LuaField("onSelect", get_onSelect, set_onSelect),
		new LuaField("onScroll", get_onScroll, set_onScroll),
		new LuaField("onDragStart", get_onDragStart, set_onDragStart),
		new LuaField("onDrag", get_onDrag, set_onDrag),
		new LuaField("onDragOver", get_onDragOver, set_onDragOver),
		new LuaField("onDragOut", get_onDragOut, set_onDragOut),
		new LuaField("onDragEnd", get_onDragEnd, set_onDragEnd),
		new LuaField("onDrop", get_onDrop, set_onDrop),
		new LuaField("onKey", get_onKey, set_onKey),
		new LuaField("onTooltip", get_onTooltip, set_onTooltip),
	};

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Create(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		object obj = null;

		if (count == 0)
		{
			obj = new UIEventListener();
			LuaScriptMgr.PushResult(L, obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(L, "invalid arguments to method: UIEventListener.New");
		}

		return 0;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UIEventListener", typeof(UIEventListener), regs, fields, "UIEventListener");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_parameter(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name parameter");
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushResult(L, obj.parameter);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onSubmit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onSubmit");
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushResult(L, obj.onSubmit);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onClick(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onClick");
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushResult(L, obj.onClick);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onDoubleClick(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onDoubleClick");
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushResult(L, obj.onDoubleClick);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onHover(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onHover");
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushResult(L, obj.onHover);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onPress(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onPress");
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushResult(L, obj.onPress);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onSelect(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onSelect");
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushResult(L, obj.onSelect);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onScroll(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onScroll");
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushResult(L, obj.onScroll);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onDragStart(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onDragStart");
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushResult(L, obj.onDragStart);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onDrag(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onDrag");
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushResult(L, obj.onDrag);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onDragOver(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onDragOver");
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushResult(L, obj.onDragOver);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onDragOut(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onDragOut");
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushResult(L, obj.onDragOut);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onDragEnd(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onDragEnd");
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushResult(L, obj.onDragEnd);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onDrop(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onDrop");
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushResult(L, obj.onDrop);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onKey(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onKey");
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushResult(L, obj.onKey);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onTooltip(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onTooltip");
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushResult(L, obj.onTooltip);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_parameter(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name parameter");
		}

		UIEventListener obj = (UIEventListener)o;
		obj.parameter = LuaScriptMgr.GetVarObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onSubmit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onSubmit");
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onSubmit = (UIEventListener.VoidDelegate)LuaScriptMgr.GetNetObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onClick(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onClick");
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onClick = (UIEventListener.VoidDelegate)LuaScriptMgr.GetNetObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onDoubleClick(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onDoubleClick");
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onDoubleClick = (UIEventListener.VoidDelegate)LuaScriptMgr.GetNetObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onHover(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onHover");
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onHover = (UIEventListener.BoolDelegate)LuaScriptMgr.GetNetObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onPress(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onPress");
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onPress = (UIEventListener.BoolDelegate)LuaScriptMgr.GetNetObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onSelect(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onSelect");
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onSelect = (UIEventListener.BoolDelegate)LuaScriptMgr.GetNetObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onScroll(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onScroll");
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onScroll = (UIEventListener.FloatDelegate)LuaScriptMgr.GetNetObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onDragStart(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onDragStart");
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onDragStart = (UIEventListener.VoidDelegate)LuaScriptMgr.GetNetObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onDrag(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onDrag");
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onDrag = (UIEventListener.VectorDelegate)LuaScriptMgr.GetNetObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onDragOver(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onDragOver");
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onDragOver = (UIEventListener.VoidDelegate)LuaScriptMgr.GetNetObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onDragOut(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onDragOut");
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onDragOut = (UIEventListener.VoidDelegate)LuaScriptMgr.GetNetObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onDragEnd(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onDragEnd");
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onDragEnd = (UIEventListener.VoidDelegate)LuaScriptMgr.GetNetObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onDrop(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onDrop");
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onDrop = (UIEventListener.ObjectDelegate)LuaScriptMgr.GetNetObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onKey(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onKey");
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onKey = (UIEventListener.KeyCodeDelegate)LuaScriptMgr.GetNetObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onTooltip(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaDLL.luaL_error(L, "unknown member name onTooltip");
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onTooltip = (UIEventListener.BoolDelegate)LuaScriptMgr.GetNetObject(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Get(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		GameObject arg0 = (GameObject)LuaScriptMgr.GetNetObject(L, 1);
		UIEventListener o = UIEventListener.Get(arg0);
		LuaScriptMgr.PushResult(L, o);
		return 1;
	}
}


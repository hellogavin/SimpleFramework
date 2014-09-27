using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class UIEventListenerWrap : ILuaWrap
{
	public static LuaScriptMgr luaMgr = null;
	public static int reference = -1;

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
	static int Create(IntPtr l)
	{
		int count = LuaDLL.lua_gettop(l);
		object obj = null;

		if (count == 0)
		{
			obj = new UIEventListener();
			luaMgr.PushResult(obj);
			return 1;
		}
		else
		{
			LuaDLL.luaL_error(l, "The best overloaded method match for 'UIEventListener.New' has some invalid arguments");
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
		reference = luaMgr.RegisterLib("UIEventListener", regs);
		luaMgr.CreateMetaTable("UIEventListener", metas, typeof(UIEventListener));
		luaMgr.RegisterField(typeof(UIEventListener), fields);
	}

	static bool get_parameter(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		luaMgr.PushResult(obj.parameter);
		return true;
	}

	static bool get_onSubmit(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		luaMgr.PushResult(obj.onSubmit);
		return true;
	}

	static bool get_onClick(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		luaMgr.PushResult(obj.onClick);
		return true;
	}

	static bool get_onDoubleClick(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		luaMgr.PushResult(obj.onDoubleClick);
		return true;
	}

	static bool get_onHover(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		luaMgr.PushResult(obj.onHover);
		return true;
	}

	static bool get_onPress(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		luaMgr.PushResult(obj.onPress);
		return true;
	}

	static bool get_onSelect(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		luaMgr.PushResult(obj.onSelect);
		return true;
	}

	static bool get_onScroll(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		luaMgr.PushResult(obj.onScroll);
		return true;
	}

	static bool get_onDragStart(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		luaMgr.PushResult(obj.onDragStart);
		return true;
	}

	static bool get_onDrag(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		luaMgr.PushResult(obj.onDrag);
		return true;
	}

	static bool get_onDragOver(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		luaMgr.PushResult(obj.onDragOver);
		return true;
	}

	static bool get_onDragOut(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		luaMgr.PushResult(obj.onDragOut);
		return true;
	}

	static bool get_onDragEnd(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		luaMgr.PushResult(obj.onDragEnd);
		return true;
	}

	static bool get_onDrop(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		luaMgr.PushResult(obj.onDrop);
		return true;
	}

	static bool get_onKey(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		luaMgr.PushResult(obj.onKey);
		return true;
	}

	static bool get_onTooltip(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		luaMgr.PushResult(obj.onTooltip);
		return true;
	}

	public static bool TryLuaIndex(IntPtr l)
	{
		string str = luaMgr.GetString(2);

		if (luaMgr.Index(reference, str, fields))
		{
			return true;
		}

		return UIEventListenerWrap.TryLuaIndex(l);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_Index(IntPtr l)
	{
		if (TryLuaIndex(l))
		{
			return 1;
		}

		string str = luaMgr.GetString(2);
		LuaDLL.luaL_error(l, string.Format("'UIEventListener' does not contain a definition for '{0}'", str));
		return 0;
	}

	static bool set_parameter(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		obj.parameter = (object)luaMgr.GetNetObject(3);
		return true;
	}

	static bool set_onSubmit(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		obj.onSubmit = (UIEventListener.VoidDelegate)luaMgr.GetNetObject(3);
		return true;
	}

	static bool set_onClick(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		obj.onClick = (UIEventListener.VoidDelegate)luaMgr.GetNetObject(3);
		return true;
	}

	static bool set_onDoubleClick(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		obj.onDoubleClick = (UIEventListener.VoidDelegate)luaMgr.GetNetObject(3);
		return true;
	}

	static bool set_onHover(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		obj.onHover = (UIEventListener.BoolDelegate)luaMgr.GetNetObject(3);
		return true;
	}

	static bool set_onPress(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		obj.onPress = (UIEventListener.BoolDelegate)luaMgr.GetNetObject(3);
		return true;
	}

	static bool set_onSelect(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		obj.onSelect = (UIEventListener.BoolDelegate)luaMgr.GetNetObject(3);
		return true;
	}

	static bool set_onScroll(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		obj.onScroll = (UIEventListener.FloatDelegate)luaMgr.GetNetObject(3);
		return true;
	}

	static bool set_onDragStart(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		obj.onDragStart = (UIEventListener.VoidDelegate)luaMgr.GetNetObject(3);
		return true;
	}

	static bool set_onDrag(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		obj.onDrag = (UIEventListener.VectorDelegate)luaMgr.GetNetObject(3);
		return true;
	}

	static bool set_onDragOver(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		obj.onDragOver = (UIEventListener.VoidDelegate)luaMgr.GetNetObject(3);
		return true;
	}

	static bool set_onDragOut(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		obj.onDragOut = (UIEventListener.VoidDelegate)luaMgr.GetNetObject(3);
		return true;
	}

	static bool set_onDragEnd(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		obj.onDragEnd = (UIEventListener.VoidDelegate)luaMgr.GetNetObject(3);
		return true;
	}

	static bool set_onDrop(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		obj.onDrop = (UIEventListener.ObjectDelegate)luaMgr.GetNetObject(3);
		return true;
	}

	static bool set_onKey(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		obj.onKey = (UIEventListener.KeyCodeDelegate)luaMgr.GetNetObject(3);
		return true;
	}

	static bool set_onTooltip(IntPtr l)
	{
		object o = luaMgr.GetLuaObject(1);
		if (o == null) return false;
		UIEventListener obj = (UIEventListener)o;
		obj.onTooltip = (UIEventListener.BoolDelegate)luaMgr.GetNetObject(3);
		return true;
	}

	public static bool TryLuaNewIndex(IntPtr l)
	{
		string str = luaMgr.GetString(2);

		if (luaMgr.NewIndex(reference, str, fields))
		{
			return true;
		}

		return UIEventListenerWrap.TryLuaNewIndex(l);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Lua_NewIndex(IntPtr l)
	{
		if (TryLuaNewIndex(l))
		{
			return 0;
		}

		string str = luaMgr.GetString(2);
		LuaDLL.luaL_error(l, string.Format("'UIEventListener' does not contain a definition for '{0}'", str));
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Get(IntPtr l)
	{
		luaMgr.CheckArgsCount(1);
		GameObject arg0 = (GameObject)luaMgr.GetNetObject(1);
		UIEventListener o = UIEventListener.Get(arg0);
		luaMgr.PushResult(o);
		return 1;
	}
}


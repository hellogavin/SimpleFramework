﻿using System;
using UnityEngine;
using LuaInterface;
using Object = UnityEngine.Object;

public class UIEventListenerWrap
{
	public static LuaMethod[] regs = new LuaMethod[]
	{
		new LuaMethod("Get", Get),
		new LuaMethod("New", _CreateUIEventListener),
		new LuaMethod("GetClassType", GetClassType),
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
	static int _CreateUIEventListener(IntPtr L)
	{
		LuaDLL.luaL_error(L, "UIEventListener class does not have a constructor function");
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, typeof(UIEventListener));
		return 1;
	}

	public static void Register(IntPtr L)
	{
		LuaScriptMgr.RegisterLib(L, "UIEventListener", typeof(UIEventListener), regs, fields, "UnityEngine.MonoBehaviour");
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_parameter(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name parameter");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index parameter on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushVarObject(L, obj.parameter);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onSubmit(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onSubmit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onSubmit on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushObject(L, obj.onSubmit);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onClick(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onClick");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onClick on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushObject(L, obj.onClick);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onDoubleClick(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onDoubleClick");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onDoubleClick on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushObject(L, obj.onDoubleClick);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onHover(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onHover");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onHover on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushObject(L, obj.onHover);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onPress(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onPress");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onPress on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushObject(L, obj.onPress);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onSelect(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onSelect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onSelect on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushObject(L, obj.onSelect);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onScroll(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onScroll");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onScroll on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushObject(L, obj.onScroll);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onDragStart(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onDragStart");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onDragStart on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushObject(L, obj.onDragStart);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onDrag(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onDrag");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onDrag on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushObject(L, obj.onDrag);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onDragOver(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onDragOver");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onDragOver on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushObject(L, obj.onDragOver);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onDragOut(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onDragOut");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onDragOut on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushObject(L, obj.onDragOut);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onDragEnd(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onDragEnd");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onDragEnd on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushObject(L, obj.onDragEnd);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onDrop(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onDrop");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onDrop on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushObject(L, obj.onDrop);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onKey(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onKey");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onKey on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushObject(L, obj.onKey);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_onTooltip(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onTooltip");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onTooltip on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		LuaScriptMgr.PushObject(L, obj.onTooltip);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_parameter(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name parameter");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index parameter on a nil value");
			}
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
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onSubmit");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onSubmit on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onSubmit = LuaScriptMgr.GetNetObject<UIEventListener.VoidDelegate>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onClick(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onClick");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onClick on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onClick = LuaScriptMgr.GetNetObject<UIEventListener.VoidDelegate>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onDoubleClick(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onDoubleClick");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onDoubleClick on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onDoubleClick = LuaScriptMgr.GetNetObject<UIEventListener.VoidDelegate>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onHover(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onHover");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onHover on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onHover = LuaScriptMgr.GetNetObject<UIEventListener.BoolDelegate>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onPress(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onPress");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onPress on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onPress = LuaScriptMgr.GetNetObject<UIEventListener.BoolDelegate>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onSelect(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onSelect");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onSelect on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onSelect = LuaScriptMgr.GetNetObject<UIEventListener.BoolDelegate>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onScroll(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onScroll");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onScroll on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onScroll = LuaScriptMgr.GetNetObject<UIEventListener.FloatDelegate>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onDragStart(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onDragStart");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onDragStart on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onDragStart = LuaScriptMgr.GetNetObject<UIEventListener.VoidDelegate>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onDrag(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onDrag");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onDrag on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onDrag = LuaScriptMgr.GetNetObject<UIEventListener.VectorDelegate>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onDragOver(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onDragOver");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onDragOver on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onDragOver = LuaScriptMgr.GetNetObject<UIEventListener.VoidDelegate>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onDragOut(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onDragOut");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onDragOut on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onDragOut = LuaScriptMgr.GetNetObject<UIEventListener.VoidDelegate>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onDragEnd(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onDragEnd");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onDragEnd on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onDragEnd = LuaScriptMgr.GetNetObject<UIEventListener.VoidDelegate>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onDrop(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onDrop");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onDrop on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onDrop = LuaScriptMgr.GetNetObject<UIEventListener.ObjectDelegate>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onKey(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onKey");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onKey on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onKey = LuaScriptMgr.GetNetObject<UIEventListener.KeyCodeDelegate>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_onTooltip(IntPtr L)
	{
		object o = LuaScriptMgr.GetLuaObject(L, 1);

		if (o == null)
		{
			LuaTypes types = LuaDLL.lua_type(L, 1);

			if (types == LuaTypes.LUA_TTABLE)
			{
				LuaDLL.luaL_error(L, "unknown member name onTooltip");
			}
			else
			{
				LuaDLL.luaL_error(L, "attempt to index onTooltip on a nil value");
			}
		}

		UIEventListener obj = (UIEventListener)o;
		obj.onTooltip = LuaScriptMgr.GetNetObject<UIEventListener.BoolDelegate>(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Get(IntPtr L)
	{
		LuaScriptMgr.CheckArgsCount(L, 1);
		GameObject arg0 = LuaScriptMgr.GetNetObject<GameObject>(L, 1);
		UIEventListener o = UIEventListener.Get(arg0);
		LuaScriptMgr.Push(L, o);
		return 1;
	}
}


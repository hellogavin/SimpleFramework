using System;

public static class LuaBinder
{
	public static void Bind(IntPtr L)
	{
		objectWrap.Register(L);
		ObjectWrap.Register(L);
		ApplicationWrap.Register(L);
		BaseLuaWrap.Register(L);
		BehaviourWrap.Register(L);
		ByteBufferWrap.Register(L);
		ComponentWrap.Register(L);
		ConstWrap.Register(L);
		GameObjectWrap.Register(L);
		GlobalWrap.Register(L);
		HashtableWrap.Register(L);
		iooWrap.Register(L);
		LuaHelperWrap.Register(L);
		MonoBehaviourWrap.Register(L);
		NetworkManagerWrap.Register(L);
		PanelManagerWrap.Register(L);
		ResourceManagerWrap.Register(L);
		TimerManagerWrap.Register(L);
		TimeWrap.Register(L);
		TransformWrap.Register(L);
		TypeWrap.Register(L);
		UIEventListenerWrap.Register(L);
		UtilWrap.Register(L);
		Vector2Wrap.Register(L);
		Vector3Wrap.Register(L);
	}
}

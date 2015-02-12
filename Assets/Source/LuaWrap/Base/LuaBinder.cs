using System;
public static class LuaBinder
{
	public static void Bind(IntPtr L)
	{
		objectWrap.Register(L);
		ObjectWrap.Register(L);
		coroutineWrap.Register(L);
		iooWrap.Register(L);
		UtilWrap.Register(L);
		ConstWrap.Register(L);
		GlobalWrap.Register(L);
		ByteBufferWrap.Register(L);
		NetworkManagerWrap.Register(L);
		ResourceManagerWrap.Register(L);
		PanelManagerWrap.Register(L);
		UIEventListenerWrap.Register(L);
		TimerManagerWrap.Register(L);
		LuaHelperWrap.Register(L);
		HashtableWrap.Register(L);
		Vector2Wrap.Register(L);
		Vector3Wrap.Register(L);
		BaseLuaWrap.Register(L);
		GameObjectWrap.Register(L);
		TransformWrap.Register(L);
		TypeWrap.Register(L);
		ComponentWrap.Register(L);
		BehaviourWrap.Register(L);
		MonoBehaviourWrap.Register(L);
		TimeWrap.Register(L);
		ApplicationWrap.Register(L);
	}
}

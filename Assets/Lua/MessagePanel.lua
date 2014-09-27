module("MessagePanel", package.seeall)

require "functions"

local gameObject;

--启动事件--发送登录请求--
function Start()
	gameObject = find("MessagePanel");
	warn("Start lua--->>"..gameObject.name);

	local panel = gameObject:GetComponent('UIPanel');
	panel.depth = 10;	--设置纵深--

	local Button = find('Button');
	UIEventListener.Get(Button).onClick = LuaHelper.VoidDelegate(OnClick);
end

--单击事件--
function OnClick()
	destroy(gameObject);
end
module("BackupPanel", package.seeall)

local gameObject;

--启动事件--
function Start()
	gameObject = find("BackupPanel");
	warn("Start lua--->>"..gameObject.name);

	local button = find("Button");
	UIEventListener.Get(button).onClick = LuaHelper.VoidDelegate(OnClick);
end

--单击事件--
function OnClick()
	warn("OnClick---->>>"..gameObject.name);
	--ioo.panelManager:CreatePanel("Backup"); --Lua里创建面板
end
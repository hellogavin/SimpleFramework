local gameObject;

--启动事件--发送登录请求--
function Start()
	local button = find("Button");
	Util.AddClick(button, OnClick);
	
	gameObject = find("BackupPanel");
	warn("Start lua--->>"..gameObject.name);
end

--单击事件--
function OnClick()
	error("OnClick---->>>"..gameObject.name);
	--ioo.panelManager:CreatePanel("Backup"); --Lua里创建面板
end
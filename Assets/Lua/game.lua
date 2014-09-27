module("GameManager", package.seeall)

require "define"
require "functions"

--管理器--
local game;	

function LuaPanel()
	return 'Backup', 'Login';
end

function Awake()
    --warn('Awake--->>>');
end

--启动事件--
function Start()
	--warn('Start--->>>');
end

--初始化完成--
function OnInitOK()
	warn('OnInitOK--->>>');
	io.panelManager:CreatePanel("Backup");
end

--销毁--
function OnDestroy()
	--warn('OnDestroy--->>>');
end

module("GameManager", package.seeall)

require "functions"

--管理器--
local game;	

function LuaScriptPanel()
	return 'Prompt', 'Message';
end

function Awake()
    --warn('Awake--->>>');
end

--启动事件--
function Start()
	--warn('Start--->>>');
end

--初始化完成，发送链接服务器信息--
function OnInitOK()
	warn('OnInitOK--->>>');
	createPanel("Prompt");

    Const.SocketPort = 2012;
    Const.SocketAddress = "127.0.0.1";
    io.networkManager:SendConnect();
end

--销毁--
function OnDestroy()
	--warn('OnDestroy--->>>');
end

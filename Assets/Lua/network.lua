module("network", package.seeall)

require "protocal"

local islogging = false;

--Socket消息--
function OnSocket(key, buffer)
	if key == Connect then OnConnect(); end
	if key == Exception then OnException(); end
	if key == Disconnect then OnDisconnect(); end
	---------------------------------------------
	if key == Login then OnLogin(buffer); end
	--ModuleName.function--
end

--当连接建立时--
function OnConnect() 
    warn("Game Server connected!!");
end

--异常断线--
function OnException() 
    islogging = false; 
    io.networkManager:SendConnect();
   	error("OnException------->>>>");
end

--连接中断，或者被踢掉--
function OnDisconnect() 
    islogging = false; 
    error("OnDisconnect------->>>>");
end

--当登录时--
function OnLogin(buffer) 
    local result = buffer:ReadByte();
    if result == 0 then return; end
    islogging = true;
    local str = buffer:ReadString();
    warn('OnLogin---->>>'..str);
    createPanel("Message"); --Lua里创建面板
end


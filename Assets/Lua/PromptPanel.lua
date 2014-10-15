module("PromptPanel", package.seeall)

require "functions"

local panel;
local trans;
local prompt;
local gameObject;

--启动事件--
function Start()
	gameObject = find("PromptPanel");
	prompt = gameObject:GetComponent('BaseLua');

	trans = gameObject.transform;
	panel = gameObject:GetComponent('UIPanel');
	warn("Start lua--->>"..gameObject.name);

	local Open = find('Open');
	UIEventListener.Get(Open).onClick = LuaHelper.VoidDelegate(OnClick);

	InitPanel();	--初始化面板--
end

--初始化面板--
function InitPanel()
	panel.depth = 1;	--设置纵深--
	local parent = trans:Find('ScrollView/Grid');
	local itemPrefab = prompt:GetGameObject('PromptItem');
	for i = 1, 100 do
		local go = newobject(itemPrefab);
		go.name = tostring(i);
		go.transform.parent = parent;
		go.transform.localScale = Vector3.one;
		go.transform.localPosition = Vector3.zero;

		local goo = go.transform:FindChild('Label');
		goo:GetComponent('UILabel').text = i;
	end
	local grid = parent:GetComponent('UIGrid');
	grid:Reposition();
	grid.repositionNow = true;
	parent:GetComponent('UIWrapGrid'):InitGrid();
end

--单击事件--
function OnClick()
    local buffer = ByteBuffer.New();
    buffer:WriteShort(Login);
    buffer:WriteString("ffff我的ffffQ靈uuu");
    buffer:WriteInt(200);
    io.networkManager:SendMessage(buffer);
	warn("OnClick---->>>"..gameObject.name);
end
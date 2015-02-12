本工程基于Unity 4.6.0 + NGUI3.7.1 + uLua 1.0.3 + toluac# 2.03构建

//-------------2014-11-29---------------
(1)集成tolua c# 2.03版本
(2)增加了Class.lua自定义类
(3)修改了tolua c#中生成自定义类与U3D类合并函数

//-------------2014-10-10---------------
(1)集成tolua c# 1.2版本

//-------------2014-09-27---------------
(1)添加了一个基于supersocket的服务器端框架。
(2)集成了网络模块，并且通过lua发送消息给，返回echo流程已完成。
服务器框架程序:SimpleFramework\Server\Server\bin\Debug\SuperSocket.SocketService.exe
服务器配置文件:同上目录\SuperSocket.SocketService.exe.config
PS:运行服务器程序，需要.Net(windows)/Mono(linux) 4.0以上版本

//-------------2014-09-26---------------
(1)集成了UIWrapGrid.cs，100个滚动列表项不卡（亲测2000不卡）。
(2)因同学需求，添加了弹出面板。

//-------------2014-09-25---------------
(1)集成了阿萌的tolua c#版插件.
(2)集成了UnityVS调试插件


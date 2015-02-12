using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Const {   
    public static bool DebugMode = false;                        //调试模式-用于内部测试

    public static int TimerInterval = 1;
    public static int GameFrameRate = 30;                       //游戏帧频

    public static TextAsset[] luaScripts;                       //Lua公共脚本

    public static string UserId = string.Empty;                 //用户ID
    public static string AppName = "GameApp";                   //应用程序名称
    public static string AppPrefix = AppName + "_";             //应用程序前缀
    public static string ResDirectory = "game/";                //资源目录

    public static string WebUrl = string.Empty; 
    public static string SocketAddress = string.Empty;          //Socket服务器地址
    public static int SocketPort = 0;                           //Socket服务器端口

    public static string uid = string.Empty;
    public static string sid = string.Empty;
}

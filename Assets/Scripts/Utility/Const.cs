using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Const {   
    public static bool DebugMode = false;                       //����ģʽ-�����ڲ�����

    public static int TimerInterval = 1;
    public static int GameFrameRate = 30;                       //��Ϸ֡Ƶ

    public static TextAsset[] luaScripts;                       //Lua�����ű�

    public static string UserId = string.Empty;                 //�û�ID
    public static string AppName = "simpleframework";           //Ӧ�ó�������
    public static string AppPrefix = AppName + "_";             //Ӧ�ó���ǰ׺

    public static string WebUrl = string.Empty;
    public static int SocketPort = 0;                           //Socket�������˿�
    public static string SocketAddress = string.Empty;          //Socket��������ַ
}

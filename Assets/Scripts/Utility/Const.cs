using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Const {   
    public static bool BetaMode = false;                        //���ģʽ-���ڱ�ʾ֧��
    public static bool DebugMode = true;                        //����ģʽ-�����ڲ�����
    public static bool InnerNetMode = true;                     //����ģʽ-ʹ������ģʽ

    public static int TimerInterval = 1;

    public static TextAsset[] luaScripts;                       //Lua�����ű�

    public static string UserId = string.Empty;                 //�û�ID
    public static string AppName = "GameApp";                   //Ӧ�ó�������
    public static string AppPrefix = AppName + "_";             //Ӧ�ó���ǰ׺
    public static string ResDirectory = "game/";                //��ԴĿ¼
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Global {
    public static Hashtable ShareVars = new Hashtable();        //Lua�������

    /// <summary>
    /// ��ӱ���
    /// </summary>
    public static void AddValue(string name, string value) {
        ShareVars.Add(name, value);
    }

    /// <summary>
    /// ��ȡ����
    /// </summary>
    public static object GetValue(string name) {
        return ShareVars[name];
    }

    /// <summary>
    /// �Ƴ�����
    /// </summary>
    public static void RemoveValue(string name) {
        ShareVars.Remove(name);
    }

    /// <summary>
    /// �������
    /// </summary>
    public static void ClearShareVars() {
        ShareVars.Clear();
    }
}

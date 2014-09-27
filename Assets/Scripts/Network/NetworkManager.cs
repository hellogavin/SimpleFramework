using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;

public class NetworkManager : BaseLua {
    private int count;
    private TimerInfo timer;
    private bool islogging = false;
    private static Queue<KeyValuePair<int, ByteBuffer>> sEvents = new Queue<KeyValuePair<int, ByteBuffer>>();

    new void Start() {
        base.Start();
    }

    ///------------------------------------------------------------------------------------
    public static void AddEvent(int _event, ByteBuffer data) {
        sEvents.Enqueue(new KeyValuePair<int, ByteBuffer>(_event, data));
    }

    void Update(){
        if (sEvents.Count > 0) {
            while (sEvents.Count > 0) {
                KeyValuePair<int, ByteBuffer> _event = sEvents.Dequeue();
                switch (_event.Key) {
                    default: CallMethod("OnSocket", _event.Key, _event.Value); break;
                }
            }
        }
    }

    /// <summary>
    /// ������������
    /// </summary>
    public void SendConnect() {
        SocketClient.SendConnect();
    }

    /// <summary>
    /// ����SOCKET��Ϣ
    /// </summary>
    public void SendMessage(ByteBuffer buffer) {
        SocketClient.SendMessage(buffer);
    }

    /// <summary>
    /// ��������
    /// </summary>
    new void OnDestroy() {
        base.OnDestroy();
        Debug.Log("~NetworkManager was destroy");
    }
}

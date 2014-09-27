using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyValue {
    public string key;
    public string value;
    public KeyValue(string key, string value) {
        this.key = key; this.value = value;
    }
}

public class PanelManager : MonoBehaviour {
    private Transform parent;
    private static Queue<KeyValue> events = new Queue<KeyValue>();

    Transform Parent {
        get {
            if (parent == null) {
                parent = io.guiCamera;
            }
            return parent;
        }
    }

    void Update() {
        if (events.Count == 0) return;
        KeyValue ev = events.Dequeue();
        string name = ev.key;
        string text = ev.value;
        AssetBundle bundle = io.resourceManager.LoadBundle(name);
        StartCoroutine(StartCreatePanel(name, bundle, text));
        Debug.LogWarning("CreatePanel::>> " + name + " " + bundle);
    }

    /// <summary>
    /// 创建面板，请求资源管理器
    /// </summary>
    /// <param name="type"></param>
    public void CreatePanel(string name, string text = null) {
        events.Enqueue(new KeyValue(name, text));
    }

    /// <summary>
    /// 请求资源回调函数
    /// </summary>
    public void OnRequestResource(string type, AssetBundle bundle, string text = null) {
        StartCreatePanel(type, bundle, text);
    }

    /// <summary>
    /// 创建面板
    /// </summary>
    IEnumerator StartCreatePanel(string name, AssetBundle bundle, string text = null) {
        name += "Panel";
        GameObject prefab = bundle.Load(name) as GameObject;
        yield return new WaitForEndOfFrame();
        if (Parent.FindChild(name) != null || prefab == null) {
            yield break;
        }
        GameObject go = Instantiate(prefab) as GameObject;
        go.name = name;
        go.layer = LayerMask.NameToLayer("Default");
        go.transform.parent = Parent;
        go.transform.localScale = Vector3.one;
        go.transform.localPosition = Vector3.zero;

        yield return new WaitForEndOfFrame();
        go.AddComponent<BaseLua>().OnInit(bundle);

        Debug.Log("StartCreatePanel------>>>>" + name);
    }
}

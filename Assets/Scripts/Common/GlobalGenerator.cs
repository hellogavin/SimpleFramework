using UnityEngine;
using System.Collections;

/// <summary>
/// ȫ�ֹ�������ÿ�������ﶼ�У�����ÿ�����������ʼ��һ�飬Ҳ���ʼ����Ϸ������һ��
/// �����Ϸ�������Ѿ������ˣ��������ˣ����򴴽���Ϸ������������֤��Ϸ��ֻ��һ��GameManager
/// </summary>
public class GlobalGenerator : MonoBehaviour {

    void Awake() {
        InitGameMangager();
    }

    void Start() {
        io.gameManager.OnInitScene();
    }

    /// <summary>
    /// ʵ������Ϸ������
    /// </summary>
    public void InitGameMangager() {
        string name = "GameManager";
        GameObject manager = GameObject.Find(name);
        if (manager == null) {
            GameObject prefab = io.LoadPrefab(name);
            manager = Instantiate(prefab) as GameObject;
            manager.name = name;
        }
    }
}

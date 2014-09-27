using UnityEngine;
using System.Collections;

/// <summary>
/// ȫ�ֹ�������ÿ�������ﶼ�У�����ÿ�����������ʼ��һ�飬Ҳ���ʼ����Ϸ������һ��
/// �����Ϸ�������Ѿ������ˣ��������ˣ����򴴽���Ϸ������������֤��Ϸ��ֻ��һ��GameManager
/// </summary>
public class GlobalGenerator : MonoBehaviour {
    private static GameObject prefab;

    void Awake() {
        InitGameMangager();
    }

    /// <summary>
    /// ʵ������Ϸ������
    /// </summary>
    public void InitGameMangager() {
        GameObject gameManager = GameObject.Find("GameManager");
        if (gameManager == null) {
            if (prefab == null) {
                prefab = Resources.Load("Prefabs/GameManager", typeof(GameObject)) as GameObject;
            }
            gameManager = Instantiate(prefab) as GameObject;
            gameManager.name = "GameManager";
        }
    }
}

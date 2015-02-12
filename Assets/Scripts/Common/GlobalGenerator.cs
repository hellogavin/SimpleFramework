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
        ioo.gameManager.OnInitScene();
    }

    /// <summary>
    /// ʵ������Ϸ������
    /// </summary>
    public void InitGameMangager() {
        string name = "GameManager";
        GameObject manager = GameObject.Find(name);
        if (manager == null) {
            GameObject prefab = ioo.LoadPrefab(name);
            manager = Instantiate(prefab) as GameObject;
            manager.name = name;
        }
    }

    void OnGUI() {
        GUI.Label(new Rect(10, 0, 500, 50), "(1) ���� \"Lua/Gen Lua Wrap Files\"��");
        GUI.Label(new Rect(10, 20, 500, 50), "(2) ����Unity��Ϸ");
        GUI.Label(new Rect(10, 40, 500, 50), "PS: ������棬����\"Lua/Clear LuaBinder File + Wrap Files\"��");
        GUI.Label(new Rect(10, 60, 900, 50), "PS: �����е������������Const.DebugMode=false�����ص���������Const.DebugMode=true");
        GUI.Label(new Rect(10, 80, 500, 50), "PS: ��Unity+ulua��������Ⱥ��>>341746602");
    }
}

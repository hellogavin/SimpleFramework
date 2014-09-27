using UnityEngine;
using System.Collections;
using System.Text;

/// <summary>
/// Interface Manager Object 
/// </summary>
public class io {  
    /// <summary>
    /// ��Ϸ����������
    /// </summary>
    private static GameObject _manager = null;
    public static GameObject manager {
        get { 
            if (_manager == null) 
                _manager = GameObject.FindWithTag("GameManager");
            return _manager;
        }
    }

    /// <summary>
    /// ��Ϸ������
    /// </summary>
    private static GameManager _gameManager = null;
    public static GameManager gameManager {
        get { 
            if (_gameManager == null)
                _gameManager = manager.GetComponent<GameManager>();
            return _gameManager;
        }
    }

    /// <summary>
    /// ��������
    /// </summary>
    private static PanelManager _panelManager = null;
    public static PanelManager panelManager {
        get {
            if (_panelManager == null)
                _panelManager = manager.GetComponent<PanelManager>();
            return _panelManager;
        }
    }

    /// <summary>
    /// ��Դ������
    /// </summary>
    private static ResourceManager _resourceManager = null;
    public static ResourceManager resourceManager {
        get {
            if (_resourceManager == null)
                _resourceManager = manager.GetComponent<ResourceManager>();
            return _resourceManager;
        }
    }

    /// <summary>
    /// ��ʱ��������
    /// </summary>
    private static TimerManager _timerManager = null;
    public static TimerManager timerManager {
        get { 
            if (_timerManager == null)
                _timerManager = manager.GetComponent<TimerManager>();
            return _timerManager;
        }
    }

    /// ����������
    /// </summary>
    private static MusicManager _musicManager = null;
    public static MusicManager musicManager {
        get {
            if (_musicManager == null)
                _musicManager = manager.GetComponent<MusicManager>();
            return _musicManager;
        }
    }

    /// <summary>
    /// ��ȡ������
    /// </summary>
    private static Transform _mainUi;
    public static Transform MainUI {
        get { 
            if (_mainUi == null) 
                _mainUi = GameObject.FindWithTag("MainUI").transform;
            return _mainUi;
        }
    }

    /// <summary>
    /// ��ʽ���ַ���
    /// </summary>
    /// <returns></returns>
    public static string f(string format, params object[] args) {
        StringBuilder sb = new StringBuilder();
        return sb.AppendFormat(format, args).ToString();
    }

    /// <summary>
    /// �ַ�������
    /// </summary>
    public static string c(params object[] args) { 
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < args.Length; i++ ) {
            sb.Append(args[i].ToString());
        }
        return sb.ToString();
    }
}

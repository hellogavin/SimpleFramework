using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using ICSharpCode.SharpZipLib.GZip;

public class Util : MonoBehaviour {
    public static int Int(object o) {
        return Convert.ToInt32(o);
    }

    public static float Float(object o) {
        return (float)Math.Round(Convert.ToSingle(o), 2);
    }

    public static long Long(object o) {
        return Convert.ToInt64(o);
    }

    public static int Random(int min, int max) {
        return UnityEngine.Random.Range(min, max);
    }

    public static float Random(float min, float max) {
        return UnityEngine.Random.Range(min, max);
    }

    public static string Uid(string uid) {
        int position = uid.LastIndexOf('_');
        return uid.Remove(0, position + 1);
    }

    public static long GetTime() {
        TimeSpan ts = new TimeSpan(DateTime.UtcNow.Ticks - new DateTime(1970, 1, 1, 0, 0, 0).Ticks);
        return (long)ts.TotalMilliseconds;
    }

    /// <summary>
    /// �������������-GameObject��
    /// </summary>
    public static T Get<T>(GameObject go, string subnode) where T : Component {
        if (go != null) {
            Transform sub = go.transform.FindChild(subnode);
            if (sub != null) return sub.GetComponent<T>();
        }
        return null;
    }

    /// <summary>
    /// �������������-Transform��
    /// </summary>
    public static T Get<T>(Transform go, string subnode) where T : Component {
        if (go != null) {
            Transform sub = go.FindChild(subnode);
            if (sub != null) return sub.GetComponent<T>();
        }
        return null;
    }

    /// <summary>
    /// �������������-Component��
    /// </summary>
    public static T Get<T>(Component go, string subnode) where T : Component {
        return go.transform.FindChild(subnode).GetComponent<T>();
    }

    /// <summary>
    /// ������
    /// </summary>
    public static T Add<T>(GameObject go) where T : Component {
        if (go != null) {
            T[] ts = go.GetComponents<T>();
            for (int i = 0; i < ts.Length; i++ ) {
                if (ts[i] != null) Destroy(ts[i]);
            }
            return go.gameObject.AddComponent<T>();
        }
        return null;
    }

    /// <summary>
    /// ������
    /// </summary>
    public static T Add<T>(Transform go) where T : Component {
        return Add<T>(go.gameObject);
    }

    /// <summary>
    /// �����Ӷ���
    /// </summary>
    public static GameObject Child(GameObject go, string subnode) {
        return Child(go.transform, subnode);
    }

    /// <summary>
    /// �����Ӷ���
    /// </summary>
    public static GameObject Child(Transform go, string subnode) {
        Transform tran = go.FindChild(subnode);
        if (tran == null) return null;
        return tran.gameObject;
    }

    /// <summary>
    /// ȡƽ������
    /// </summary>
    public static GameObject Peer(GameObject go, string subnode) {
        return Peer(go.transform, subnode);
    }

    /// <summary>
    /// ȡƽ������
    /// </summary>
    public static GameObject Peer(Transform go, string subnode) {
        Transform tran = go.parent.FindChild(subnode);
        if (tran == null) return null;
        return tran.gameObject;
    }

    /// <summary>
    /// �ֻ���
    /// </summary>
    public static void Vibrate() {
        //int canVibrate = PlayerPrefs.GetInt(Const.AppPrefix + "Vibrate", 1);
        //if (canVibrate == 1) iPhoneUtils.Vibrate();
    }

    /// <summary>
    /// Base64����
    /// </summary>
    public static string Encode(string message) {
        byte[] bytes = Encoding.GetEncoding("utf-8").GetBytes(message);
        return Convert.ToBase64String(bytes);
    }

    /// <summary>
    /// Base64����
    /// </summary>
    public static string Decode(string message) {
        byte[] bytes = Convert.FromBase64String(message);
        return Encoding.GetEncoding("utf-8").GetString(bytes);
    }

    /// <summary>
    /// �ж�����
    /// </summary>
    public static bool IsNumeric(string str) {
        if (str == null || str.Length == 0) return false;
        for (int i = 0; i < str.Length; i++ ) {
            if (!Char.IsNumber(str[i])) { return false; }
        }
        return true;
    }

    /// <summary>
    /// HashToMD5Hex
    /// </summary>
    public static string HashToMD5Hex(string sourceStr) {
        byte[] Bytes = Encoding.UTF8.GetBytes(sourceStr);
        using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider()) {
            byte[] result = md5.ComputeHash(Bytes);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
                builder.Append(result[i].ToString("x2"));
            return builder.ToString();
        }
    }

    /// <summary>
    /// �����ַ�����MD5ֵ
    /// </summary>
    public static string md5(string source) {
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        byte[] data = System.Text.Encoding.UTF8.GetBytes(source);
        byte[] md5Data = md5.ComputeHash(data, 0, data.Length);
        md5.Clear();

        string destString = "";
        for (int i = 0; i < md5Data.Length; i++) {
            destString += System.Convert.ToString(md5Data[i], 16).PadLeft(2, '0');
        }
        destString = destString.PadLeft(32, '0');
        return destString;
    }

        /// <summary>
    /// �����ļ���MD5ֵ
    /// </summary>
    public static string md5file(string file) {
        try {
            FileStream fs = new FileStream(file, FileMode.Open);
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(fs);
            fs.Close();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++) {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        } catch (Exception ex) {
            throw new Exception("md5file() fail, error:" + ex.Message);
        }
    }

    /// <summary>
    /// ���ܣ�ѹ���ַ���
    /// </summary>
    /// <param name="infile">��ѹ�����ļ�·��</param>
    /// <param name="outfile">����ѹ���ļ���·��</param>
    public static void CompressFile(string infile, string outfile) {
        Stream gs = new GZipOutputStream(File.Create(outfile));
        FileStream fs = File.OpenRead(infile);
        byte[] writeData = new byte[fs.Length];
        fs.Read(writeData, 0, (int)fs.Length);
        gs.Write(writeData, 0, writeData.Length);
        gs.Close(); fs.Close();
    }

    /// <summary>
    /// ���ܣ������ļ�·�������ؽ�ѹ����ַ���
    /// </summary>
    public static string DecompressFile(string infile) {
        string result = string.Empty;
        Stream gs = new GZipInputStream(File.OpenRead(infile));
        MemoryStream ms = new MemoryStream();
        int size = 2048;
        byte[] writeData = new byte[size]; 
        while (true) {
            size = gs.Read(writeData, 0, size); 
            if (size > 0) {
                ms.Write(writeData, 0, size); 
            } else {
                break; 
            }
        }
        result = new UTF8Encoding().GetString(ms.ToArray());
        gs.Close(); ms.Close();
        return result;
    }

    /// <summary>
    /// ѹ���ַ���
    /// </summary>
    public static string Compress(string source) {
        byte[] data = Encoding.UTF8.GetBytes(source);
        MemoryStream ms = null;
        using (ms = new MemoryStream()) {
            using (Stream stream = new GZipOutputStream(ms)) {
                try {
                    stream.Write(data, 0, data.Length);
                } finally {
                    stream.Close();
                    ms.Close();
                }
            }
        }
        return Convert.ToBase64String(ms.ToArray());
    }

    /// <summary>
    /// ��ѹ�ַ���
    /// </summary>
    public static string Decompress(string source) {
        string result = string.Empty;
        byte[] buffer = null;
        try {
            buffer = Convert.FromBase64String(source);
        } catch {
            Debug.LogError("Decompress---->>>>" + source);
        }
        using (MemoryStream ms = new MemoryStream(buffer)) {
            using (Stream sm = new GZipInputStream(ms)) {
                StreamReader reader = new StreamReader(sm, Encoding.UTF8);
                try {
                    result = reader.ReadToEnd();
                } finally {
                    sm.Close();
                    ms.Close();
                }
            }
        }
        return result;
    }

    /// <summary>
    /// ��������ӽڵ�
    /// </summary>
    public static void ClearChild(Transform go) {
        if (go == null) return;
        for (int i = go.childCount - 1; i >= 0; i--) {
            Destroy(go.GetChild(i).gameObject);
        }
    }

    /// <summary>
    /// ����һ��Key��
    /// </summary>
    public static string GetKey(string key) {
        return Const.AppPrefix + Const.UserId + "_" + key; 
    }

    /// <summary>
    /// ȡ������
    /// </summary>
    public static int GetInt(string key) {
        string name = GetKey(key);
        return PlayerPrefs.GetInt(name);
    }

    /// <summary>
    /// ��û��ֵ
    /// </summary>
    public static bool HasKey(string key) {
        string name = GetKey(key);
        return PlayerPrefs.HasKey(name);
    }

    /// <summary>
    /// ��������
    /// </summary>
    public static void SetInt(string key, int value) {
        string name = GetKey(key);
        PlayerPrefs.DeleteKey(name);
        PlayerPrefs.SetInt(name, value);
    }

    /// <summary>
    /// ȡ������
    /// </summary>
    public static string GetString(string key) {
        string name = GetKey(key);
        return PlayerPrefs.GetString(name);
    }

    /// <summary>
    /// ��������
    /// </summary>
    public static void SetString(string key, string value) {
        string name = GetKey(key);
        PlayerPrefs.DeleteKey(name);
        PlayerPrefs.SetString(name, value);
    }

    /// <summary>
    /// ɾ������
    /// </summary>
    public static void RemoveData(string key) {
        string name = GetKey(key);
        PlayerPrefs.DeleteKey(name);
    }

    /// <summary>
    /// �����ڴ�
    /// </summary>
    public static void ClearMemory() {
        GC.Collect(); Resources.UnloadUnusedAssets();
    }

    /// <summary>
    /// �Ƿ�Ϊ����
    /// </summary>
    public static bool IsNumber(string strNumber) {
        Regex regex = new Regex("[^0-9]");
        return !regex.IsMatch(strNumber);
    }

    /// <summary>
    /// ȡ��App������Ķ�ȡĿ¼
    /// </summary>
    public static Uri AppContentDataUri {
        get {
            string dataPath = Application.dataPath;
            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                var uriBuilder = new UriBuilder();
                uriBuilder.Scheme = "file";
                uriBuilder.Path = Path.Combine(dataPath, "Raw");
                return uriBuilder.Uri;
            } else if (Application.platform == RuntimePlatform.Android) {
                return new Uri("jar:file://" + dataPath + "!/assets");
            } else {
                var uriBuilder = new UriBuilder();
                uriBuilder.Scheme = "file";
                uriBuilder.Path = Path.Combine(dataPath, "StreamingAssets");
                return uriBuilder.Uri;
            }
        }
    }

    /// <summary>
    /// ȡ�����ݴ��Ŀ¼
    /// </summary>
    public static string DataPath {
        get {
            string game = Const.AppName.ToLower();
            string dataPath = Application.dataPath;
            if (Const.DebugMode) AppContentDataUri.ToString();

            if (Application.platform == RuntimePlatform.IPhonePlayer) {
                string path = Path.GetDirectoryName(Path.GetDirectoryName(dataPath));
                return Path.Combine(path, "Documents/" + game + "/");
            } else if (Application.platform == RuntimePlatform.Android) {
                return "/sdcard/" + game + "/";
            }
            return dataPath + "/StreamingAssets/";
        }
    }

    /// <summary>
    /// ȡ�����ı�
    /// </summary>
    public static string GetFileText(string path) {
        return File.ReadAllText(path);
    }

    /// <summary>
    /// �������
    /// </summary>
    public static bool NetAvailable {
        get {
            return Application.internetReachability != NetworkReachability.NotReachable;
        }
    }

    /// <summary>
    /// �Ƿ�������
    /// </summary>
    public static bool IsWifi {
        get {
            return Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork;
        }
    }

    /// <summary>
    /// ȡ�����ݴ��Ŀ¼
    /// </summary>
    public static string GetDataDir() {
        string dataPath = Application.dataPath;
        if (Application.platform == RuntimePlatform.IPhonePlayer) {
            string path = Path.GetDirectoryName(Path.GetDirectoryName(dataPath));
            return Path.Combine(path, "Documents/testgame/");
        } else if (Application.platform == RuntimePlatform.Android) {
            return "/sdcard/testgame/";
        }
        if (Const.DebugMode) return dataPath;
        return "c:/";
    }

    /// <summary>
    /// Ӧ�ó�������·��
    /// </summary>
    public static string AppContentPath() {
        string path = string.Empty;
        switch (Application.platform) {
            case RuntimePlatform.Android:
                path = "jar:file://" + Application.dataPath + "!/assets/";
            break;
            case RuntimePlatform.IPhonePlayer:
                path = Application.dataPath + "/Raw/";
            break;
            default:
                path = "file://" + Application.dataPath + "/StreamingAssets/";
            break;
        }
        return path;
    }
}
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class Packager {
    public static string platform = string.Empty;
    static List<string> paths = new List<string>();
    static List<string> files = new List<string>();

    ///-----------------------------------------------------------
    static string[] exts = { ".txt", ".xml", ".lua", ".assetbundle" };
    static bool CanCopy(string ext) {   //�ܲ��ܸ���
        foreach (string e in exts) {
            if (ext.Equals(e)) return true;
        }
        return false;
    }

    /// <summary>
    /// �����ز�
    /// </summary>
    static UnityEngine.Object LoadAsset(string file) {
        if (file.EndsWith(".lua")) file += ".txt";
        return AssetDatabase.LoadMainAssetAtPath("Assets/Builds/" + file);
    }

    /// <summary>
    /// ���ɰ��ز�
    /// </summary>
    [MenuItem("Game/Build Bundle Resource")]
    public static void BuildAssetResource() {
        UpdateResource();               //�ȸ�����Դ
        Object mainAsset = null;        //���ز���������
        Object[] addiAssets = null;     //�����ز��������
        string assetfile = string.Empty;  //�ز��ļ���

        BuildAssetBundleOptions options = BuildAssetBundleOptions.UncompressedAssetBundle | BuildAssetBundleOptions.CollectDependencies |
                                          BuildAssetBundleOptions.CompleteAssets | BuildAssetBundleOptions.DeterministicAssetBundle;

        BuildTarget target;
        if (Application.platform == RuntimePlatform.OSXEditor) {
            target = BuildTarget.iPhone;
        } else {
            target = BuildTarget.Android;
        }
        string assetPath = Application.dataPath + "/StreamingAssets/asset/" + target + "/";
        if (!Directory.Exists(assetPath)) Directory.CreateDirectory(assetPath);

        ///-----------------------------���ɹ����Lua��Դ---------------------------------------
        addiAssets = new Object[3];   //���ӽű��ز�
        addiAssets[0] = LoadAsset("Common/Scripts/define.lua");
        addiAssets[1] = LoadAsset("Common/Scripts/functions.lua");
        addiAssets[2] = LoadAsset("Backup/Scripts/BackupPanel.lua");

        assetfile = assetPath + "common.assetbundle";
        BuildPipeline.BuildAssetBundle(null, addiAssets, assetfile, options, target);

        ///-----------------------------���ɹ���Ĺ������زİ�-------------------------------------
        BuildPipeline.PushAssetDependencies();

        assetfile = assetPath + "shared.assetbundle";
        mainAsset = LoadAsset("Shared/Atlas/Dialog.prefab");
        BuildPipeline.BuildAssetBundle(mainAsset, null, assetfile, options, target);

        ///------------------------------����BackupPanel�زİ�-----------------------------------
        BuildPipeline.PushAssetDependencies();
        mainAsset = LoadAsset("Backup/Prefabs/BackupPanel.prefab");
        assetfile = assetPath + "backup.assetbundle";
        BuildPipeline.BuildAssetBundle(mainAsset, null, assetfile, options, target);
        BuildPipeline.PopAssetDependencies();

        ///-------------------------------ˢ��---------------------------------------
        BuildPipeline.PopAssetDependencies();
        AssetDatabase.Refresh();
    }

    /// <summary>
    /// ������Դ:��lua�ļ�����txt
    /// </summary>
    static void UpdateResource() {
        paths.Clear(); files.Clear();
        Recursive(AppDataPath + "/Builds/");

        for (int i = 0; i < files.Count; i++) {
            string file = files[i];
            if (!file.EndsWith(".lua")) continue;

            string newfile = file + ".txt";
            if (File.Exists(newfile)) File.Delete(newfile);

            string[] oldContent = File.ReadAllLines(file);
            List<string> newContent = new List<string>();
            for (int j = 0; j < oldContent.Length; j++) {
                string str = oldContent[j].Trim();
                if (str.StartsWith("--")) continue; //�����ע���У���������д���ļ�
                newContent.Add(oldContent[j]);
            }
            File.WriteAllLines(newfile, newContent.ToArray(), System.Text.Encoding.UTF8);
        }
        AssetDatabase.Refresh();
    }

    /// <summary>
    /// ����Ŀ¼
    /// </summary>
    static string AppDataPath {
        get { return Application.dataPath.ToLower(); }
    }

    /// <summary>
    /// ����Ŀ¼������Ŀ¼
    /// </summary>
    static void Recursive(string path) {
        string[] names = Directory.GetFiles(path);
        string[] dirs = Directory.GetDirectories(path);
        foreach (string filename in names) {
            string ext = Path.GetExtension(filename);
            if (ext.Equals(".meta")) continue;
            files.Add(filename.Replace('\\', '/'));
        }
        foreach (string dir in dirs) {
            paths.Add(dir.Replace('\\', '/'));
            Recursive(dir);
        }
    }
}
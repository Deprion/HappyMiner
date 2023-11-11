using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public static SimpleEvent<long, long> TopRecords = new SimpleEvent<long, long>();

    private string path;

    public Data data { get; private set; }

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);

        path = Application.persistentDataPath + "/Data.dat";
        LoadData();
    }

    private void LoadData()
    {
        if (!File.Exists(path))
        {
            data = new Data();
            return;
        }

        data = JsonUtility.FromJson<Data>(File.ReadAllText(path));

        TopRecords.Invoke(data.Limited, data.Endless);
    }

    private void SaveData()
    {
        File.WriteAllText(path, JsonUtility.ToJson(data));
    }

    public class Data
    {
        public long Endless, Limited;
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus) SaveData();
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }
}

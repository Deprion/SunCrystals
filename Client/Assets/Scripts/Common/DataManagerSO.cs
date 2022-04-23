using System.IO;
using UnityEngine;

[CreateAssetMenu(menuName = "ManagersSO/Data")]
public class DataManagerSO : ScriptableObject
{
    public static DataManagerSO inst { get; private set; }
    private string path;
    public Data Data { get; private set; }

    public void Init()
    {
        inst = this;
        path = Application.persistentDataPath + "/data.crs";
        LoadData();
    }
    private void LoadData()
    {
        if (File.Exists(path))
        {
            Data = JsonUtility.FromJson<Data>(File.ReadAllText(path));
        }
        else
        {
            Data = new Data()
            {
                LocationData = new LocationData()
                {
                    maxLoc = 0,
                    maxChapter = 0,
                    maxLvl = 0,
                    numLocation = 0,
                    numChapter = 0,
                    numLvl = 0
                }
            };
        }
    }
    public void SaveData()
    {
        File.WriteAllText(path, JsonUtility.ToJson(Data));
    }
    public void DeleteData()
    {
        File.Delete(path);
        PlayerPrefs.DeleteAll();
    }
}
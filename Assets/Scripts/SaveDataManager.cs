using System.IO;
using UnityEngine;

public class SaveDataManager : MonoBehaviour
{

    public static SaveDataManager Instance;

    public Score CurrentScore;
    public Score TopScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        CurrentScore = new Score();
        TopScore = new Score();
        Load();
    }

    private string GetSavePath()
    {
        return Application.persistentDataPath + "/savefile.json";
    }

    public void Load()
    {
        string path = GetSavePath();
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            this.CurrentScore = new Score();
            this.CurrentScore.PlayerName = data.CurrentName;
            this.TopScore = data.TopScore;
        }
    }

    public void Save()
    {
        string path = GetSavePath();
        SaveData data = new SaveData();
        data.CurrentName = this.CurrentScore.PlayerName;
        data.TopScore = this.TopScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    [System.Serializable]
    private class SaveData
    {
        public string CurrentName;
        public Score TopScore;
    }

}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PersistentManager : MonoBehaviour
{
    public static PersistentManager Instance;

    private string PlayerNameHighScore;
    private int HighScore = 0;

    private string CurrentPlayerName = "";
    private int CurrentPlayerScore = 0;
    
    private string PathFilePersistence;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        PathFilePersistence = Application.persistentDataPath + "/MissionPersistenceRepoFile.json";
        LoadHighScore();
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string Player = "";
        public int HighScore = 0;
    }

    private void LoadHighScore()
    {
        if (File.Exists(PathFilePersistence))
        {
            string json = File.ReadAllText(PathFilePersistence);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            PlayerNameHighScore = data.Player;
            HighScore = data.HighScore;
        }
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.Player = CurrentPlayerName;
        data.HighScore = CurrentPlayerScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(PathFilePersistence, json);
        PlayerNameHighScore = CurrentPlayerName;
        HighScore = CurrentPlayerScore;
    }

    public void setPlayerName(string name)
    {
        if (name == null || name.Replace(" ","").Length < 1)
        {
            name = "dummy";
        }
        CurrentPlayerName = name;
    }

    public string getPlayerName()
    {
        return CurrentPlayerName;
    }

    public void setPlayerScore(int score)
    {
        CurrentPlayerScore = score;
    }

    public string GetPlayerHighScoreForDisplay()
    {
        if (HighScore > 0) {
            return PlayerNameHighScore + " : " + HighScore;
        }
        return "no highscore";
    }

    public int getHighScore()
    {
        return HighScore;
    }
}

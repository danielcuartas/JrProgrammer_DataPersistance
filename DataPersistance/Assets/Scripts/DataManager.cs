using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string player;
    public int score;

    string jsonHiScore;
    string jsonScore;

    public SaveData dataHiScore = new SaveData();


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    [System.Serializable]
    public class SaveData
    {
        public string player;
        public int score = 0;
    }

    public void SaveScore()
    {

        LoadScore();

        if (score > dataHiScore.score)
        {
            SaveData dataToSave = new SaveData();
            dataToSave.player = player;
            dataToSave.score = score;
            jsonScore = JsonUtility.ToJson(dataToSave);
            File.WriteAllText(Application.persistentDataPath + "/savefilePersistance.json", jsonScore);
        }
    }   

    public void LoadScore()
    {
        
        string path = Application.persistentDataPath + "/savefilePersistance.json";

        if (File.Exists(path))
        {
            jsonHiScore = File.ReadAllText(path);
            dataHiScore = JsonUtility.FromJson<SaveData>(jsonHiScore);
        }
    }

}

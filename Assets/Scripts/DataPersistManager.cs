using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataPersistManager : MonoBehaviour
{
    public static DataPersistManager Instance;
    private string Name;
    private int Point;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);        
    }

    [System.Serializable]
    public class Score
    {
        public int Point;
        public string Name;
    }

    public string GetBestScoreText()
    {
        return Name + " : " + Point;
    }

    public void SaveBestScore(int point)
    {
        if (point <= Point)
            return;

        var score = new Score();
        score.Point = point;
        score.Name = Name;

        var json = JsonUtility.ToJson(score);
        var path = Application.persistentDataPath + "/bestScore.json";
        File.WriteAllText(path, json);
    }

    public void LoadBestScore()
    {
        var path = Application.persistentDataPath + "/bestScore.json";
        if (!File.Exists(path))
            return;

        var json = File.ReadAllText(path);
        var score = JsonUtility.FromJson<Score>(json);
        Name = score.Name;
        Point = score.Point;
    }

    public void SaveName(string name)
    {
        Name = name;
    }

}

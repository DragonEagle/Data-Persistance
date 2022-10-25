using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
class HighScore{
    public string name;
    public int score;
}
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public string playerName;
    public string highScoreName = "Name";
    public int highScore = 0;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }

    public void SaveHighScore()
    {
        HighScore data = new HighScore();
        data.name = playerName;
        data.score = highScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath+"/highscore.json",json);

    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/highscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            HighScore data = JsonUtility.FromJson<HighScore>(json);
            highScoreName = data.name;
            highScore = data.score;
        }
    }
}

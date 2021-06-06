using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string Name;
    public BestScore bestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }
    
    public void SaveScore(int score)
    {
        //BestScore data = new BestScore();
        bestScore.name = Name;
        bestScore.score = score;

        string json = JsonUtility.ToJson(bestScore);
  
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestScore data = JsonUtility.FromJson<BestScore>(json);

            bestScore = data;
        }
    }
}

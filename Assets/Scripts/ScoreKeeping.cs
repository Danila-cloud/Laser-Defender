using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeping : MonoBehaviour
{
    private int Score;

    private static ScoreKeeping instance;

    private void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    public int GetScore()
    {
        return Score;
    }

    public void ModifyScore(int sum)
    {
        Score += sum;
        Debug.Log(Score);
    }

    public void ResetScore()
    {
        Score = 0;
    }
}

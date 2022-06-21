using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeping : MonoBehaviour
{
    private int Score;

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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private ScoreKeeping _scoreKeeping;
    private void Awake()
    {
        _scoreKeeping = FindObjectOfType<ScoreKeeping>();
    }

    void Start()
    {
        scoreText.text = "Your score:\n" + _scoreKeeping.GetScore();
    }

}

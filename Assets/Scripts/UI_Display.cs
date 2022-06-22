using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_Display : MonoBehaviour
{
    private ScoreKeeping _scoreKeeping;

    [SerializeField] private Healt PLayerHealth;
    [SerializeField] private TextMeshProUGUI Score;
    [SerializeField] private Slider HealthSlider;

    private void Awake()
    {
        _scoreKeeping = FindObjectOfType<ScoreKeeping>();
    }

    void Start()
    {
        HealthSlider.maxValue = PLayerHealth.GetHealth();
    }

    void Update()
    {
        Score.text = _scoreKeeping.GetScore().ToString("000000000");
        HealthSlider.value = PLayerHealth.GetHealth();
    }
}

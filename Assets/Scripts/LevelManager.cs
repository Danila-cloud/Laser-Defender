using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float sceneDelay = 2f;
    private ScoreKeeping _scoreKeeping;

    private void Awake()
    {
        _scoreKeeping = FindObjectOfType<ScoreKeeping>();
    }

    public void LoadGame()
    {
        _scoreKeeping.ResetScore();
        StartCoroutine(WaitAndLoad("Game", sceneDelay));
    }
    public void LoadMainMenu()
    {
        StartCoroutine(WaitAndLoad("MainMenu", sceneDelay));
    }
    public void LoadEndMenu()
    {
        StartCoroutine(WaitAndLoad("EndMenu", sceneDelay));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string SceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneName);
    }
}

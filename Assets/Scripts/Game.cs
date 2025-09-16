using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private PipeGenerator _pipeGenerator;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButonClick;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
        _bird.GameOver += EndGame;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButonClick;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClick;
        _bird.GameOver -= EndGame;
    }

    private void Start()
    {
        _startScreen.Open();
        Time.timeScale = 0;
    }

    private void OnPlayButonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _endGameScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _bird.Reset();
        _pipeGenerator.Reset();
    }

    private void EndGame()
    {
        Time.timeScale = 0;
        _endGameScreen.Open();
    }
}

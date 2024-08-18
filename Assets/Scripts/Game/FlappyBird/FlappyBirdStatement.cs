using Datas;
using System;
using Helpers;
using UnityEngine;
using System.Collections;

public class FlappyBirdStatement : MonoBehaviour
{
    [SerializeField] private float gameStartDelay;
    [SerializeField] FlappyUI flappyUI;
    LeaderboardProcess leaderboard;

    int scoreCount = 0;
    private void Awake()
    {
        leaderboard = GameManager.instance.leaderboard;
    }
    private void Start()
    {
        //GameManager.instance.Score = scoreCount; // 0
        StartCoroutine(StartDelay());
    }
    IEnumerator StartDelay()
    {
        yield return new WaitForSecondsRealtime(gameStartDelay);
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        // GameManager.instance.SubmitScore();
        //StartCoroutine(GameManager.instance.SubmitScoreRoutine(scoreCount));
        flappyUI.gameOver_panel.SetActive(true);
    }

    public void UpdateScore()
    {
        scoreCount += 1;
        flappyUI.UpdateScore(scoreCount);
        //GameManager.instance.Score = scoreCount;
        DataManager.SaveScore(PrefesKeys.FlappyBird, scoreCount);
    }
}
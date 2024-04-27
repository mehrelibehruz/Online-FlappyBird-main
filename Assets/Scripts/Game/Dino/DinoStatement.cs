using Datas;
using Helpers;
using UnityEngine;

public class DinoStatement : MonoBehaviour
{
    private int scoreCount;
    [SerializeField] DionUI dionUI;
    private void Start() {
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        Time.timeScale = 0;
       // GameManager.instance.SubmitScore();
        // StartCoroutine(GameManager.instance.SubmitScoreRoutine(scoreCount));
        // DataManager.SaveScore(Constants.Dino, scoreCount);
        dionUI.gameOver_panel.SetActive(true);
    }
    public void UpdateScore()
    {
        scoreCount += 1;
        Debug.Log(scoreCount);
        dionUI.UpdateScore(scoreCount);

        // GameManager.instance.Score = scoreCount;
        DataManager.SaveScore(Constants.Dino, scoreCount);
    }
}
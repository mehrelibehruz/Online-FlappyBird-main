using TMPro;
using Datas;
using Helpers;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;

public class LeaderboardPanel : BasePanel
{   
    List<TextMeshProUGUI> textObjects_score, textObjects_name;

    [SerializeField] LeaderboardProcess leaderboardProcess;
    
    private void Start()
    {        
        CloseButton.onClick.AddListener(Close);    
    }
    
    public void OpenLeaderboard()
    {
        Panel.SetActive(true);
    }
    public void ShowGameScore(int index)
    {
        switch (index)
        {
            case 0:
                StartCoroutine(SetupScore(PrefesKeys.FlappyBird));
                DataManager.SetGameState(PrefesKeys.FlappyBird, GameState.open);

                m_SceneManager.LoadScene(Scenes.MainMenu);
                break;

            case 1:
                StartCoroutine(SetupScore(PrefesKeys.FlappyBird));
                DataManager.SetGameState(PrefesKeys.Dino, GameState.open);

                m_SceneManager.LoadScene(Scenes.MainMenu);
                break;
        }
    }
    IEnumerator SetupScore(PrefesKeys gameName)
    {
        yield return StartCoroutine(GameManager.instance.SubmitScoreRoutine(DataManager.GetScore(gameName)));

        yield return new WaitForSeconds(0.3f);

        foreach (var go in textObjects_name)
        {
            Destroy(go);
        }
        textObjects_name.Clear();

        foreach (var go in textObjects_score)
        {
            Destroy(go);
        }
        textObjects_score.Clear();

        yield return new WaitForSeconds(0.4f);

        yield return leaderboardProcess.FetchTopHighscoresRoutineOrigin();
    }

    public override void Close()
    {
        DataManager.SetGameState(PrefesKeys.FlappyBird, GameState.close);
        DataManager.SetGameState(PrefesKeys.Dino, GameState.close);

        Panel.SetActive(false);
    }
}
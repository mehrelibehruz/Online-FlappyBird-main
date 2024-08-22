using TMPro;
using Datas;
using Utils;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;

public class LeaderboardPanel : BasePanel
{   
    List<TextMeshProUGUI> textObjects_score, textObjects_name;

    [SerializeField] LeaderboardProcessService leaderboardProcess;

    public override void InitButtons()
    {
        CloseButton.onClick.AddListener(_Close);
    }

    public override void InitTexts()
    {
       
    }
    private void Start()
    {
        InitButtons();
        InitTexts();
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

       // yield return leaderboardProcess.FetchTopHighscoresRoutineOrigin();
    }

    public void _Close()
    {
        DataManager.SetGameState(PrefesKeys.FlappyBird, GameState.close);
        DataManager.SetGameState(PrefesKeys.Dino, GameState.close);
        //base.Close();
        Close();
    }
    public override void Close()
    {
        base.Close();
    }
}
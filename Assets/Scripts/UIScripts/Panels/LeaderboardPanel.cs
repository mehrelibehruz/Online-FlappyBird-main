using TMPro;
using Datas;
using Helpers;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl;

public class LeaderboardPanel : BasePanel
{
    GameObject leaderBoard_Panel;
    List<TextMeshProUGUI> textObjects_score, textObjects_name;
    LeaderboardProcess leaderboard;

    public void OpenLeaderboard()
    {
        leaderBoard_Panel.SetActive(true);
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

        yield return leaderboard.FetchTopHighscoresRoutineOrigin();
    }  
    public void CloseLeaderboard()
    {   
        DataManager.SetGameState(PrefesKeys.FlappyBird, GameState.close);
        DataManager.SetGameState(PrefesKeys.Dino, GameState.close);

        leaderBoard_Panel.SetActive(false);
    }
}
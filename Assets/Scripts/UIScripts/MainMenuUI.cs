using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using Datas;
using Helpers;
using LootLocker.Extension.DataTypes;
using LootLocker.Requests;
using TMPro;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    [SerializeField] Leaderboard leaderboard;

    [SerializeField] TextMeshProUGUI appVersionInfo;
    [SerializeField] GameObject textObject_Prefab;
    [SerializeField] GameObject leaderBoard_Panel;
    [SerializeField] GameObject content_Panel;
    [SerializeField] GameObject lP_Names;
    [SerializeField] GameObject lP_Scores;
    [SerializeField] public TMP_InputField setName_InputField;

    public List<GameObject> textObjects_name = new List<GameObject>();
    public List<GameObject> textObjects_score = new List<GameObject>();
    public List<string> leaderBoard_Texts = new List<string>();
    public void GenerateTextField(string value, bool isName)
    {
        GameObject go = Instantiate(textObject_Prefab);
        if (isName)
        {
            textObjects_name.Add(go);
        }
        else
        {
            textObjects_score.Add(go);
        }

        go.GetComponent<TextMeshProUGUI>().text = value;
        leaderBoard_Texts.Add(value);

        if (isName)
        {
            go.transform.parent = lP_Names.transform;
        }
        else
        {
            go.transform.parent = lP_Scores.transform;
        }

        // PrintMembers();
    }

    private void Start()
    {
        appVersionInfo.text = GameManager.instance.AppVersion;
        leaderBoard_Panel.SetActive(false);

        Debug.LogError($"Data Flappy: {DataManager.GetScore(Constants.FlappyBird)}");
        Debug.LogError($"Data Dino: {DataManager.GetScore(Constants.Dino)}");

        // int rs = DataManager.GetScore(Constants.FlappyBird);
        // Debug.LogError(rs);
    }
    private void Awake()
    {
        //    StartCoroutine(GameManager.instance.SubmitScoreRoutine(0));
    }
    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         leaderBoard_Panel.SetActive(false);
    //     }
    // }
    private void PrintMembers()
    {
        for (int i = 0; i < textObjects_name.Count; i++)
        {
            Debug.Log(textObjects_name[i].GetComponent<TextMeshProUGUI>().text);
        }
    }

    // public void ShowCurrentUser(int userIndex, string name)
    // {
    //     textObjects[userIndex].GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0); // red
    //     // Debug.LogError(textObjectsElements.Equals(name));
    //     Debug.Log("");
    // }

    public void ShowCurrentUser(LootLockerLeaderboardMember[] members, int i)
    {
        if (PlayerManager.leaderBoardMembers[i].player.id == members[i].player.id)
        {
            Debug.LogError("Correct id");
            textObjects_name[i].GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0); // red
        }
        // Debug.LogError(textObjectsElements.Equals(name));

    }
    // public void GenerateTextField(string playerName, string playerID)
    // {
    //     GameObject go = Instantiate(textObject_Prefab);
    //     textObjects.Add(go);

    //     // Eğer bu oyuncu şu anki oturumda olan oyuncuysa, adının yanına bir yıldız simgesi ekleyin
    //     if (playerName == PlayerPrefs.GetString("PlayerName"))
    //     {
    //         go.GetComponent<TextMeshProUGUI>().text = playerName + " *"; // Oyuncunun adının yanına yıldız simgesi ekler
    //     }
    //     else
    //     {
    //         go.GetComponent<TextMeshProUGUI>().text = playerName;
    //     }

    //     go.transform.SetParent(leaderBoard_Panel.transform, false);
    // }

    public void GenerateTextField(string playerName, string playerID)
    {
        GameObject go = Instantiate(textObject_Prefab);
        textObjects_name.Add(go);

        // Eğer bu oyuncu şu anki oturumda olan oyuncuysa, adının yanına bir yıldız simgesi ekleyin
        if (playerID == SessionManager.PlayerID)
        {
            playerName += " *"; // Oyuncunun adının yanına yıldız simgesi ekler
        }

        go.GetComponent<TextMeshProUGUI>().text = playerName;
        go.transform.SetParent(leaderBoard_Panel.transform, false);
    }

    // public void ShowCurrentUser(string userID)
    // {
    //     if (userID == PlayerPrefs.GetString("PlayerName"))
    //         textObjects[0].GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0); // red
    // }

    //TODO: Add new Button system
    public static int gameIndex;
    public void PlayGame(int index) // FLappy:1, Dino: 2
    {
        gameIndex = index;
        SceneLoader.LoadScene(index);
    }
    // public void PlayGame(Scenes scene)
    // {
    //     SceneLoader.LoadScene(scene);
    // }

    public void OpenLeaderboard()
    {
        leaderBoard_Panel.SetActive(true);
    }
    public void ShowGameScore(int index)
    {
        // leaderboard.FetchTopHighscoresRoutineOrigin();        
        content_Panel.SetActive(true);
        switch (index)
        {
            case 0:
                //GameManager.instance.SubmitScoreRoutine(DataManager.GetScore(Constants.FlappyBird));
                // Debug.Log(DataManager.GetScore(Constants.FlappyBird));
                // DataManager.GetScore(Constants.FlappyBird);
                // StartCoroutine(GameManager.instance.SubmitScoreRoutine(DataManager.GetScore(Constants.FlappyBird)));

                StartCoroutine(SetupScore(Constants.FlappyBird));
                break;

            case 1:
                // GameManager.instance.SubmitScoreRoutine(DataManager.GetScore(Constants.Dino));
                // Debug.Log(DataManager.GetScore(Constants.Dino));
                // DataManager.GetScore(Constants.Dino);
                // StartCoroutine(GameManager.instance.SubmitScoreRoutine(DataManager.GetScore(Constants.Dino)));

                StartCoroutine(SetupScore(Constants.Dino));
                break;
        }
    }
    #region OLD SCORE
    // IEnumerator SetupScore(string gameName)
    // {
    //     StartCoroutine(GameManager.instance.SubmitScoreRoutine(DataManager.GetScore(gameName)));
    //     // content_Panel.SetActive(false);

    //     yield return new WaitForSeconds(0.3f);

    //     for (int i = textObjects_name.Count - 1; i >= 0; i--)
    //     {
    //         textObjects_name.RemoveAt(i);
    //         textObjects_score.RemoveAt(i);

    //         // Destroy(textObjects_name[i]);
    //         // Destroy(textObjects_score[i]);
    //     }

    //     // for (int i = 0; i < textObjects_name.Count; i++)
    //     // {
    //     //     textObjects_name[i].GetComponent<TextMeshProUGUI>().text = "";
    //     //     textObjects_score[i].GetComponent<TextMeshProUGUI>().text = "";
    //     // }

    //     yield return new WaitForSeconds(0.3f);
    //     yield return leaderboard.FetchTopHighscoresRoutineOrigin();

    //     // yield return new WaitForSeconds(0.3f);
    //     // content_Panel.SetActive(true);
    // }
    #endregion

    IEnumerator SetupScore(string gameName)
    {
        // Skoru gönder ve bekleyelim
        yield return StartCoroutine(GameManager.instance.SubmitScoreRoutine(DataManager.GetScore(gameName)));

        // 0.3 saniye bekle
        yield return new WaitForSeconds(0.3f);

        // Mevcut GameObject'leri yok et
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
        
        leaderBoard_Texts.Clear();

        // Yeniden liderlik tablosunu al ve göster
        yield return leaderboard.FetchTopHighscoresRoutineOrigin();
    }

    public void CloseLeaderboard()
    {
        leaderBoard_Panel.SetActive(false);
    }
}
using TMPro;
using Datas;
using System;
using Utils;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using LootLocker.Requests;
using System.Collections.Generic;
using LootLocker.Extension.DataTypes;

public class MainMenuUI : BaseUI
{
    public static MainMenuUI instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    [SerializeField] UserManager playerManager;
    [SerializeField] LeaderboardProcess leaderboard;

    [SerializeField] TextMeshProUGUI appVersionInfo;
    [SerializeField] Button PlayButton;

    [Header("Leaderboards Elements")]
    [SerializeField] GameObject leaderBoard_Panel;
    [SerializeField] GameObject textObject_Prefab;
    [SerializeField] GameObject content_Panel;
    [SerializeField] GameObject lP_Names;
    [SerializeField] GameObject lP_Scores;
    [SerializeField] Image[] btn_image;

    [Header("Account panel elements")]
    [SerializeField] public TMP_InputField setName_InputField;

    [Header("Panels")]
    [SerializeField] GameObject account_Panel;
    [SerializeField] GameObject games_Panel;

    [SerializeField] GameObject messageImage;

    public List<GameObject> textObjects_name = new List<GameObject>();
    public List<GameObject> textObjects_score = new List<GameObject>();
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
        leaderBoard_Panel.SetActive(false);
        PlayButton.onClick.AddListener(OnButtonClick);
        //ShowInfo();
    }

    private void OnButtonClick()
    {
        games_Panel.SetActive(true);
    }

    private void ShowInfo()
    {
        Debug.LogError($"Data Flappy: {DataManager.GetScore(PrefesKeys.FlappyBird)}");
        Debug.LogError($"Data Dino: {DataManager.GetScore(PrefesKeys.Dino)}");

        if (DataManager.CompareGameState(PrefesKeys.Dino, GameState.open))
        {
            Debug.LogError("Dino");
            leaderBoard_Panel.SetActive(true);
        }
        else if (DataManager.CompareGameState(PrefesKeys.FlappyBird, GameState.open))
        {
            Debug.LogError("Flappy");
            leaderBoard_Panel.SetActive(true);
        }
    }

    public void ShowCurrentUser(LootLockerLeaderboardMember[] members, int i)
    {
        if (UserManager.leaderBoardMembers[i].player.id == members[i].player.id)
        {
            Debug.LogError("Correct id");
            textObjects_name[i].GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0); // red
        }
        // Debug.LogError(textObjectsElements.Equals(name));
    }

    public void PlayGame(int index) // FLappy:1, Dino: 2
    {
        index += GameManager.PreviusGame_Scene_Count;
        m_SceneManager.LoadScene(index);
    }
}
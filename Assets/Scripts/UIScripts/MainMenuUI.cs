using System.Collections.Generic;
using System.Collections;

using Helpers;
using Datas;

using TMPro;
using UnityEngine;
using UnityEngine.UI;

using LootLocker.Requests;
using LootLocker.Extension.DataTypes;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] PlayerManager playerManager;
    [SerializeField] Leaderboard leaderboard;

    [SerializeField] TextMeshProUGUI appVersionInfo;

    [Header("Leaderboards Elements")]
    [SerializeField] GameObject leaderBoard_Panel;
    [SerializeField] GameObject textObject_Prefab;
    [SerializeField] GameObject content_Panel;
    [SerializeField] GameObject lP_Names;
    [SerializeField] GameObject lP_Scores;
    [SerializeField] Image[] btn_image;

    [Header("Account panel elements")]
    [SerializeField] GameObject account_Panel;
    [SerializeField] public TMP_InputField setName_InputField;

    [SerializeField] GameObject messageImage;

    public List<GameObject> textObjects_name = new List<GameObject>();
    public List<GameObject> textObjects_score = new List<GameObject>();
    // public GameObject[] textObjects_name;
    // public GameObject[] textObjects_score;

    // public List<string> leaderBoard_Texts = new List<string>();
    public void GenerateTextField(string value, bool isName)
    {
        GameObject go = Instantiate(textObject_Prefab);
        // GameObject[] temp = {go};
        if (isName)
        {
            textObjects_name.Add(go);
            // for (int i = 0; i < 3; i++)
            // {
            //     GameObject g = go;
            // }
            // textObjects_name = temp;
        }
        else
        {
            textObjects_score.Add(go);
            // textObjects_score = temp;
        }

        go.GetComponent<TextMeshProUGUI>().text = value;
        // leaderBoard_Texts.Add(value);

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
        // leaderBoard_Panel.SetActive(false);

        Debug.LogError($"Data Flappy: {DataManager.GetScore(Constants.FlappyBird)}");
        Debug.LogError($"Data Dino: {DataManager.GetScore(Constants.Dino)}");

        if (PlayerPrefs.GetString("DinoOpen") == "open")
        {
            Debug.LogError("DIno");
            leaderBoard_Panel.SetActive(true);
            // btn_image[0].color = new Color(0, btn_image[0].color.g, btn_image[0].color.b);
            // btn_image[1].color = new Color(255, btn_image[1].color.g, btn_image[1].color.b);
        }
        else if (PlayerPrefs.GetString("FlappyOpen") == "open")
        {
            Debug.LogError("FLappy");
            leaderBoard_Panel.SetActive(true);
            // btn_image[0].color = new Color(255, btn_image[0].color.g, btn_image[0].color.b);
            // btn_image[1].color = new Color(0, btn_image[1].color.g, btn_image[1].color.b);
        }

        // int rs = DataManager.GetScore(Constants.FlappyBird);
        // Debug.LogError(rs);
    }
    // void ChangeColor_Temp(int index, int color)
    // {
    //     btn_image[index].color = new Color(color, btn_image[0].color.g, btn_image[0].color.b);
    //     btn_image[index].color = new Color(color, btn_image[1].color.g, btn_image[1].color.b);
    // }

    #region Comments 1
    // private void Awake()
    // {
    //     //    StartCoroutine(GameManager.instance.SubmitScoreRoutine(0));
    // }

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         leaderBoard_Panel.SetActive(false);
    //     }
    // }
    // private void PrintMembers()
    // {
    //     for (int i = 0; i < textObjects_name.Count; i++)
    //     {
    //         Debug.Log(textObjects_name[i].GetComponent<TextMeshProUGUI>().text);
    //     }
    // }

    // public void ShowCurrentUser(int userIndex, string name)
    // {
    //     textObjects[userIndex].GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0); // red
    //     // Debug.LogError(textObjectsElements.Equals(name));
    //     Debug.Log("");
    // }
    #endregion

    public void ShowCurrentUser(LootLockerLeaderboardMember[] members, int i)
    {
        if (PlayerManager.leaderBoardMembers[i].player.id == members[i].player.id)
        {
            Debug.LogError("Correct id");
            textObjects_name[i].GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0); // red
        }
        // Debug.LogError(textObjectsElements.Equals(name));

    }
    #region Comments
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

    // public void GenerateTextField(string playerName, string playerID)
    // {
    //     GameObject go = Instantiate(textObject_Prefab);
    //     // textObjects_name.Add(go);

    //     // Eğer bu oyuncu şu anki oturumda olan oyuncuysa, adının yanına bir yıldız simgesi ekleyin
    //     if (playerID == SessionManager.PlayerID)
    //     {
    //         playerName += " *"; // Oyuncunun adının yanına yıldız simgesi ekler
    //     }

    //     go.GetComponent<TextMeshProUGUI>().text = playerName;
    //     go.transform.SetParent(leaderBoard_Panel.transform, false);
    // }

    // public void ShowCurrentUser(string userID)
    // {
    //     if (userID == PlayerPrefs.GetString("PlayerName"))
    //         textObjects[0].GetComponent<TextMeshProUGUI>().color = new Color(255, 0, 0); // red
    // }
    #endregion

    //TODO: Add new Button system
    public static int gameIndex;
    public void PlayGame(int index) // FLappy:1, Dino: 2
    {
        gameIndex = index;
        m_SceneManager.LoadScene(index);
    }
    // public void PlayGame(Scenes scene)
    // {
    //     SceneLoader.LoadScene(scene);
    // }

    #region Account panel

    public void OpenAccountPanel()
    {
        account_Panel.SetActive(true);
    }
    public void SetName(TMP_InputField tMP_InputField){
        // Debug.LogError("Salam");        
        string name = tMP_InputField.text;
        
        messageImage.SetActive(true);
        playerManager.SetPlayerName(name);
    }
    public void CloseAccountPanel()
    {
        account_Panel.SetActive(false);
    }

    #endregion Account panel

    #region Leaderboard panel
    public void OpenLeaderboard()
    {
        leaderBoard_Panel.SetActive(true);
    }
    public void ShowGameScore(int index)
    {
        // leaderboard.FetchTopHighscoresRoutineOrigin();        
        // content_Panel.SetActive(true);
        switch (index)
        {
            case 0:
                // //GameManager.instance.SubmitScoreRoutine(DataManager.GetScore(Constants.FlappyBird));
                // // Debug.Log(DataManager.GetScore(Constants.FlappyBird));
                // // DataManager.GetScore(Constants.FlappyBird);
                // //StartCoroutine(GameManager.instance.SubmitScoreRoutine(DataManager.GetScore(Constants.FlappyBird)));

                // btn_image[0].color = new Color(255, btn_image[0].color.g, btn_image[0].color.b);
                // btn_image[1].color = new Color(0, btn_image[1].color.g, btn_image[1].color.b);

                StartCoroutine(SetupScore(Constants.FlappyBird));
                PlayerPrefs.SetString("FlappyOpen", "open");
                m_SceneManager.LoadScene(Scenes.MainMenu);
                break;

            case 1:
                // // GameManager.instance.SubmitScoreRoutine(DataManager.GetScore(Constants.Dino));
                // // Debug.Log(DataManager.GetScore(Constants.Dino));
                // // DataManager.GetScore(Constants.Dino);
                // //StartCoroutine(GameManager.instance.SubmitScoreRoutine(DataManager.GetScore(Constants.Dino)));

                // btn_image[0].color = new Color(0, btn_image[0].color.g, btn_image[0].color.b);
                // btn_image[1].color = new Color(255, btn_image[1].color.g, btn_image[1].color.b);

                StartCoroutine(SetupScore(Constants.Dino));
                PlayerPrefs.SetString("DinoOpen", "open");
                m_SceneManager.LoadScene(Scenes.MainMenu);
                break;
        }
    }
    #region OLD SCORE
    // IEnumerator SetupScore(string gameName)
    // {
    //     StartCoroutine(GameManager.instance.SubmitScoreRoutine(DataManager.GetScore(gameName)));
    //     content_Panel.SetActive(false);

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

    //      yield return new WaitForSeconds(0.3f);
    //      content_Panel.SetActive(true);
    // }
    #endregion

    #region  Old Score 2
    IEnumerator SetupScore(string gameName)
    {
        // content_Panel.SetActive(false);
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

        yield return new WaitForSeconds(0.4f);
        // //leaderBoard_Texts.Clear();

        // content_Panel.SetActive(true);

        yield return leaderboard.FetchTopHighscoresRoutineOrigin();
        // content_Panel.SetActive(true);
    }
    #endregion

    #region SetupScore3 Old SCore

    // IEnumerator SetupScore(string gameName)
    // {
    //     yield return StartCoroutine(GameManager.instance.SubmitScoreRoutine(DataManager.GetScore(gameName)));

    //     yield return new WaitForSeconds(0.3f);

    //     // for (int i = 0; i < textObjects_name.Length; i++)
    //     // {
    //     //     Destroy(textObjects_name[i]);
    //     // }

    //     // yield return new WaitForSeconds(0.3f);
    //     leaderBoard_Panel.SetActive(true);
    //     // yield return leaderboard.FetchTopHighscoresRoutineOrigin();
    // }

    // IEnumerator SetupScore(string gameName)
    // {
    //     // Önce eski skorları temizle
    //     ClearScoreDisplay();
    //     yield return new WaitForSeconds(0.3f);
    //     // Yeni skoru gönder
    //     /*yield return*/
    //     StartCoroutine(GameManager.instance.SubmitScoreRoutine(DataManager.GetScore(gameName)));

    //     // Biraz bekle
    //     yield return new WaitForSeconds(0.3f);

    //     // Yeniden skorları yükle
    //     yield return leaderboard.FetchTopHighscoresRoutineOrigin();
    //     Debug.Log("Fetch");
    // }

    // void ClearScoreDisplay()
    // {
    //     // Text objelerini yok et
    //     foreach (var go in textObjects_name)
    //     {
    //         Destroy(go);
    //     }
    //     textObjects_name.Clear();

    //     foreach (var go in textObjects_score)
    //     {
    //         Destroy(go);
    //     }
    //     textObjects_score.Clear();
    // }
    #endregion


    public void CloseLeaderboard()
    {
        PlayerPrefs.SetString("FlappyOpen", "close");
        PlayerPrefs.SetString("DinoOpen", "close");
        leaderBoard_Panel.SetActive(false);
    }
    #endregion leaderBoard_Panel
}
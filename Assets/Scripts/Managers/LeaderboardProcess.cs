using System.Collections;
using UnityEngine;
using LootLocker.Requests;
using TMPro;
using LootLocker;
using System.Linq;
using Datas;
using Utils;

public class LeaderboardProcess : MonoBehaviour
{
    //int leaderboardKey = 18872;
    string leaderboardKey = "myHighScore1";

    public TextMeshProUGUI playerNames;
    public TextMeshProUGUI playerScores;

    [SerializeField] MainMenuUI mainMenuUI;
    [SerializeField] PlayerManager playerManager;
    public bool originSolution;

    private string playerID;
    public int scoreListCount = 10;

    private void Start()
    {
        //playerID = PlayerPrefs.GetString("PlayerID");
        playerID = DataManager.GetData(PrefesKeys.PlayerID, Type.String);
    }

    public IEnumerator FetchTopHighscoresRoutineOrigin()
    {
        bool done = false;
        //string playerID = PlayerPrefs.GetString("PlayerID");
        string playerID = DataManager.GetData(PrefesKeys.PlayerID);
        LootLockerSDKManager.GetScoreList(leaderboardKey, scoreListCount, 0, (response) =>
        {
            if (response.success)
            {
                string tempPlayerNames = ""; // 1. Ugurlu oldugu halda adlari tutacaq muveqqeti bir string deyisen yaradilir.
                string tempPlayerScores = "";

                LootLockerLeaderboardMember[] members = response.items;
                PlayerManager.leaderBoardMembers = response.items;

                for (int i = 0; i < members.Length; i++) // 3. membersin uzunlugu qeder massiv icinde dovr edirik.
                {
                    tempPlayerNames += members[i].rank + ". ";
                    if (members[i].player.name != "")
                    {
                        tempPlayerNames += members[i].player.name;
                        mainMenuUI.GenerateTextField(tempPlayerNames, true);
                    }
                    else
                    {
                        tempPlayerNames += Constants.Empty_Name_Message;
                        mainMenuUI.GenerateTextField(tempPlayerNames, true);
                    }
                    if (playerID == members[i].player.id.ToString())
                    {
                        mainMenuUI.ShowCurrentUser(members, i);
                    }
                    tempPlayerScores += members[i].score; // + "\n";
                    mainMenuUI.GenerateTextField(tempPlayerScores, false);
                    tempPlayerScores = "";
                    tempPlayerNames = "";
                }
                done = true;
            }
            else
            {
                Debug.Log("Failed" + response.errorData);
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }
}
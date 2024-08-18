using System.Collections;
using UnityEngine;
using LootLocker.Requests;
using TMPro;
using LootLocker;
using System.Linq;
using Datas;
using Helpers;

public class Leaderboard : MonoBehaviour
{
    //int leaderboardKey = 18872;
    string leaderboardKey = "myHighScore1";

    public TextMeshProUGUI playerNames;
    public TextMeshProUGUI playerScores;
    // Start is called before the first frame update 

    [SerializeField] MainMenuUI mainMenuUI;
    [SerializeField] PlayerManager playerManager;
    public bool originSolution;
    // private string playerIDKey = "PlayerID";

    // private string playerID = PlayerPrefs.GetString("PlayerID");
    private string playerID;
    // public LootLockerLeaderboardMember[] leaderBoardMembers;
    // public static bool playerId_true_false;
    private void Start()
    {
        playerID = PlayerPrefs.GetString("PlayerID");
        // GameManager.instance.SubmitScoreRoutine(0);
    }

    // public IEnumerator SubmitScoreRoutine(int scoreToUpload)
    // {
    //     bool done = false;
    //     string playerID = PlayerPrefs.GetString("PlayerID");
    //     LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leaderboardKey, (response) => // add toString()
    //     {
    //         if (response.success)
    //         {
    //             Debug.Log("Successfully uploaded score");
    //             done = true;
    //         }
    //         else
    //         {
    //             Debug.Log("Failed" + response.errorData);
    //             done = true;
    //         }
    //     });
    //     yield return new WaitWhile(() => done == false);
    // }
    // PlayerNames playerNamess;
    // LootLockerGetMemberRankRequest lootLockerGetMemberRankRequest;
    private void Awake()
    {
        //lootLockerGetMemberRankRequest = new LootLockerGetMemberRankRequest();
        //StartCoroutine(SubmitScoreRoutine(11));
    }

    #region ORIGIN SOLUTION
    public IEnumerator FetchTopHighscoresRoutineOrigin()
    {
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");
        LootLockerSDKManager.GetScoreList(leaderboardKey, 10, 0, (response) => // GetScore list
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
                       
                        tempPlayerNames += "Ad mövcud deyil.";
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
    #endregion

    #region MY SOLUTIon
    // public IEnumerator FetchTopHighscoresRoutine()
    // {
    //     bool done = false;
    //     LootLockerSDKManager.GetScoreList(leaderboardKey, 10, 0, (response) => // GetScore list
    //     {
    //         if (response.success)
    //         {
    //             // string tempPlayerNames = "Names\n";
    //             string tempPlayerNames = "";
    //             string tempPlayerScores = "Scores\n";

    //             LootLockerLeaderboardMember[] members = response.items;
    //             // playerManager.leaderBoardMembers = members;
    //             PlayerManager.leaderBoardMembers = members;

    //             for (int i = 0; i < members.Length; i++)
    //             {
    //                 tempPlayerNames += members[i].rank + ". ";
    //                 if (members[i].player.name != "")
    //                 {
    //                     tempPlayerNames += PlayerManager.leaderBoardMembers[i].player.name;
    //                     mainMenuUI.GenerateTextField(tempPlayerNames);
    //                     // if (!string.IsNullOrEmpty(playerID))
    //                     // {
    //                     //     Debug.Log("Player id: " + playerID);
    //                     //     // TODO: Special font
    //                     //     // mainMenuUI.textObjects[i].GetComponent<TextMeshProUGUI>().color = ;
    //                     //     // if (members[i].player.name == PlayerPrefs.GetString("PlayerName"))
    //                     // }
    //                     if (lootLockerGetMemberRankRequest.member_id == playerID)
    //                     {
    //                         mainMenuUI.ShowCurrentUser(i);
    //                     }
    //                     else { Debug.LogError("ID IS NOT EQUAL"); }

    //                     // else
    //                     // {
    //                     //     Debug.Log("Player is not found.");
    //                     //     // TODO: Special error
    //                     // }
    //                     tempPlayerNames = "";
    //                 }
    //                 else
    //                 {
    //                     // tempPlayerNames += members[i].player.id;
    //                     mainMenuUI.GenerateTextField("Name is not found");
    //                 }
    //                 tempPlayerScores += members[i].score + "\n";
    //                 // tempPlayerNames += "\n";
    //             }
    //             // string playerID = PlayerPrefs.GetString("PlayerID");

    //             // if (!string.IsNullOrEmpty(playerID))
    //             // {
    //             //     Debug.Log(": " + playerID);
    //             // }
    //             // else
    //             // {
    //             //     Debug.Log("");
    //             // }
    //             done = true;
    //             // playerNames.text = tempPlayerNames;
    //             playerScores.text = tempPlayerScores;

    //         }
    //         else
    //         {
    //             Debug.Log("Failed" + response.errorData);
    //             done = true;
    //         }
    //     });
    //     yield return new WaitWhile(() => done == false);
    // }
    #endregion

    #region AI SOLUTION
    // public IEnumerator FetchTopHighscoresRoutine()
    // {
    //     bool done = false;
    //     LootLockerSDKManager.GetScoreList(leaderboardKey, 10, 0, (response) =>
    //     {
    //         if (response.success)
    //         {
    //             LootLockerLeaderboardMember[] members = response.items;
    //             for (int i = 0; i < members.Length; i++)
    //             {
    //                 string playerName = members[i].player.name != "" ? members[i].player.name : "Name is not found";
    //                 // mainMenuUI.GenerateTextField(playerName);
    //                 mainMenuUI.GenerateTextField(playerName, PlayerPrefs.GetString("PlayerID"));

    //                 // if (members[i].player.id.ToString() == PlayerPrefs.GetString("PlayerID"))
    //                 // {
    //                 //     mainMenuUI.ShowCurrentUser(i);
    //                 // }
    //             }
    //             playerScores.text = string.Join("\n", members.Select(m => m.score.ToString()).ToArray());
    //         }
    //         else
    //         {
    //             Debug.Log("Failed" + response.errorData);
    //         }
    //         done = true;
    //     });
    //     yield return new WaitWhile(() => done == false);
    // }

    #endregion AI SOLUTION

    // //private void Update()
    // //{
    // //    string memberID = "20";
    // //    string leaderboardKeys = "myHighScore1";
    // //    int score = 400;

    // //    LootLockerSDKManager.SubmitScore(memberID, score, leaderboardKeys, (response) =>
    // //    {
    // //        if (response.statusCode == 200)
    // //        {
    // //            Debug.Log("Successful");
    // //        }
    // //        else
    // //        {
    // //            Debug.Log("failed: " + response.errorData);
    // //        }
    // //    });
    // //}
}
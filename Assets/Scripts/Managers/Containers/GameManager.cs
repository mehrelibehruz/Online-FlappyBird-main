using TMPro;
using Datas;
using Utils;
using UnityEngine;
using System.Collections;
using LootLocker.Requests;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public string AppVersion { get; private set; }
    public const int PreviusGame_Scene_Count = 1;
    public UserManager userManager;

    public LeaderboardProcess leaderboard;
    public static GameManager instance;
    public Scenes scenes;
    public Choice choice;
    public Tags tags;
    public Games currentGame;

    // public int Score { get; set; }
    private void Awake()
    {
        if (instance == null)
            instance = this;
        AppVersion = "Version: " + Application.version;
        leaderboard = Object.FindObjectOfType<LeaderboardProcess>();
        userManager = Object.FindObjectOfType<UserManager>();
    }  

    string leaderboardKey = "myHighScore1";
    public IEnumerator SubmitScoreRoutine(int scoreToUpload)
    {
        bool done = false;
        //string playerID = PlayerPrefs.GetString("PlayerID");
        string playerID = DataManager.GetData(PrefesKeys.PlayerID);

        LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leaderboardKey, (response) => // add toString()
        {
            if (response.success)
            {
                Debug.LogError("Successfully uploaded score" + " " + scoreToUpload);
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

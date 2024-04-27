using LootLocker.Requests;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Leaderboard leaderboard;
    public TMP_InputField playerNameInputfield;

    private string playerIDKey = "PlayerID";
    // [SerializeField] MainMenuUI mainMenuUI;

    // public List<LootLockerLeaderboardMember> leaderBoardMembers = new List<LootLockerLeaderboardMember>();
    public static LootLockerLeaderboardMember[] leaderBoardMembers; // TODO: Transform to PlayerData.cs
    [SerializeField] MainMenuUI mainMenuUI;
    void Start()
    {
        StartCoroutine(SetupRoutine());

        //string playerID = PlayerPrefs.GetString(playerIDKey);

        // if (!string.IsNullOrEmpty(playerID))
        // {
        //     Debug.Log("Player id: " + playerID);
        //     // TODO: Special font
        //     // mainMenuUI.ShowCurrentUser(playerID);
        //     Debug.Log("Salam" + playerID + " " + playerIDKey);
        // }
        // else
        // {
        //     Debug.Log("Player is not found.");
        //     // TODO: Special error
        // }
    }

    public void ChangeName()
    {
        // accountPanel.SetActive(true);
        // oldName.text = leaderboard.playerNames.text;
    }
    public string TempPlayerName;
    public void SetPlayerName()
    {
        LootLockerSDKManager.SetPlayerName(playerNameInputfield.text, (response) =>
        {
            if (response.success)
            {
                // TempPlayerName = playerNameInputfield.text;
                // PlayerPrefs.SetString("PlayerName", TempPlayerName);
                Debug.Log("Succesfully set player name");
            }
            else
            {
                Debug.Log("Could not set player name" + response.errorData);
            }
        });
        // playerNameInputfield.gameObject.SetActive(false); // Go to GameManager
        // changeName.gameObject.SetActive(true);
    }

    IEnumerator SetupRoutine()
    {
        yield return LoginRoutine();

        yield return leaderboard.FetchTopHighscoresRoutineOrigin();
    }

    IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Player was logged in");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log("Could not start session");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }
}

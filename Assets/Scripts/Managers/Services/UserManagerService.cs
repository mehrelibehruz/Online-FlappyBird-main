using TMPro;
using Datas;
using Utils;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using LootLocker.Requests;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl;

public class UserManagerService : MonoBehaviour
{
    [SerializeField] LeaderboardProcessService leaderboard;

    // TODO: Transform to PlayerData.cs  
    public static LootLockerLeaderboardMember[] leaderBoardMembers;


    void Start()
    {
        StartCoroutine(SetupRoutine());
    }

    public void SetName(string name)
    {
        SetPlayerName(name);
    }

    private void SetPlayerName(string playerName)
    {
        if (/*!string.IsNullOrEmpty(playerName) &&*/!CheckUserSameName(playerName))
        {
            LootLockerSDKManager.SetPlayerName(playerName, (response) =>
            {
                if (response.success)
                {
                    DataManager.SetData(PrefesKeys.PlayerName, playerName, Type.String);
                    Debug.LogError("Succesfully set player name");
                }
                else
                {
                    Debug.Log("Could not set player name" + response.errorData);
                }
            });
        }

    }

    IEnumerator SetupRoutine()
    {
        yield return LoginRoutine();

        //yield return leaderboard.FetchTopHighscoresRoutineOrigin();
    }

    IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (response.success)
            {
                Debug.Log("Player was logged in");
                //PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                DataManager.SetData(PrefesKeys.PlayerID, response.player_id, Type.String);
                DataManager.SetData(PrefesKeys.PlayerName, response.player_name, Type.String);
                Debug.Log("Your player name With response: " + response.player_name);
                Debug.Log("Your player name With Data manager: " + DataManager.GetData(PrefesKeys.PlayerName));
                done = true;

                //var lootLockerMessagesResponse = new LootLockerGetMessagesResponse();
                // LootLockerSDKManager.GetMessages((response) =>
                // {
                //     if (response.messages.Length == 0) Debug.Log(response.messages[0].body);
                //     Debug.LogError("Messages length Service: " + response.messages.Length);

                //     //lootLockerMessagesResponse = response;
                //     //string msg = response.messages[0].body.ToString();

                //     LootLockerGMMessage[] messagesResponses = response.messages;

                //     // MainMenuUI.instance.Test_GetMessage(messagesResponses);

                //     //Debug.Log(response.messages[1].body.ToString());
                // });
            }
            else
            {
                Debug.Log("Could not start session");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }


    public bool CheckUserSameName(string newPlayerName)
    {
        string playerID = DataManager.GetData(PrefesKeys.PlayerID);

        LootLockerLeaderboardMember[] members = leaderBoardMembers;

        for (int i = 0; i < members.Length; i++)
        {
            //members[x].player.name = "";            
            if (newPlayerName == members[i].player.name)
            {
                Debug.LogWarning($"Same Name. index:{members[i].player.name}");
                return true;
            }
            Debug.LogWarning(members[i].player.name);

            if (playerID == members[i].player.id.ToString())
            {
            }

        }
        return false;
    }
}

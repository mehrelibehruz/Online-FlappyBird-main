using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using LootLocker.Requests;
using System.Collections.Generic;
using UnityEngine.SocialPlatforms.Impl;
using Datas;
using Utils;

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
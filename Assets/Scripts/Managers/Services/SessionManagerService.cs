using Datas;
using System.Collections;
using UnityEngine;

public class SessionManagerService : MonoBehaviour
{
    public static string PlayerID
    {
        get { return DataManager.GetData(PrefesKeys.PlayerID); }
        private set { DataManager.SetData(PrefesKeys.PlayerID, value, Type.String); }
    }

    public static bool IsLoggedIn
    {
        get { return !string.IsNullOrEmpty(PlayerID); }
    }

    private void Start()
    {
        if (IsLoggedIn)
        {
            Debug.Log("Login success, entering point starting...");
            StartSession(PlayerID);
        }
        else
        {
            Debug.Log("You not login.");
        }
       // StartCoroutine(SetupScore(PrefesKeys.FlappyBird));
    }

    //IEnumerator SetupScore(PrefesKeys gameName)
    //{
    //    yield return new WaitForSeconds(0.1f);
    //    yield return StartCoroutine(GameManager.instance.SubmitScoreRoutine(DataManager.GetScore(gameName)));

    //    yield return new WaitForSeconds(0.4f);
    //    yield return GameManager.instance.leaderboardService.FetchTopHighscoresRoutineOrigin();

    //    Debug.LogError("Session Manager Setup Scope Running..");
    //}

    public static void StartSession(string playerID)
    {
        PlayerID = playerID;
        Debug.LogError("Logged in. Player ID:" + playerID + ", " + "Player Name: " + DataManager.GetData(PrefesKeys.PlayerName, Type.String));
    }

    public static void EndSession()
    {
        PlayerID = string.Empty;
        Debug.Log("Log out.");
    }
}

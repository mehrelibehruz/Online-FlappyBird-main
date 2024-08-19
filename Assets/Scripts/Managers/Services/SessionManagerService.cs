using Datas;
using UnityEngine;

public class SessionManagerService : MonoBehaviour
{
    private const string PlayerIDKey = "PlayerID";

    public static string PlayerID
    {
        get { return DataManager.GetData(PrefesKeys.PlayerID); }
        private set { DataManager.SetData(PrefesKeys.PlayerID, value, Type.String);}      
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
    }

    public static void StartSession(string playerID)
    {
        PlayerID = playerID;
        Debug.Log("Logged in. Player ID: " + playerID);
        Debug.Log("Player Name: " + DataManager.GetData(PrefesKeys.PlayerName, Type.String));
    }

    public static void EndSession()
    {
        PlayerID = string.Empty;
        Debug.Log("Log out.");
    }
}

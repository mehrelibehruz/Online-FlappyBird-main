using Datas;
using UnityEngine;

public class SessionManager : MonoBehaviour
{
    private const string PlayerIDKey = "PlayerID";

    public static string PlayerID
    {
        get { return DataManager.GetData(PrefesKeys.PlayerID); }
        private set { PlayerPrefs.SetString(PlayerIDKey, value);}      
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
        Debug.Log("Oturum başlatildi. Oyuncu ID: " + playerID);
    }

    public static void EndSession()
    {
        PlayerID = string.Empty;
        Debug.Log("Oturum sonlandirildi.");
    }
}

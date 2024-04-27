using UnityEngine;

public class SessionManager : MonoBehaviour
{
    private const string PlayerIDKey = "PlayerID";

    public static string PlayerID
    {
        get { return PlayerPrefs.GetString(PlayerIDKey); }
        private set { PlayerPrefs.SetString(PlayerIDKey, value); }
    }

    public static bool IsLoggedIn
    {
        get { return !string.IsNullOrEmpty(PlayerID); }
    }

    private void Start()
    {
        // Oyun başladığında oturum durumu kontrol edilir
        if (IsLoggedIn)
        {
            Debug.Log("Login success, entering point starting...");
            // Oturum açıksa ve geçerliyse (örneğin, PlayerPrefs'te bir PlayerID varsa), oturum otomatik olarak başlatılır
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

using UnityEngine;

namespace Utils
{
    public class Constants
    {
        public const string PLAYER_ID = "PlayerID";
        public string playerID = PlayerPrefs.GetString("PlayerID");
        public const string FlappyBird = "FlappyBird";
        public const string Dino = "Dino";
        
        public const string LEADERBOARD_KEY = "myHighScore1";

        public const string AccountPanel_PlaceHolder_Text = "   adınızı daxil edin..";
        public const string Empty_Name_Message = "Ad mövcud deyil.";

        //Titles:
        public const string AccountPanel_Title = "Hesab";        
        public const string SetName_Text = "Təyin Et";


        public static void Log(string message, bool isActive)
        {
            Debug.Log(message);
        }        
    }
}

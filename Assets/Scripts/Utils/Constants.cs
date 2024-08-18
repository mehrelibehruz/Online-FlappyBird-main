using UnityEngine;

namespace Helpers
{
    public class Constants
    {
        public const string PLAYER_ID = "PlayerID";
        public string playerID = PlayerPrefs.GetString("PlayerID");
        public const string FlappyBird = "FlappyBird";
        public const string Dino = "Dino";
        
        public const string LEADERBOARD_KEY = "myHighScore1";

        public const string Name_Input_Field_PlaceHolder_TEXT = "adınızı daxil edin..";
        public const string Empty_Name_Message = "Ad mövcud deyil.";
        public static void Log(string message, bool isActive)
        {
            Debug.Log(message);
        }        
    }
}

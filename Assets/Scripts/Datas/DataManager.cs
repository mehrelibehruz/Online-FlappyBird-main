namespace Datas
{
    using UnityEngine;

    public class DataManager //: MonoBehaviour {
    {
        // public static LootLockerLeaderboardMember[] leaderBoardMembers;
        // public static string GetPlayerID()
        // {
        //     string playerID = PlayerPrefs.GetString("PlayerID");
        //     return playerID;
        // }
        // public static bool CheckPlayer(int index)
        // {
        //     // bool check = GetPlayerID() == PlayerManager.leaderBoardMembers[index].player.id.ToString();
        //     string playerID = PlayerPrefs.GetString("PlayerID");
        //     bool check = playerID == PlayerManager.leaderBoardMembers[index].player.id.ToString();
        //     return check;
        // }
        #region Old
        public static void SaveScore(string gameName, int score)
        {
            if (score >= GetScore(gameName)){
                PlayerPrefs.SetInt(gameName, score);
            }
            // gameList.Add(gameName);
        }

        public static int GetScore(string gameName)
        {
            return PlayerPrefs.GetInt(gameName);
        }
        #endregion

        #region New
        public static void SaveScore(PrefesKeys prefesKey, int score)
        {
            if (score >= GetScore(prefesKey))
            {
                PlayerPrefs.SetInt(prefesKey.ToString(), score);
            }
        }
        public static int GetScore(PrefesKeys prefesKey)
        {
            return PlayerPrefs.GetInt(prefesKey.ToString());
        }
        #endregion
        // public static List<string> gameList = new List<string>();
        // public static bool GetGame(string gameName)
        // {
        //     if (gameName == gameList.ToString())
        //     {
        //         return true;
        //     }
        //     return false;
        // }
        // public static bool CheckPlayer(string playerNickName)
        // {
        //     // bool check = GetPlayerID() == PlayerManager.leaderBoardMembers[index].player.id.ToString();
        //     string playerID = PlayerPrefs.GetString("PlayerID");
        //     string playerName = PlayerManager.leaderBoardMembers[0].player.name;
        //     return false;
        // }

        // public static void SaveScore()
        // {
        //     PlayerPrefs.SetInt("", 0);
        // }
    }

    // public struct ScoreSystem
    // {
    //     public string ScoreType { get; set; }
    //     public int Score { get; set; }

    //     public void SaveScore(int score){
    //         PlayerPrefs.SetInt("FlappyBirdScore", score);
    //     }
    //     public int GetScore(){
    //         return PlayerPrefs.GetInt("FlappyBirdScore");
    //     }

    //     private void Awake() {

    //     }
    // }

    // class MainMenu{
    //     public void ChoiceGame(int gameIndex){

    //     }
    // }
    // class FlappyBird{
    //     int curScore;
    //     public void SubmitScore(){
    //         var ScoreSystem = new ScoreSystem();
    //         ScoreSystem.SaveScore(curScore);
    //     }
    // }

}
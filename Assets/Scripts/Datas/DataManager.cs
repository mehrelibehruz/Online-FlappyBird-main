namespace Datas
{
    using UnityEngine;

    public class DataManager //: MonoBehaviour {
    {                    
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

        public static void GameState(PrefesKeys gameName, GameState state)
        {
            PlayerPrefs.SetString(gameName.ToString(), state.ToString());

        }
    }                
}
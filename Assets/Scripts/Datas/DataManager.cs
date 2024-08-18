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

        /// <summary>
        /// 1- key, 2- string or int
        /// </summary>
        /// <param name="prefesKey"></param>
        /// <param name="valueType"></param>
        /// <returns></returns>
        public static string GetPrefes(PrefesKeys prefesKey, Type valueType = Type.String)
        {
            dynamic returnValue;
            if (valueType == Type.String)
            {
                returnValue = PlayerPrefs.GetString(prefesKey.ToString());
            }
            else
            {
                returnValue = PlayerPrefs.GetInt(prefesKey.ToString()).ToString();
            }
            return returnValue;
        }

        public static void SetGameState(PrefesKeys gameName, GameState state)
        {
            PlayerPrefs.SetString(gameName.ToString(), state.ToString());
        }

        /// <summary>
        /// 1- Prefes key, 2- string value
        /// </summary>
        /// <param name="gameName"></param>
        /// <param name="state"></param>
        /// <returns>Current game state open or close</returns>
        public static bool CompareGameState(PrefesKeys gameName, GameState state)
        {
            return PlayerPrefs.GetString(gameName.ToString()) == state.ToString() ? true : false;
        }
    }
}
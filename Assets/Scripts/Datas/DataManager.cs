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
        public static string GetData(PrefesKeys prefesKey, Type valueType = Type.String)
        {
            var returnValue = string.Empty;
            if (valueType == Type.String)
            {
                returnValue = PlayerPrefs.GetString(prefesKey.ToString());
            }
            else if (valueType == Type.Int)
            {
                returnValue = PlayerPrefs.GetInt(prefesKey.ToString()).ToString(); //ConvertType(returnValue);
            }
            else
            {
                returnValue = "Invalid type";
            }
            return returnValue;
        }
        public static void SetData(PrefesKeys prefesKey, object value, Type valueType)
        {
            if (valueType == Type.String) { PlayerPrefs.SetString(prefesKey.ToString(), value.ToString()); }
            else if (valueType == Type.Int) { PlayerPrefs.SetInt(prefesKey.ToString(), System.Convert.ToInt32(value)); }
            else { Debug.LogWarning($"Just problem. value type: {valueType}, value: {value}"); }
        }

        //static int ConvertInt(string value) { return System.Convert.ToInt32(value); }

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
        public static bool CompareGameState(ApplicationState applicationState, int count = 0)
        {
            return PlayerPrefs.GetInt(applicationState.ToString()) == count ? true : false;
        }

        public static void SetState_Application(ApplicationState applicationState, int value)
        {
            PlayerPrefs.SetInt(applicationState.ToString(), value);
        }
        public static int GetState_Application(ApplicationState applicationState)
        {
            return PlayerPrefs.GetInt(applicationState.ToString());
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Helpers
{
    public class m_SceneManager
    {
        public static void LoadScene(Scenes scene)
        {
            SceneManager.LoadScene(scene.ToString());
        }
        public static void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        public static void QuitGame()
        {
            PlayerPrefs.SetString("FlappyOpen", "close");
            PlayerPrefs.SetString("DinoOpen", "close");
            // wait delay
            Application.Quit();
        }
    }
}
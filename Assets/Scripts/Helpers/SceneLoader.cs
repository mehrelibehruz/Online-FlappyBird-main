using Helpers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Helpers
{
    public class SceneLoader : MonoBehaviour
    {
        public static void LoadScene(Scenes scene)
        {
            SceneManager.LoadScene(scene.ToString());
        }
        public static void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;

public class First : MonoBehaviour
{
    public static First INSTANCE;
    
    private void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
        }
        else
        {
            Destroy(INSTANCE);
        }
        DontDestroyOnLoad(gameObject);
    }
    //private void Start()
    //{
    //    Debug.Log("Application Version: " + Application.version);
    //}
    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.Alpha5)) { SceneManager.LoadScene("MainMenu"); }
    //    if(Input.GetKeyDown(KeyCode.Alpha6)) { SceneManager.LoadScene("BoardScene"); }
    //    if(Input.GetKeyDown(KeyCode.Alpha7)) { SceneManager.LoadScene("Game"); }
    //}

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void Register()
    {
        SceneManager.LoadScene("BoardScene");
    }
}

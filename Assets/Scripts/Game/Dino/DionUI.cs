using Helpers;
using TMPro;
using UnityEngine;

public class DionUI : MonoBehaviour
{
    [SerializeField] public GameObject gameOver_panel;
    [SerializeField] TextMeshProUGUI scoreText;

    public void UpdateScore(int getScore)
    {
        scoreText.text = getScore.ToString();
    }
    public /*override*/ void GetButtonIndex(int index)
    {
        switch (index)
        {
            case 0:
                print("Start");
                GameManager.instance.choice = Choice.Start;
                break;
            case 1:
                print("Pause");
                GameManager.instance.choice = Choice.Pause;
                break;
            case 2:
                print("Restart");
                GameManager.instance.choice = Choice.Restart;
                break;
            case 3:
                print("Back");
                GameManager.instance.choice = Choice.Back;
                break;
            case 4:
                print("Quit");
                GameManager.instance.choice = Choice.Quit;
                break;
        }
        Operation_Button(GameManager.instance.choice);
    }
    private void Operation_Button(Choice choice)
    {
        // switch (GameManager.instance.choice)
        switch (choice)
        {
            case Choice.Start:
                break;
            case Choice.Pause:
                break;
            case Choice.Restart:
                m_SceneManager.LoadScene(Scenes.GameDino);
                break;
            case Choice.Back:
                m_SceneManager.LoadScene(Scenes.MainMenu);
                break;
            case Choice.Quit:
                Application.Quit();
                break;
        }
    }

    private void Start()
    {
        gameOver_panel.SetActive(false);
    }

}
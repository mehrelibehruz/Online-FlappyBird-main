using System;
using Utils;
using TMPro;
using UnityEngine;

public class FlappyUI : MonoBehaviour /*UIManager*/
{
    [SerializeField] public GameObject gameOver_panel;
    [SerializeField] TextMeshProUGUI scoreText;

    [Header("Backround Elements")]
    [SerializeField] GameObject backround_image;
    [SerializeField] float backround_moveSpeed;
    [SerializeField] Transform backround_LeftPoint;
    [SerializeField] Transform backround_CenterPoint;

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

    public void UpdateScore(int getScore)
    {
        scoreText.text = getScore.ToString();
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
                m_SceneManager.LoadScene(Scenes.GameFlappyBird);
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
    private void Update()
    {
        backround_image.transform.Translate(Vector2.left * backround_moveSpeed * Time.deltaTime);
        if(backround_image.transform.position.x <= backround_LeftPoint.transform.position.x){
            backround_image.transform.position = backround_CenterPoint.transform.position;
        }
    }
}
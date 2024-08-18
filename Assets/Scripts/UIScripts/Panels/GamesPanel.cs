using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GamesPanel : BasePanel
{
    public List<Button> games;
    [SerializeField] MainMenuUI mainMenuUI;

    public override void InitButtons()
    {
        for (int i = 0; i < games.Count; i++)
        {
            int curr = i;
            games[curr].onClick.AddListener(() => mainMenuUI.PlayGame(curr));
        }
    }
    public override void InitTexts()
    {
       
    }

    private void Start()
    {
        InitButtons();
        InitTexts();
    }

    public override void Close()
    {
        base.Close();
    }
}
using Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AccountPanel : BasePanel
{
    [SerializeField] Button SetNameButton;
    [SerializeField] TextMeshProUGUI PlaceHolder_Text;

    public override void InitButtons()
    {
        CloseButton.onClick.AddListener(Close);
        SetNameButton.onClick.AddListener(SetName);
    }

    public override void InitTexts()
    {
        Title.text = Constants.AccountPanel_Title;
        PlaceHolder_Text.text = Constants.AccountPanel_PlaceHolder_Text;
        SetNameButton.GetComponentInChildren<TextMeshProUGUI>().text = Constants.SetName_Text;
    }
    private void Start()
    {
        InitButtons();
        InitTexts();
    }

    public void OpenAccountPanel()
    {
        //account_Panel.SetActive(true);
    }
    public void SetName(TMP_InputField tMP_InputField)
    {
        string name = tMP_InputField.text;

        //messageImage.SetActive(true);
        //playerManager.SetPlayerName(name);
    }

    private void SetName()
    {
        print("Set");
    }

    public override void Close()
    {
        base.Close();
    }
}
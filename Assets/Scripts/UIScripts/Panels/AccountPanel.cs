using Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using JetBrains.Annotations;

public class AccountPanel : BasePanel
{
    [SerializeField] Button SetNameButton;
    [SerializeField] TextMeshProUGUI PlaceHolder_Text;
    [SerializeField] TextMeshProUGUI WarningMessage_Text;    
    [SerializeField] TMP_InputField SetNameInputField;
    [SerializeField] int CharacterLimit;
    private string UserName;
    public override void InitButtons()
    {
        SetNameButton.onClick.AddListener(OnClickSetName);
        CloseButton.onClick.AddListener(Close);
    }

    public override void InitTexts()
    {
        Title.text = Constants.AccountPanel_Title;
        PlaceHolder_Text.text = Constants.AccountPanel_PlaceHolder_Text;
        WarningMessage_Text.text = Constants.AccountPanel_WarningMessage_Text;
        SetNameButton.GetComponentInChildren<TextMeshProUGUI>().text = Constants.SetName_Text;        
    }
    private void InitInputFields()
    {
        SetNameInputField.onValueChanged.AddListener(CatchInputField);
        SetNameInputField.characterLimit = this.CharacterLimit;
    }
    private void Start()
    {
        InitButtons();
        InitTexts();
        WarningMessage_Text.gameObject.SetActive(false);
        InitInputFields();
        FEATURE_TEST_Text.text = GameManager.instance.FirstTime;
    }

    public void OpenAccountPanel()
    {
        //account_Panel.SetActive(true);
    }    

    private void CatchInputField(string inputText)
    {
        UserName = inputText;      
    }

    private void OnClickSetName()
    {
        if(string.IsNullOrEmpty(UserName) || string.IsNullOrWhiteSpace(UserName))
        {
            WarningMessage_Text.gameObject.SetActive(true);
            return;
        }
        print("check continue");
        GameManager.instance.userManager.SetName(UserName);
    }

    public override void Close()
    {
        base.Close();
    }
}
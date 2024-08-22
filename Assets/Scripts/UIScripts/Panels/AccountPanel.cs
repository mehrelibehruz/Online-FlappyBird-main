using Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;
//Account : authentification : Base

public class AccountPanel : BasePanel
{
    #region  class
    // [SerializeField] Button SetNameButton;
    // [SerializeField] TextMeshProUGUI PlaceHolder_Text;
    // [SerializeField] TextMeshProUGUI WarningMessage_Text;
    // [SerializeField] TMP_InputField SetNameInputField;
    // [SerializeField] int CharacterLimit;
    // private string UserName;
    // public override void InitButtons()
    // {
    //     SetNameButton.onClick.AddListener(OnClickSetName);
    //     CloseButton.onClick.AddListener(Close);
    // }

    // public override void InitTexts()
    // {
    //     Title.text = Constants.AccountPanel_Title;
    //     PlaceHolder_Text.text = Constants.AccountPanel_PlaceHolder_Text;
    //     WarningMessage_Text.text = Constants.AccountPanel_WarningMessage_Text;
    //     SetNameButton.GetComponentInChildren<TextMeshProUGUI>().text = Constants.SetName_Text;
    // }
    // private void InitInputFields()
    // {
    //     SetNameInputField.onValueChanged.AddListener(CatchInputField);
    //     SetNameInputField.characterLimit = this.CharacterLimit;
    // }
    // private void Start()
    // {
    //     InitButtons();
    //     InitTexts();
    //     WarningMessage_Text.gameObject.SetActive(false);
    //     InitInputFields();
    //     FEATURE_TEST_Text.text = GameManager.instance.FirstTime;
    // }

    // public void OpenAccountPanel()
    // {
    //     //account_Panel.SetActive(true);
    // }

    // private void CatchInputField(string inputText)
    // {
    //     UserName = inputText;
    // }

    // private void OnClickSetName()
    // {
    //     if (string.IsNullOrEmpty(UserName) || string.IsNullOrWhiteSpace(UserName))
    //     {
    //         WarningMessage_Text.gameObject.SetActive(true);
    //         return;
    //     }
    //     print("not null or white scpace check success");
    //     GameManager.instance.userManager.SetName(UserName);
    // }
    // void GetPlayerProgression()
    // {
    //     LootLockerSDKManager.GetPlayerProgression("", response =>
    //     {
    //         if (response.success)
    //         {
    //             Debug.Log("The player is currently level" + response.step.ToString());
    //             Debug.Log("The player is points" + response.points.ToString());
    //             Debug.Log("The player is steps" + response.step.ToString());
    //             if (response.next_threshold != null)
    //             {
    //                 Debug.Log("Points needed to reach next level:" + (response.next_threshold - response.points).ToString());
    //             }
    //         }
    //         else
    //         {
    //             Debug.Log("Failed: " + response.errorData);
    //         }
    //     });
    // }


    // public override void Close()
    // {
    //     base.Close();
    // }
    #endregion

    const string first_Trigger_Key = "first_allow_test";
    public void SendedScoreServer()
    {
        LootLockerSDKManager.AddPointsToPlayerProgression(first_Trigger_Key, System.Convert.ToUInt64(1), (response) =>
        {
            if (response.success)
            {
                Debug.Log("Points added to progression");
                // If the player leveled up, the count of awarded_tiers will be greater than 0
                print($"award tiers: {response.awarded_tiers}, next_threshold: {response.next_threshold}, {response.points}, {response.previous_threshold}, {response.step}");
                //
                AText.text = "pre" + response.previous_threshold.ToString();
                BText.text = "next" + response.next_threshold.ToString();
                HelpText1_level.text = "level-tier" + response.step.ToString();
                PointsText.text = "point: " + response.points.ToString();

                if (response.awarded_tiers.Count > 0)
                {
                    Debug.Log("Player leveled up");
                }
            }
            else
            {
                Debug.Log("Error adding points to progression");
            }
        });
    }

    public void GetPlayerProgress()
    {
        LootLockerSDKManager.GetPlayerProgression(first_Trigger_Key, response =>
        {
            if (response.success)
            {
                Debug.Log("The player is currently level" + response.step.ToString());
                if (response.next_threshold != null)
                {
                    AText.text = "pre" + response.previous_threshold.ToString();
                    BText.text = "next" + response.next_threshold.ToString();
                    HelpText1_level.text = "level-tier" + response.step.ToString();
                    PointsText.text = "point: " + response.points.ToString();
                    Debug.Log("Points needed to reach next level:" + (response.next_threshold - response.points).ToString());
                }
            }
            else
            {
                Debug.Log("Failed: " + response.errorData);
            }
        });
    }

    [SerializeField] GameObject CurrPanel;
    [SerializeField] TextMeshProUGUI AText;
    [SerializeField] TextMeshProUGUI BText;
    [SerializeField] TextMeshProUGUI HelpText1_level;
    [SerializeField] TextMeshProUGUI HelpText2;
    [SerializeField] TextMeshProUGUI PointsText;

    [SerializeField] Slider slider;




    public void CLose()
    {
        CurrPanel.SetActive(false);
    }

}
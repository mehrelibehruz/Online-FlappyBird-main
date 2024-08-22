using LootLocker.Requests;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SignUpPanel : BasePanel
{
    [SerializeField] TMP_InputField nickname_InputField;
    [SerializeField] TMP_InputField email_InputField;
    [SerializeField] TMP_InputField password_InputField;
    [SerializeField] Button signUpButton;


    [SerializeField] Toggle rememberMeToggle;
    string newNickName;
    string email;
    string password;

    public override void InitButtons()
    {
        CloseButton.onClick.AddListener(Close);
        signUpButton.onClick.AddListener(SignUp);
    }

    public override void InitTexts()
    {

    }
    private void InitInputFields()
    {
        nickname_InputField.onValueChanged.AddListener(Catch_NickName_InputField);
        email_InputField.onValueChanged.AddListener(Catch_Email_InputField);
        password_InputField.onValueChanged.AddListener(Catch_Password_InputField);
    }

    private int rememberMe;
    private void Start()
    {
        InitButtons();
        InitTexts();
        InitInputFields();
        // rememberMeToggle.onValueChanged.AddListener();
        rememberMe = PlayerPrefs.GetInt("rememberMe", 0);
        if (rememberMe == 0)
        {
            rememberMeToggle.isOn = false;
        }
        else
        {
            rememberMeToggle.isOn = true;
        }

        FEATURE_TEST_Text.text = GameManager.instance.FirstTime;
    }

    public void OpenPanel()
    {
        //panel.SetActive(true);
    }

    private void Catch_NickName_InputField(string inputText)
    {
        newNickName = inputText;
    }
    private void Catch_Email_InputField(string inputText)
    {
        email = inputText;
    }
    private void Catch_Password_InputField(string inputText)
    {
        password = inputText;
    }


    void Error(string error)
    {
        Debug.Log("signUp Error: " + error);
    }

    private void SignUp()
    {
        string newNickName = nickname_InputField.text;
        string email = email_InputField.text;
        string password = password_InputField.text;

        LootLockerSDKManager.WhiteLabelSignUp(email, password, (response) =>
        {
            if (!response.success)
            {
                Error(response.errorData.ToString());
                return;
            }
            else
            {
                // Succesful response
                // Log in player to set name
                // Login the player
                LootLockerSDKManager.WhiteLabelLogin(email, password, false, response =>
                {
                    if (!response.success)
                    {
                        //Error(response.Error);
                        Error(response.errorData.ToString());
                        return;
                    }
                    // Start session
                    LootLockerSDKManager.StartWhiteLabelSession((response) =>
                    {
                        if (!response.success)
                        {
                            //Error(response.Error);
                            Error(response.errorData.ToString());
                            return;
                        }
                        // Set nickname to be public UID if nothing was provided
                        if (newNickName == "")
                        {
                            newNickName = response.public_uid;
                        }
                        // Set new nickname for player
                        LootLockerSDKManager.SetPlayerName(newNickName, (response) =>
                        {
                            if (!response.success)
                            {
                                //Error(response.Error);
                                Error(response.errorData.ToString());
                                return;
                            }

                            // End this session
                            LootLockerSessionRequest sessionRequest = new LootLockerSessionRequest();
                            LootLocker.LootLockerAPIManager.EndSession(sessionRequest, (response) =>
                            {
                                if (!response.success)
                                {
                                    //Error(response.Error);
                                    Error(response.errorData.ToString());
                                    return;
                                }
                                Debug.Log("Account Created");
                                // New user, turn off remember me
                                rememberMeToggle.isOn = false;
                            });
                        });
                    });
                });
            }
        });
    }

    public override void Close()
    {
        base.Close();
    }
}
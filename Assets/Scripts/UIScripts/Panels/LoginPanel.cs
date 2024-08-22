using LootLocker.Requests;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{
    // [SerializeField] TMP_InputField nickname_InputField;
    [SerializeField] TMP_InputField email_InputField;
    [SerializeField] TMP_InputField password_InputField;
    [SerializeField] Button loginButton;


    // [SerializeField] Toggle rememberMeToggle;
    string newNickName;
    string email;
    string password;

    public override void InitButtons()
    {
        CloseButton.onClick.AddListener(Close);
        loginButton.onClick.AddListener(Login);
    }

    public override void InitTexts()
    {

    }
    private void InitInputFields()
    {
        // nickname_InputField.onValueChanged.AddListener(Catch_NickName_InputField);
        email_InputField.onValueChanged.AddListener(Catch_Email_InputField);
        password_InputField.onValueChanged.AddListener(Catch_Password_InputField);
    }

    private int rememberMe;
    private void Start()
    {
        InitButtons();
        InitTexts();
        InitInputFields();

    }

    // private void Catch_NickName_InputField(string inputText)
    // {
    //     newNickName = inputText;
    // }
    private void Catch_Email_InputField(string inputText)
    {
        email = inputText;
    }
    private void Catch_Password_InputField(string inputText)
    {
        password = inputText;
    }


    private void Login()
    {
        // string email = "salam@gmail.com";
        // string password = "12345678";

        LootLockerSDKManager.WhiteLabelLogin(email, password, /*System.Convert.ToBoolean(rememberMe),*/ response =>
        {
            if (!response.success)
            {
                // Error
                // Animate the buttons             
                Debug.Log("error while logging in");
                return;
            }
            else
            {
                Debug.Log("Player was logged in succesfully");
            }

            // Is the account verified?
            if (response.VerifiedAt == null)
            {
                // Stop here if you want to require your players to verify their email before continuing
            }

            LootLockerSDKManager.StartWhiteLabelSession((response) =>
            {
                if (!response.success)
                {
                    // Error
                    // Animate the buttons                    
                    Debug.Log("error starting LootLocker session");
                    return;
                }
                else
                {
                    // Session was succesfully started;
                    // animate the buttons                  
                    Debug.Log("session started successfully");
                    // Write the current players name to the screen
                    // SetPlayerNameToGameScreen();
                }
            });

            //WhiteLoginPanel.SetActive(false);          
        });
    }


    public override void Close()
    {
        base.Close();
    }
}

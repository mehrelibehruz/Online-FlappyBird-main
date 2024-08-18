using TMPro;
using UnityEngine;

public class AccountPanel : MonoBehaviour //BasePanel
{
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
    public void CloseAccountPanel()
    {
        //account_Panel.SetActive(false);
    } 
}
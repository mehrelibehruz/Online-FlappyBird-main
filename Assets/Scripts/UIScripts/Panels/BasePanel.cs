using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BasePanel : BaseUI, I_UI
{
    public string PanelName { get; set; }
    public int PanelID { get; set; }
    public bool IsPanelSpecificScene { get; set; }
    [SerializeField] public TextMeshProUGUI Title;
    [SerializeField] public TextMeshProUGUI FEATURE_TEST_Text;

    [SerializeField] public GameObject Panel;
    //[SerializeField] public Component ProcessClass;

    [SerializeField] public Button CloseButton;
 

    public virtual void Close()
    {
        Panel.gameObject.SetActive(false);
    }

    public virtual void InitButtons()
    {
        
    }

    public virtual void InitTexts()
    {
        
    }
}
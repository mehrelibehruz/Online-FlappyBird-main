using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BasePanel : MonoBehaviour
{
    public string PanelName { get; set; }
    public int PanelID { get; set; }
    public bool IsPanelSpecificScene { get; set; }
    [SerializeField] public TextMeshProUGUI Title;

    [SerializeField] public GameObject Panel;
    //[SerializeField] public Component ProcessClass;

    [SerializeField] public Button CloseButton;

    public abstract void InitButtons();
    public abstract void InitTexts();

    public virtual void Close()
    {
        Panel.SetActive(false);
    }
}
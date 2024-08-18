using UnityEngine;
using UnityEngine.UI;

public abstract class BasePanel : MonoBehaviour
{
    public string PanelName { get; set; }
    public int PanelID { get; set; }
    public bool IsPanelSpecificScene { get; set; }

    [SerializeField] public GameObject Panel;
    //[SerializeField] public Component ProcessClass;

    [SerializeField] public Button CloseButton;

    public abstract void Close();
    //public virtual void Close()
    //{
    //    Panel.SetActive(false);
    //}
}

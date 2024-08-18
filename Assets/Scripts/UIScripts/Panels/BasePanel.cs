using UnityEngine;

public abstract class BasePanel : MonoBehaviour
{
    public string PanelName { get; set; }
    public int PanelID { get; set; }
    public bool IsPanelSpecificScene { get; set; }
}

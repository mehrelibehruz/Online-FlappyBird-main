using TMPro;
using UnityEngine;

public class AutoTextScaleTest : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] GameObject textObject;
    [SerializeField] GameObject panel;
    string[] names = new string[] { "Ehmed", "Memmed", "Zulfiye" };

    private void Start()
    {
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        string namess = " ";

        for (int i = 0; i < names.Length; i++)
        {
            namess += names[i];
            namess += "\n";

            GameObject go = GenerateTextField();
            go.GetComponent<TextMeshProUGUI>().text = names[i];
            go.transform.parent = panel.transform;
            // nameText.text = names[i];
        }
        // }
    }

    private GameObject GenerateTextField()
    {
        GameObject uGUI = Instantiate(textObject);
        return uGUI;
    }
}

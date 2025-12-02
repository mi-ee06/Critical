using UnityEngine;

public class ShowUIWhileTabPressed : MonoBehaviour
{
    public GameObject uiPanel;

    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            uiPanel.SetActive(true);
        }
        else
        {
            uiPanel.SetActive(false);
        }
    }
}

using UnityEngine;

public class ShowUIWhileTabPressed : MonoBehaviour
{
    public bool Openweapon;
    public GameObject uiPanel;

    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            Openweapon = true;
            uiPanel.SetActive(true);
        }
        else
        {
            Openweapon = false;
            uiPanel.SetActive(false);
        }
    }
}

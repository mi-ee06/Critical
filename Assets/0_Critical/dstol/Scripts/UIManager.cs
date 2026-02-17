using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] uiElements;
    [SerializeField] private int[] permenantUiIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ToggleUIElement(int index)
    {
        if (uiElements[index].activeInHierarchy)
        {
            uiElements[index].SetActive(false);
        }
        else
        {
            uiElements[index].SetActive(true);
        }
        for(int i = 0; i < uiElements.Length; i++)
        {
            if(i != index && uiElements[i].activeInHierarchy)
            {
                uiElements[i].SetActive(false);
            }
        }
    }
    public void DisableMenus()
    {
        for(int i = 0; i < uiElements.Length; i++)
        {
            bool active = false;
            for(int j = 0; j < permenantUiIndex.Length; j++)
            {
                if (i == permenantUiIndex[j])
                {
                    active = true;
                    break;
                }
                
            }
           
            uiElements[i].SetActive(active);
        }
    }
    public GameObject[] UIElements
    {
        get { return uiElements; }
    }
}

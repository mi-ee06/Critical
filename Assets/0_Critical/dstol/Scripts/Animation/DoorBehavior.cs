using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public bool closing;
    public bool opening;
    [SerializeField] private Door door;
    [SerializeField] private GameObject button;

    void Awake()
    {
        closing = false;
        opening = false;
        door.InitializeHeight();
    }
    void Start()
    {
        if(button != null)
        {
            button.SetActive(false);
        }
    }
    void Update()
    {
        if(opening)
        {
            door.OpenDoor();
        }
    }
    void OnTriggerStay()
    {
        if (closing || opening) return;
        if(Input.GetKey(KeyCode.E))
        {
            Debug.Log("Interaction Button Pressed");
            if(button!=null)
            {
                button.SetActive(false);
            }
            if(door.Open)
            {
                closing = true;
            }
            if(!door.Open)
            {
                opening = true;
            }
        }
    }
    void OnTriggerEnter()
    {
        Debug.Log("Player Entered Door Trigger");
        if(button != null)
        {
            button.SetActive(true);
            Debug.Log("Displaying Button");
        }
    }
    void OnTriggerExit()
    {
        Debug.Log("Player Left Door Trigger");
        if(button != null)
        {
            button.SetActive(false);
        }
    }
}

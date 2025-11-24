using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public bool closing;
    public bool opening;
    [SerializeField] private Door door;
    [SerializeField] GameObject button;

    void Awake()
    {
        closing = false;
        opening = false;
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
            door.Open();
            if (door.OtherDoor != null)
            {
                door.OtherDoor.Open();
            }
        }
        if(closing)
        {
            door.Close();
            if (door.OtherDoor != null)
            {
                door.OtherDoor.Close();
            }
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
            if(door.Closed)
            {
                opening = true;
            }
            if(!door.Closed)
            {
                closing = true;
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

using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Door door;
    [SerializeField] private bool openTrigger;
    [SerializeField] private bool lockAfterTrigger;
    private void OnTriggerEnter()
    {
        if(openTrigger)
        {
            door.OpenDoor();
        }
        else
        {
            door.CloseDoor();
        }
        if(lockAfterTrigger)
        {
            door.ToBeLocked = true;
        }
    }
}

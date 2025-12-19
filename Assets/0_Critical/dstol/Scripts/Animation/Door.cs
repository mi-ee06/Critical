using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject oppositePosition;
    [SerializeField] private bool locked;
    private bool toBeLocked;
    [SerializeField] private float openSpeed;
    [SerializeField] private float closeSpeed;
    private float openHeight;
    private float closedHeight;
    [SerializeField] private bool open;
    [SerializeField] private DoorBehavior doorBehavior;
    private float originalHeight;

    public void OpenDoor()
    {
        if(locked)
        {
            return;
        }
        transform.position = new Vector3(transform.position.x,
            Mathf.Clamp(transform.position.y + openSpeed * Time.deltaTime, closedHeight, openHeight),
            transform.position.z);
        if(transform.position.y <= openHeight)
        {
            open = true;
            if(toBeLocked)
            {
                locked = true;
            }
        }
    }
    public void CloseDoor()
    {
        if(locked)
        {
            return;
        }
        transform.position = new Vector3(transform.position.x,
            Mathf.Clamp(transform.position.y - closeSpeed * Time.deltaTime, closedHeight, openHeight),
            transform.position.z);
        if(transform.position.y >= closedHeight)
        {
            open = false;
            if(toBeLocked)
            {
                locked = true;
            }
        }
    }
    public void InitializeHeight()
    {
        originalHeight = transform.position.y;
        if(open)
        {
            openHeight = originalHeight;
            closedHeight = oppositePosition.transform.position.y;
        }
        else
        {
            closedHeight = originalHeight;
            openHeight = oppositePosition.transform.position.y;
        }
    }
    public bool Open
    {
        get { return open; }
    }
    public float OpenHeight
    {
        get { return openHeight; }
        set { openHeight = value; }
    }
    public float ClosedHeight
    {
        get { return closedHeight; }
        set { closedHeight = value; }
    }
    public DoorBehavior DoorBehavior
    {
        get { return doorBehavior; }
    }
    public bool ToBeLocked
    {
        get { return toBeLocked; }
        set { toBeLocked = value; }
    }
}

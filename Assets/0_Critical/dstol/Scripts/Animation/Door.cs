using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float minAngle;
    [SerializeField] private float maxAngle;
    [SerializeField] private bool open;
    [SerializeField] private DoorBehavior doorBehavior;
    [SerializeField] private Door otherDoor;

    public void Open()
    {
        if (open) return;
        Vector3 euler = transform.localEulerAngles;
        euler.y += rotationSpeed * Time.deltaTime;
        transform.localEulerAngles = euler;
        ClampRotation();
    }
    public void Close()
    {
        if (!open) return;
        Vector3 euler = transform.localEulerAngles;
        euler.y -= rotationSpeed * Time.deltaTime;
        transform.localEulerAngles = euler;
        ClampRotation();
    }
    private void ClampRotation()
    {
        transform.localEulerAngles = new Vector3(
            transform.localEulerAngles.x,
            Mathf.Clamp(transform.localEulerAngles.y, minAngle, maxAngle),
            transform.localEulerAngles.z
            );
    }
    public bool Closed
    {
        get { return !open; }
    }
    public Door OtherDoor
    {
        get { return otherDoor; }
    }
}

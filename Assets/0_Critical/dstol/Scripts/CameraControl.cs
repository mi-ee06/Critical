using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Vector3 difference;
    [SerializeField] private GameObject focus;

    public void FollowCharacter()
    {
        transform.position = focus.transform.position + difference;
    }
    public void SetDifference()
    {
        difference = transform.position - focus.transform.position;
    }
}

using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public Vector2 minPos;
    public Vector2 maxPos;
    public float smoothSpeed = 0.01f;
    public float roomMoveSpeed = 0.2f;
    bool lockCamera;

    [SerializeField] private OnRoom onRoom;

    public GameObject bossCameraPos;

    private void Start()
    {
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        CheckLock();
        MoveCamera();

    }

    private void CheckLock()
    {
        if (onRoom.OnBossRoom)
        {
            lockCamera = true;
            transform.position = new Vector3(
                Mathf.Lerp(transform.position.x, bossCameraPos.transform.position.x, roomMoveSpeed),
                Mathf.Lerp(transform.position.y, bossCameraPos.transform.position.y, roomMoveSpeed),
                Mathf.Lerp(transform.position.z, bossCameraPos.transform.position.z, roomMoveSpeed)
                );
            return;
        }
        else
        {
            lockCamera = false;
        }
    }

    private void MoveCamera()
    {

        if (lockCamera)
            return;

        Vector3 targetPos = player.position + offset;

        float clampX = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);

        float smoothX = Mathf.Lerp(
            transform.position.x,
            clampX,
            smoothSpeed
        );

        transform.position = new Vector3(
            smoothX,
            transform.position.y,
            transform.position.z
        );
    }
}

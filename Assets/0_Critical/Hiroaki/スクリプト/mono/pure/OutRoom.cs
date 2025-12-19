using UnityEngine;

public class OutRoom : MonoBehaviour
{
    [SerializeField] private OnRoom onRoom;
    private void OnTriggerEnter()
    {
        onRoom.OnBossRoom = false;
    }
}

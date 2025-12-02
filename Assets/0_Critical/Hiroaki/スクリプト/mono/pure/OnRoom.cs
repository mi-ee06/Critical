using UnityEngine;

public class OnRoom : MonoBehaviour
{
    public bool OnBossRoom;
    private void OnTriggerEnter()
    {
        OnBossRoom = true;
    }
}
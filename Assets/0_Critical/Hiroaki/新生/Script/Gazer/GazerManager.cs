using System;
using UnityEngine;

public class GazerManager:MonoBehaviour
{
    public event Action OnDefeated;

    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject gazerPrefab;
    private GameObject gazerInstance;
    private GazerMovement movement;

    public void CreateGazer()
    {
        gazerInstance=Instantiate(gazerPrefab,spawnPoint.position,spawnPoint.rotation);
        movement=gazerInstance.GetComponent<GazerMovement>();
        movement.Defeated += Handler;
    }

    public void StartGazer()
    {

    }

    public void DestroyGazer()
    {
        movement.Defeated -= Handler;
        Destroy(gazerInstance);
    }

    private void Handler()
    {
        OnDefeated?.Invoke();
    }
}

using System;
using UnityEngine;

public class GazerManager:EnemyManagerBase
{
    override public event Action OnDefeated;

    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject gazerPrefab;
    private GameObject gazerInstance;
    private GazerMovement movement;

    override public void CreateEnemy()
    {
        gazerInstance=Instantiate(gazerPrefab,spawnPoint.position,spawnPoint.rotation);
        movement=gazerInstance.GetComponent<GazerMovement>();
        movement.Defeated += Handler;
    }

    public void StartGazer()
    {
        movement.SetCanMove(true);
    }

    override public void DestroyEnemy()
    {
        movement.Defeated -= Handler;
        Destroy(gazerInstance);
    }

    private void Handler()
    {
        OnDefeated?.Invoke();
    }
}

using System;
using UnityEngine;

public class SlimeManager:EnemyManagerBase
{
    //Weaponタグのついたものに当たったら発火する
    override public event Action OnDefeated;

    [SerializeField] private GameObject slime;
    [SerializeField] private Transform spawnPoint;

    private GameObject slimeInstance;
    private SlimeMovement movement;

    private void Start()
    {
        OnDefeated += DestroyEnemy;
    }

    //slimeのゲームオブジェクトを出す
    override public void CreateEnemy()
    {
        slimeInstance = Instantiate(slime, spawnPoint.position, spawnPoint.rotation);
        movement = slimeInstance.GetComponent<SlimeMovement>();
        movement.OnDefeated += Handler;
        movement.SetTrans();
    }

    //slimeを動き出すときに使う
    public void StartSlime()
    {
        movement.StartMoving();
    }

    override public void DestroyEnemy()
    {
        OnDefeated -= Handler;
        Destroy(slimeInstance);
    }

    private void Handler()
    {
        OnDefeated?.Invoke();
    }
}

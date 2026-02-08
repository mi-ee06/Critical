using System;
using UnityEngine;

public class SlimeManager:MonoBehaviour
{
    //Weaponタグのついたものに当たったら発火する
    public event Action OnDefeated;

    [SerializeField] private GameObject slime;
    [SerializeField] private Transform spawnPoint;

    private GameObject slimeInstance;
    private SlimeMovement movement;

    private void Start()
    {
        OnDefeated += DestroySlime;
    }

    //slimeのゲームオブジェクトを出す
    public void CreateSlime()
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

    public void DestroySlime()
    {
        OnDefeated -= Handler;
        Destroy(slimeInstance);
    }

    private void Handler()
    {
        OnDefeated?.Invoke();
    }
}

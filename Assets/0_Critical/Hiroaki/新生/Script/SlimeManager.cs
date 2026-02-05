using System;
using UnityEngine;

public class SlimeManager:MonoBehaviour
{
    //Weaponタグのついたものにいたらと発火する
    public event Action OnDefeated;

    [SerializeField] private GameObject slime;
    [SerializeField] private Transform spawnPoint;

    private GameObject slimeInstance;
    private SlimeMovement movement;

    private void Start()
    {
        CreateSlime();
    }

    //slimeのゲームオブジェクトを出す
    public void CreateSlime()
    {
        slimeInstance = Instantiate(slime, spawnPoint.position, spawnPoint.rotation);
        movement = slimeInstance.GetComponent<SlimeMovement>();
        movement.OnDefeated += () => OnDefeated?.Invoke();
        OnDefeated += DestroySlime;
        movement.SetTrans();
        StartSlime();
    }

    //slimeを動き出すときに使う
    public void StartSlime()
    {
        movement.StartMoving();
    }

    public void DestroySlime()
    {
        Destroy(slimeInstance);
    }
}

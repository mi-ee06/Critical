using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Cysharp.Threading.Tasks;

public class CloudManager:MonoBehaviour
{
    public event Action OnDefeated;

    [SerializeField] Transform player;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject cloudPrefab;
    private GameObject cloudInstance;
    [SerializeField] Transform canvas;
    [SerializeField] Image steamPrefab;
    private Image steamInstance;

    private CloudMovement movement;
    private int clearCount = 0;

    public void CreateCloud()
    {
        cloudInstance = Instantiate(cloudPrefab, spawnPoint);
        movement=cloudInstance.GetComponent<CloudMovement>();
        steamInstance = Instantiate(steamPrefab, canvas);
        movement.CoreDefeated += ()=>Clear();
        movement.SetTrans(player);
    }

    async public UniTask StartCloud()
    {
        movement.SetCloud(false);
        await steamInstance.DOFade(60 / 255f, 1).SetLink(steamInstance.gameObject, LinkBehaviour.KillOnDestroy);
        movement.SetCore(true);
        movement.SetAttack(true);
    }

    private void Clear()
    {
        var token = this.GetCancellationTokenOnDestroy();
        clearCount++;
        var current = steamInstance.color;
        current.a = (60 - clearCount * 12) / 255f;
        steamInstance.color = current;
        if (clearCount == 5)
        {
            movement.SetAttack(false);
            DestroyCloud();
            OnDefeated?.Invoke();
        }
    }

    public  void DestroyCloud()
    {
        Destroy(cloudInstance);
        Destroy(steamInstance.gameObject);
    }
}

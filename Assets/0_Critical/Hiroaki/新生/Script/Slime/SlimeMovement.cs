using System;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    public event Action OnDefeated;

    [SerializeField] private SlimeAnimePlayer animePlayer;
    [SerializeField] private sinsei.SlimeCore core;

    private void Start()
    {
        core.OnTouched += Defeat;
        animePlayer.UpdateDirection();
    }

    public void SetTrans()
    {
        animePlayer.SetTrans(transform);
    }

    public void StartMoving()
    {
        animePlayer.StartRush();
    }

    private void Defeat()
    {
        OnDefeated?.Invoke();
    }
}

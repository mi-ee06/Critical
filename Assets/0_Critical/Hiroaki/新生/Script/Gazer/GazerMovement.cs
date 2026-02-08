using System;
using UnityEngine;

public class GazerMovement:MonoBehaviour
{
    public event Action Defeated;

    [SerializeField] private GazerCore core;

    private bool canMove = false;

    private void Start()
    {
        core.OnTouched += Handler;
    }

    private void Update()
    {
        if (!canMove) return;
    }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }
    private void Handler()
    {
        Defeated?.Invoke();
    }
}

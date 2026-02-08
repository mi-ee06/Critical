using System;
using UnityEngine;

public class GazerMovement:MonoBehaviour
{
    public event Action Defeated;

    [SerializeField] private GazerCore core;

    private void Start()
    {
        core.OnTouched += Handler;
    }

    private void Handler()
    {
        Defeated?.Invoke();
    }
}

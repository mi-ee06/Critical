using System;
using UnityEngine;

public class GazerCore:MonoBehaviour
{
    public event Action OnTouched;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            OnTouched?.Invoke();
        }
    }
}

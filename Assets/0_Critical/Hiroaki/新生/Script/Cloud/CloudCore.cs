using System;
using UnityEngine;

public class CloudCore:MonoBehaviour
{
    public event Action OnTouched;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            OnTouched?.Invoke();
            gameObject.SetActive(false);
        }
    }
}

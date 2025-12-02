using System;
using UnityEngine;

public class SlimeCore : MonoBehaviour
{
    public Action defeat;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            defeat.Invoke();
        }
    }
}

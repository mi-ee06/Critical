using System;
using UnityEngine;
namespace sinsei
{
    public class SlimeCore:MonoBehaviour
    {
        public event Action OnTouched;

        //Weaponタグのついたオブジェクトに触れたら発火
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Weapon"))
            {
                OnTouched?.Invoke();
            }
        }
    }
}

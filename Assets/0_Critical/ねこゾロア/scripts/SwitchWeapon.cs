using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    void Start()
    {
        

    }

    void Update()
    {
       
        // Tab�����Ȃ��畐�킫�肩��
        if (Input.GetKey(KeyCode.Tab))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) inventory.switchWeapon(0);
            if (Input.GetKeyDown(KeyCode.Alpha2)) inventory.switchWeapon(1);
            if (Input.GetKeyDown(KeyCode.Alpha3)) inventory.switchWeapon(2);
        }
    }
}
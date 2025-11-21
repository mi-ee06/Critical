using UnityEngine;

public class Player : MonoBehaviour
{
    private Inventory inventory;

    void Start()
    {
        IWeapon dagger = new Dagger();
        IWeapon sword = new Sword();
        IWeapon ax = new Ax();
        inventory = new Inventory(dagger, sword, ax);

    }

    void Update()
    {
       
        // ShiftÇ®ÇµÇ»Ç™ÇÁïêäÌÇ´ÇËÇ©Ç¶
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) inventory.switchWeapon(0);
            if (Input.GetKeyDown(KeyCode.Alpha2)) inventory.switchWeapon(1);
            if (Input.GetKeyDown(KeyCode.Alpha3)) inventory.switchWeapon(2);
        }
    }
}
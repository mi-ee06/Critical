using UnityEngine;

public class Sword:IWeapon
{
    public override void Attack()
    {
        Debug.Log("attacked with a sword!");
    }
}

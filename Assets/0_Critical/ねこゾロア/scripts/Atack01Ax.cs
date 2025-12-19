using UnityEngine;

public class Ax: IWeapon
{
    public override void Attack()
    {
        Debug.Log("Attacked with an ax!");
    }
}

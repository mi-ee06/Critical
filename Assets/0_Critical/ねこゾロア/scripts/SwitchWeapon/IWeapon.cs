using UnityEngine;

public abstract class IWeapon
{
    public float     attackTime;
    public bool      canAttack;
    public string    attackAnimation;

    public abstract void Attack();
}

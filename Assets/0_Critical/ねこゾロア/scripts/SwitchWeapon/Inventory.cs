using UnityEngine;
using System.Collections.Generic;

public class Inventory
{
    [SerializeField] private KillEnemyTrigger killEnemyTrigger;
    [SerializeField] private Character owner;
    private IWeapon currentWeapon;
    private List<IWeapon> IWeapons = new List<IWeapon>();

    public IWeapon CurrentWeapon => currentWeapon;

    public Inventory(IWeapon daggerweapon,IWeapon swordweapon,IWeapon axeweapon) { 
        currentWeapon = swordweapon;
        IWeapons.Add(daggerweapon);
        IWeapons.Add(swordweapon);
        IWeapons.Add(axeweapon);
    }

    public void Attack()
    {
        if (!currentWeapon.canAttack) return;

        currentWeapon.canAttack = false;
        killEnemyTrigger.gameObject.SetActive(true);
        currentWeapon.Attack();
        owner.Animator.Play(currentWeapon.attackAnimation);

    }

    public void switchWeapon(int number)
    {
        currentWeapon = IWeapons[number];
    }
}

using UnityEngine;
using System.Collections.Generic;

public class Inventory
{
    private IWeapon currentWeapon;
    private List<IWeapon> IWeapons = new List<IWeapon>();

    public IWeapon CurrentWeapon => currentWeapon;

    public Inventory(IWeapon daggerweapon,IWeapon swordweapon,IWeapon axweapon) { 
        currentWeapon = swordweapon;
        IWeapons.Add(daggerweapon);
        IWeapons.Add(swordweapon);
        IWeapons.Add(axweapon);
    }
    public void Attack()
    {
        currentWeapon.Attack();
    }
    public void switchWeapon(int number)
    {

        currentWeapon = IWeapons[number];
      
    }
}

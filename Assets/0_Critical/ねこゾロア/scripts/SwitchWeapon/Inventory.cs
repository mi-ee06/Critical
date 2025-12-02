using UnityEngine;
using System.Collections.Generic;

public class Inventory
{
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
        currentWeapon.Attack();
    }
    public void switchWeapon(int number)
    {

        currentWeapon = IWeapons[number];
      
    }

    public IWeapon CurrentWeapon
    {
        get { return currentWeapon; }
    }
}

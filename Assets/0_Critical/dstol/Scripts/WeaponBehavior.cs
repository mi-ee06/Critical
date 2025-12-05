using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    private void Start()
    {
        inventory.CurrentWeapon.canAttack = true;
    }

    private void Update()
    {
        HandleInput();
    }

    public void HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Attack();
        }
    }

    public void Attack()
    {
        inventory.Attack();

        Invoke("ResetAttackCooldown", inventory.CurrentWeapon.attackTime);
    }

    public void ResetAttackCooldown()
    {
        inventory.CurrentWeapon.canAttack = true;
    }
}

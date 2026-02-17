using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject killEnemyTrigger;
    [SerializeField] private Character owner;
    private IWeapon currentWeapon;
    private float timeOfLastAttack;
    [SerializeField] private List<IWeapon> IWeapons = new List<IWeapon>();
    private Animator animator;

    public IWeapon CurrentWeapon => currentWeapon;

    void Start()
    {
        if (IWeapons[0] == null)
        {
            currentWeapon = null;
            return;
        }
        currentWeapon = IWeapons[0];
        animator = owner.Animator;
        switchWeapon(0);
    }

    public void DelayedAttack()
    {
        animator.Play("Attacking");
        animator.SetBool("Attacking", true);
        Invoke("Attack", currentWeapon == null ? 0.3f : currentWeapon.attackDelay);
    }

    public void Attack()
    {
        if (currentWeapon == null || !CanAttack()) return;

        timeOfLastAttack = Time.time;
        killEnemyTrigger.SetActive(true);

        Invoke("StopAttack", currentWeapon.attackTime);
    }

    public bool CanAttack()
    {
        if (currentWeapon == null) return false;
        float attackTime = currentWeapon.attackTime;
        if (Time.time - timeOfLastAttack < attackTime) return false;
        return true;
    }

    public void StopAttack()
    {
        animator.SetBool("Attacking", false);
        killEnemyTrigger.SetActive(false);
    }

    public void switchWeapon(int number)
    {
        currentWeapon = IWeapons[number];
        killEnemyTrigger.transform.localScale = new Vector3(currentWeapon.reach, killEnemyTrigger.transform.localScale.y, killEnemyTrigger.transform.localScale.z);
        killEnemyTrigger.transform.position = new Vector3(transform.position.x + currentWeapon.reach / 2, killEnemyTrigger.transform.position.y, killEnemyTrigger.transform.position.z);
    }

    public GameObject KillEnemyTrigger
    {
        get { return killEnemyTrigger; }
    }
}

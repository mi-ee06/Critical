using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameManager gameManager;

    [SerializeField] private bool alive;
    [SerializeField] private bool hostile;
    private Vector3 startPosition;

    [SerializeField] private Movement characterMovement;
    [SerializeField] private bool isPlayer;
    /*
     * [SerializeField] private Weapon[] weapons
     * [SerializeField] private Weapon activeWeapon;
     * [SerializeField] private Skill[] skills;
     * [SerializeField] private Skill activeSkill;
     */
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Die()
    {
        if(isPlayer && alive)
        {
            Debug.Log("Death method called");
            alive = false;
            animator.SetBool("Alive", false);
            Invoke("ResetDeathAnimation", 0.1f);
            Invoke("GameOverScreen", 3f);
            characterMovement.Rb.linearVelocity = new Vector3(0f, characterMovement.Rb.linearVelocity.y, 0f);
        }
        else　if(!isPlayer) { Destroy(this.gameObject); }
    }
    public GameManager GameManager
    {
        get { return gameManager; }
    }
    public bool Alive
    {
        get { return alive; }
        set { alive = value; }
    }
    public Movement CharacterMovement
    {
        get { return characterMovement; }
    }
    public bool IsPlayer
    {
        get { return isPlayer; }
    }
    public Vector3 StartPosition
    {
        get { return startPosition; }
        set { startPosition = value; }
    }
    public Animator Animator
    {
        get { return animator; }
    }
    public void ResetToStart()
    {
        transform.position = startPosition;
        alive = true;
        gameManager.UIManager.DisableMenus();
        animator.SetBool("Reset", true);
        Invoke("ResetReset", 1f);
    }
    public void GameOverScreen()
    {
        Debug.Log("Displaying Game Over Screen");
        gameManager.GameOver();
    }
    public void ResetDeathAnimation()
    {
        Debug.Log("Stopping animations");
        animator.SetBool("Alive", true);
    }
    public void ResetReset()
    {
        animator.SetBool("Reset", false);
    }
}

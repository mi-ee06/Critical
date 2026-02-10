using UnityEngine;

public class CreateEnemy:MonoBehaviour
{
    [SerializeField] private EnemyManagerBase enemyManager;
    private bool isCreated = false;

    public void Start()
    {
        enemyManager.OnDefeated += Handler;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isCreated)
            {
                enemyManager.DestroyEnemy();
                isCreated = false;
            }
            enemyManager.CreateEnemy();
            isCreated = true;
        }
    }
    public void Handler()
    {
        isCreated = false;
    }
}

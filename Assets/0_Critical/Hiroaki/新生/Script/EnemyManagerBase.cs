using System;
using UnityEngine;

public abstract class EnemyManagerBase:MonoBehaviour
{
    abstract public event Action OnDefeated;

    abstract public void CreateEnemy();
    abstract public void DestroyEnemy();
}

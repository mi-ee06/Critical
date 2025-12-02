using UnityEngine;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine.UIElements;

public class EnemyDetector : MonoBehaviour
{
    private int enemyCount;
    private HashSet<GameObject> enemies = new HashSet<GameObject>();
    private bool clearing;

    [SerializeField] private Door linkedDoor;
    [SerializeField] private BoxCollider box;

    void Awake()
    {
        enemyCount = 0;
        clearing = false;
    }

    void Start()
    {
        Invoke("StartClearNulls", 3f);
    }

    void Update()
    {
        DetectObjects();
        ClearNulls();
    }

    private void DetectObjects()
    {
        int enemyLayers = 1 << 7;
        var hits = Physics.OverlapBox(
            transform.TransformPoint(box.center),
            box.size * 0.5f,
            transform.rotation,
            enemyLayers,
            QueryTriggerInteraction.Collide
        );

        enemies.Clear();
        foreach (var hit in hits)
        {
            if (hit && hit.gameObject != this.gameObject)
            {
                enemies.Add(hit.gameObject);
            }
        }
    }

    private void ClearNulls()
    {
        if (!clearing) return;
        enemies.RemoveWhere(obj => obj == null);
        enemyCount = enemies.Count;

        if(enemyCount == 0)
        {
            linkedDoor.OpenDoor();
        }
    }
    public void StartClearNulls()
    {
        clearing = true;
    }
}

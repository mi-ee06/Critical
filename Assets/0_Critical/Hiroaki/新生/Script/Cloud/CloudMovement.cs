using System.Collections.Generic;
using System;
using UnityEngine;

public class CloudMovement:MonoBehaviour
{
    public event Action CoreDefeated;

    [SerializeField] private GameObject cloud;
    [SerializeField] private GameObject cores;
    [SerializeField] private List<CloudCore> cloudCores;
    [SerializeField] private GameObject attack;
    [SerializeField] private float speed;

    private bool canAttack=false;
    private Transform player;

    private void Start()
    {
        foreach(var core in cloudCores)
        {
            core.OnTouched += Handler;
        }
    }

    private void Update()
    {
        if (!canAttack) return;

        Vector3 current = attack.transform.position;
        Vector3 target = player.position;

        attack.transform.position = Vector3.MoveTowards(
            current,
            target,
            speed * Time.deltaTime);
    }

    public void SetCloud(bool value)
    {
        cloud.SetActive(value);
    }
    public void SetCore(bool value)
    {
        cores.SetActive(value);
    }

    public void SetAttack(bool value)
    {
        canAttack = value;
        attack.SetActive(value);
    }

    public void SetTrans(Transform player)
    {
        this.player=player;
    }

    private void Handler()
    {
        CoreDefeated?.Invoke();
    }
}

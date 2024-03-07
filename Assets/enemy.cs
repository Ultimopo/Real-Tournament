using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public Transform target;

    Health health;
    NavMeshAgent agent;
    int RNGAmmo;
    public GameObject ammodrop;
    bool hasDied = false;

    void Start()
    {
        health = GetComponent<Health>();
        agent = GetComponent<NavMeshAgent>();
        if (!target) target = GameObject.FindWithTag("Player").transform;
    }


    void Update()
    {
        RNGAmmo = Random.Range(1, 4);
        print(RNGAmmo);
        agent.destination = target.position;
    }

    public void SpawnAmmo()
    {

            if (!hasDied || RNGAmmo == 3)
            {
                Instantiate(ammodrop, transform.position, Quaternion.identity);
                hasDied = true;
            }
    }

}

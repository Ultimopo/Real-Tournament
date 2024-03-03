using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public Transform target;

    Health health;
    NavMeshAgent agent;


    void Start()
    {
        health = GetComponent<Health>();
        agent = GetComponent<NavMeshAgent>();
        if (!target) target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        agent.destination = target.position;
    }


}

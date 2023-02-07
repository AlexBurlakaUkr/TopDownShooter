using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public float startWaitTime;
    public Transform[] moveSpots;
    private NavMeshAgent agent;
    protected Transform player;
    protected float chaseRange;

    private void Start()
    {
        agent = transform.GetComponent<NavMeshAgent>();
        agent.SetDestination(moveSpots[0].position);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        chaseRange = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyParametrs>().chaseRange;
    }
    private void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
            agent.SetDestination(moveSpots[Random.Range(0, moveSpots.Length)].position);

        float distance = Vector3.Distance(agent.transform.position, player.transform.position);

        if (distance < chaseRange && distance >= 2f)
        {
            agent.SetDestination(player.position);
        }


    }
}

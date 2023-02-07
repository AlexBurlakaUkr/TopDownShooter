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
    //protected float normalEnemySpeed;

    private void Start()
    {
        agent = transform.GetComponent<NavMeshAgent>();
        agent.SetDestination(moveSpots[0].position);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        chaseRange = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyParametrs>().chaseRange;
        //normalEnemySpeed = transform.GetComponent<NavMeshAgent>().speed;
    }
    private void Update()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
            agent.SetDestination(moveSpots[Random.Range(0, moveSpots.Length)].position);

        float distance = Vector3.Distance(agent.transform.position, player.transform.position);
        Debug.Log(distance);

        if (distance < chaseRange)
        {
            agent.SetDestination(player.position);
        }


    }
}

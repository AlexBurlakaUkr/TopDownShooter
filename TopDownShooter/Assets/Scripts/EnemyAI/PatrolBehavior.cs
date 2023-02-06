using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehavior : StateMachineBehaviour
{
    List<Transform> points = new List<Transform>();
    NavMeshAgent agent;
    protected Transform player;
    protected float chaseRange;
    private string pointListName;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        pointListName = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyParametrs>().pointListName;
        Transform pointsObject = GameObject.FindGameObjectWithTag(pointListName).transform;
        foreach(Transform t in pointsObject)
            points.Add(t);
        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(points[0].position);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        chaseRange = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyParametrs>().chaseRange;

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
            agent.SetDestination(points[Random.Range(0, points.Count)].position);

        float distance = Vector3.Distance(animator.transform.position, player.transform.position);
        if (distance < chaseRange)
            animator.SetBool("isChasing", true);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }
}

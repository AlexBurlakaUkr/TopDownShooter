using UnityEngine;
using UnityEngine.AI;

public class ChaseBehaviour : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;
    float attackRange;
    float chaseRange;
    float normalEnemySpeed;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        normalEnemySpeed = animator.GetComponent<NavMeshAgent>().speed;
        agent.speed = normalEnemySpeed * 1.5f;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        attackRange = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyParametrs>().attackRange;
        chaseRange = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyParametrs>().chaseRange;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.position);
        float distance = Vector3.Distance(animator.transform.position, player.position);

        if (distance < attackRange)
            animator.SetBool("isAttack", true);

        if (distance > chaseRange)
            animator.SetBool("isChasing", false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
        agent.speed = normalEnemySpeed;
    }
}

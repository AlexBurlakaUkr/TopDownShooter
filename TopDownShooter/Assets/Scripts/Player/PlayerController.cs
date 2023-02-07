using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerMoveSpeed;
    [SerializeField] internal float attackRadius;
    [SerializeField] private Image radiusVisualizator;
    [SerializeField] private VariableJoystick joystick;
    [SerializeField] private HealthBar healthBar;

    private Animator playerAnimator;
    private Rigidbody playerRigitbody;


    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigitbody = GetComponent<Rigidbody>();
        radiusVisualizator.rectTransform.localScale = new Vector3(attackRadius, attackRadius, attackRadius) * 2;
    }
    private void Update()
    {
        GetPlayerAnamation();
    }
    private void FixedUpdate()
    {
        GetPlayerMove();
    }
    private void GetPlayerMove()
    {
        playerRigitbody.velocity = new Vector3(joystick.Horizontal * playerMoveSpeed,
                    playerRigitbody.velocity.y, joystick.Vertical * playerMoveSpeed);

        GetLookRotation();
    }

    private void GetPlayerAnamation()
    {
        playerAnimator.SetFloat("Move", Mathf.Max(Mathf.Abs(joystick.Horizontal), Mathf.Abs(joystick.Vertical)));
    }

    private void GetLookRotation()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0) transform.rotation = Quaternion.LookRotation(playerRigitbody.velocity);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("EnemyContact");
            healthBar.HP -= collision.gameObject.GetComponent<EnemyParametrs>().enemyDamage;
            RestrictionForHP();
        }
    }
    private void RestrictionForHP()
    {
        if (healthBar.HP <= 0)
        {
            healthBar.HP = 0;
            GlobalEventManager.SendPlayerKill();
            playerAnimator.SetTrigger("DieP");
        }

    }
    //void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.white;
    //    Gizmos.DrawWireSphere(transform.position, attackRadius);
    //}
}

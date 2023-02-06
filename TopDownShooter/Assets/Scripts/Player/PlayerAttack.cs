using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    private string enemyListName = "Enemy";
    private string animationCommand = "Fire";
    private SphereCollider trigerCollider;
    protected Animator animator;
    [SerializeField] internal bool isGetKey = false;

    private void Start()
    {
        trigerCollider = GetComponent<SphereCollider>();
        trigerCollider.radius = GetComponent<PlayerController>().attackRadius * 1.25f;
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(enemyListName))
        {
            GlobalEventManager.SendWeaponFire();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(enemyListName))
        {
            transform.LookAt(other.gameObject.transform.position);
            animator.SetBool(animationCommand, true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(enemyListName))
        {
            Debug.Log("StopAttack");
            animator.SetBool(animationCommand, false);
            GlobalEventManager.SendStopWeaponFire();
        }
    }
}

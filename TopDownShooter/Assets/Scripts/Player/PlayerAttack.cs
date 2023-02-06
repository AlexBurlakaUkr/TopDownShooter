using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public List<Transform> enemys = new List<Transform>();
    private string enemyListName = "Enemies";
    public float attackRadius;
    protected Animator animator;
    [SerializeField] internal bool isGetKey = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
        Transform enemysObject = GameObject.FindGameObjectWithTag(enemyListName).transform;
        foreach (Transform t in enemysObject)
            enemys.Add(t);
    }
    private void Update()
    {
        foreach (Transform enemy in enemys)
        {
            float distance = Vector3.Distance(enemy.position, transform.position);
            if (distance < attackRadius) animator.SetBool("Fire", true);
            //if (distance > attackRadius) animator.SetBool("Fire", false);
        }

    }
}

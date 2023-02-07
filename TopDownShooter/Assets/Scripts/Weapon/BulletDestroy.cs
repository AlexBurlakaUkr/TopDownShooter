using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    [SerializeField] internal float bulletAttackPower;
    [SerializeField] internal ParticleSystem wallHit;
    [SerializeField] internal ParticleSystem enemyHit;
    //private float attackRadius = 3;
    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Walls"))
        {
            wallHit.Play();
            Destroy(gameObject, 0.7f);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyHit.Play();
        }
        if (collision.gameObject.transform.position.z >= 6) Destroy(gameObject);
    }
}

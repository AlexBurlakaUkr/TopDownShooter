using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    [SerializeField] internal float bulletAttackPower;
    //private float attackRadius = 3;
    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Walls"))
        {
            Destroy(gameObject);
            Debug.Log("Shot Walls");
        }
        if (collision.gameObject.transform.position.z >= 6) Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParametrs : MonoBehaviour
{
    [SerializeField] internal float attackRange;
    [SerializeField] internal float chaseRange;
    [SerializeField] internal string pointListName;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Transform coinPrefab;
    [SerializeField] private Animator playerAnimator;
    private string animationCommand = "Fire";
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            healthBar.HP -= collision.gameObject.GetComponent<BulletDestroy>().bulletAttackPower;
            RestrictionForHP();
            Debug.Log("Shot Enemy");
        }
    }
    private void RestrictionForHP()
    {
        if (healthBar.HP <= 0)
        {
            healthBar.HP = 0;
            //GlobalEventManager.SendPlayerDeath();
            GlobalEventManager.SendStopWeaponFire();
            playerAnimator.SetBool(animationCommand, false);
            gameObject.SetActive(false);
            Instantiate(coinPrefab,transform.position + new Vector3(0,1.1f,0),Quaternion.identity);

        }

    }
}

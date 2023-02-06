using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private bool activated = false;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] internal string weaponName;
    [SerializeField] internal Rigidbody bulletPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float fireInterval = 0.3f;
    private void Start()
    {
        GlobalEventManager.OnStopWeaponFire.AddListener(GetStopWeaponFire);
        GlobalEventManager.OnWeaponFire.AddListener(GetWeaponFire);
    }
    public void GetActiveWeapon()
    {
        activated = !activated;
        playerAnimator.SetBool(weaponName, activated);
        transform.gameObject.SetActive(activated);
    }
    public void GetWeaponFire()
    {
        InvokeRepeating(nameof(GetShot), 0, fireInterval);
    }
    public void GetShot()
    {
        var bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        bullet.AddRelativeForce(Vector3.forward * bulletSpeed);
    }
    private void GetStopWeaponFire()
    {
        CancelInvoke();
    }


}

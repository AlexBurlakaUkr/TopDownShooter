using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] internal Rigidbody bulletPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float fireInterval = 0.3f;
    private void Start()
    {
        GlobalEventManager.OnStopWeaponFire.AddListener(GetStopWeaponFire);
        GlobalEventManager.OnWeaponFire.AddListener(GetWeaponFire);
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

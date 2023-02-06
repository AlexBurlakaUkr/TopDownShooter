using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private bool activated = false;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] internal string weaponName;

    public void GetActiveWeapon()
    {
        activated = !activated;
        playerAnimator.SetBool(weaponName, activated);
        transform.gameObject.SetActive(activated);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GunButton : MonoBehaviour
{
    [SerializeField] private Weapon gun;
    [SerializeField] private Weapon shotGun;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] internal string gunName = "Gun";
    [SerializeField] internal string shotGunName = "GunShot";
    [SerializeField] internal Transform shotGunButton;
    private bool activated = true;
    private Color imageGunColor;
    private void Start()
    {
        imageGunColor = GetComponent<Image>().color;
    }
    public void GetClick()
    {
        playerAnimator.SetBool(shotGunName, !activated);
        shotGun.gameObject.SetActive(!activated);
        playerAnimator.SetBool(gunName, activated);
        gun.gameObject.SetActive(activated);
        transform.GetComponent<Button>().enabled = false;
        transform.GetComponent<Image>().color = Color.black;
        shotGunButton.GetComponent<Button>().enabled = true;
        shotGunButton.GetComponent<Image>().color = imageGunColor;
    }
}

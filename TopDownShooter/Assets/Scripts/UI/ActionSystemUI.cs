using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSystemUI : MonoBehaviour
{
    [SerializeField] private Transform weaponButton;
    [SerializeField] private List<Weapon> weapons = new List<Weapon>();
    private void Start()
    {
        foreach (var weapon in weapons)
        {
            Transform actionButtonTransform = Instantiate(weaponButton, transform);
            ActionButtonUI actionButtonUI = actionButtonTransform.GetComponent<ActionButtonUI>();
            actionButtonUI.SetButtonName(weapon.weaponName, weapon.GetActiveWeapon);
        }
    }
}

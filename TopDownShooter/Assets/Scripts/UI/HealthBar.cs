using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private float enemyHealth = 10f;
    private Image healthBarImage;
    internal float HP;
    private void Start()
    {
        healthBarImage = GetComponent<Image>();
        HP = enemyHealth;
    }
    private void Update()
    {
        ChangeHealthBarValue();
    }
    private void ChangeHealthBarValue() => healthBarImage.fillAmount = HP / enemyHealth;
}

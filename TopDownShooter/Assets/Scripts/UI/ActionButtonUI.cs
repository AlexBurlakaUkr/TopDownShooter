
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class ActionButtonUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private Button button;
    public void SetButtonName(string nameWeapon, UnityAction unityAction)
    {
        textMeshPro.text = nameWeapon;
        button.onClick.AddListener(unityAction);
    }


}

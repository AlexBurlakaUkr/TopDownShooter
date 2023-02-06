using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent OnCoinCounter = new UnityEvent();
    public static UnityEvent OnWeaponFire = new UnityEvent();
    public static UnityEvent OnStopWeaponFire = new UnityEvent();

    public static void SendCoinCount() => OnCoinCounter.Invoke();
    public static void SendWeaponFire() => OnWeaponFire.Invoke();
    public static void SendStopWeaponFire() => OnStopWeaponFire.Invoke();
}

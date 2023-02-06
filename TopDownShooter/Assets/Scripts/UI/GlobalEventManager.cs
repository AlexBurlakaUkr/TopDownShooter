using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent OnCoinCounter = new UnityEvent();

    public static void SendFruitCount() => OnCoinCounter.Invoke();
}

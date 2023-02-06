using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    private int count = 0;
    private void Start()
    {
        GlobalEventManager.OnCoinCounter.AddListener(GetCoinCount);
    }
    private void GetCoinCount()
    {
        count += 10;
        GetComponent<TMP_Text>().text = $": {count}";
    }
}

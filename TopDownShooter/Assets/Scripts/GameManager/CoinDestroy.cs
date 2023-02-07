using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDestroy : MonoBehaviour
{
    [SerializeField] private AudioSource coinSounds;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            coinSounds.Play();
            GlobalEventManager.SendCoinCount();
            transform.GetComponent<SphereCollider>().enabled = false;
            Invoke(nameof(GetSetActive), 0.2f);
        }
    }
    private void GetSetActive() => gameObject.SetActive(false);
}

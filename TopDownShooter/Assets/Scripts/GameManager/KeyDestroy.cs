
using UnityEngine;

public class KeyDestroy : MonoBehaviour
{
    [SerializeField] private AudioSource keySound;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerAttack>().isGetKey = true;
            keySound.Play();
            transform.GetComponent<CapsuleCollider>().enabled = false;
            Invoke(nameof(GetSetActive), 0.2f);
        }
    }
    private void GetSetActive() => gameObject.SetActive(false);
}

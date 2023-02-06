
using UnityEngine;

public class KeyDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerAttack>().isGetKey = true;
            gameObject.SetActive(false);
        }
    }
}

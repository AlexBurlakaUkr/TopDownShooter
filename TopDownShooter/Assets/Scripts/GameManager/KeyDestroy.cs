
using UnityEngine;

public class KeyDestroy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerAttack>().isGetKey = true;
            gameObject.SetActive(false);
        }
    }
}

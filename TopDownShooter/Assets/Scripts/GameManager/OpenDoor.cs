using Unity.VisualScripting;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Vector3 moveVector = new Vector3(0, 0, 0);
    [SerializeField] private float speed = 1f;
    [SerializeField] private AudioSource doorSound;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<PlayerAttack>().isGetKey == true)
        {
            doorSound.Play();
            transform.position =  Vector3.Lerp(transform.position, moveVector, speed);
            transform.GetComponent<BoxCollider>().enabled = false;
        }

    }
}

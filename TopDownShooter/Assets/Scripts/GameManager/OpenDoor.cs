using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private Vector3 moveVector = new Vector3(0, 0, 0);
    [SerializeField] private float speed = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<PlayerAttack>().isGetKey == true)
        {
            transform.position =  Vector3.Lerp(transform.position, moveVector, speed);
            Debug.Log("DoorContact");
        }

    }
}

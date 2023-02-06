using UnityEngine;
using DG.Tweening;

public class DoOpenDoor : MonoBehaviour
{
    [SerializeField] private Vector3 moveVector = new Vector3(0, 0, 0);
    [SerializeField] private float duration = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<PlayerAttack>().isGetKey == true) 
            transform.DOMove(moveVector, duration);
    }
}

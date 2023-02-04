using UnityEngine;
using DG.Tweening;

public class DoRotateObject : MonoBehaviour
{
    [SerializeField] private Vector3 rotateVector = new Vector3(0,0,0);
    [SerializeField] private float duration = 1f;
    private void Start()
    {
        transform.DORotate(rotateVector, duration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Incremental);
    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoMoveYoyo : MonoBehaviour
{
    [SerializeField] private Vector3 moveVector = new Vector3(0, 0, 0);
    [SerializeField] private float duration = 1f;
    private void Start()
    {
        transform.DOMove(moveVector, duration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }
}

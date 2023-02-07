using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private Vector3 rotate = Vector3.zero;
    [SerializeField] private float speedRotate = 1f;
    private void Update()
    {
       transform.Rotate(rotate * Time.deltaTime * speedRotate);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private VariableJoystick joystick;
    //[SerializeField] private Animator plyerAnimator;
    [SerializeField] private float playerMoveSpeed;

    private Rigidbody playerRigitbody;


    private void Start()
    {
        playerRigitbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        playerRigitbody.velocity = new Vector3(joystick.Horizontal * playerMoveSpeed,
            playerRigitbody.velocity.y, joystick.Vertical * playerMoveSpeed);
        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(playerRigitbody.velocity);
        }
    }
}

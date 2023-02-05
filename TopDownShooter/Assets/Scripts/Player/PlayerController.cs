using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerMoveSpeed;
    [SerializeField] private VariableJoystick joystick;

    private Animator playerAnimator;
    private Rigidbody playerRigitbody;


    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRigitbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        GetPlayerAnamation();
    }
    private void FixedUpdate()
    {
        GetPlayerMove();
    }
    private void GetPlayerMove()
    {
        playerRigitbody.velocity = new Vector3(joystick.Horizontal * playerMoveSpeed,
                    playerRigitbody.velocity.y, joystick.Vertical * playerMoveSpeed);

        GetLookRotation();
    }

    private void GetPlayerAnamation()
    {
        playerAnimator.SetFloat("Move", Mathf.Max(Mathf.Abs(joystick.Horizontal), Mathf.Abs(joystick.Vertical)));
    }

    private void GetLookRotation()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0) transform.rotation = Quaternion.LookRotation(playerRigitbody.velocity);
    }
}

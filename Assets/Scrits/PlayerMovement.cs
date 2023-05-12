using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Walk
{
    walk,
    crouch
}
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float groundDrag;
    [SerializeField] private Transform orientation;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float jumpForce;
    [SerializeField] private float playerHeight;
    [SerializeField] private float jumpCooldown;
    [SerializeField] private float airMultiplaier;
    bool redyToJump;

    private float horizontalInput;
    private float verticalInput;
    
    
    private bool grounded;
    private Walk walk;
    private Vector3 moveDirection;

    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private CapsuleCollider collider;
    [SerializeField]
    private GameObject camera;

    private void Start()
    {
        redyToJump = true;
    }
    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down,playerHeight * 0.5f + 0.2f, whatIsGround);
        
        MyInput();
SpeedControll();

        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

    }

    private void FixedUpdate()
    {
        //if(grounded)
            MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.Space)&&redyToJump && grounded)
        {
            redyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }
    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10, ForceMode.Force);
        else if(!grounded) rb.AddForce(moveDirection.normalized * moveSpeed * 10 *airMultiplaier, ForceMode.Force);
    }

    private void SpeedControll()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitVel.x, rb.velocity.y, limitVel.z);
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    void ResetJump()
    {
        redyToJump = true;
    }
}

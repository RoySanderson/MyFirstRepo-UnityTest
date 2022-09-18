using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movespeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private int playerIndex;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (TurnManager.GetInstance().PlayerIsActive(playerIndex))
        {

            float leftRight = Input.GetAxis("Horizontal");
            float forwardBack = Input.GetAxis("Vertical");

            rb.velocity = new Vector3(leftRight * movespeed, rb.velocity.y, forwardBack * movespeed);

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                TurnManager.GetInstance().ChangeTurn();
            }
        }

    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, whatIsGround);
    }
    
}

    


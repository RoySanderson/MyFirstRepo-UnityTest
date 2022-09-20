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

            Vector3 playerMovement = new Vector3(leftRight, 0, forwardBack).normalized;

            rb.transform.Translate(playerMovement * movespeed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector3(rb.velocity.x, jumpSpeed, rb.velocity.z);
            }

            
        }

    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.1f, whatIsGround);
    }
    
}

    


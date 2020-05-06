﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 100f;

    public float jumpHeight = 3f;

<<<<<<< HEAD
=======
    public bool doubleJump = false;

>>>>>>> 4c0d247e229fac5299665c76fff8e0fcf4c228de
    Vector3 velocity;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;

    public LayerMask groundMask;

    bool isGrounded;

<<<<<<< HEAD
=======
    int numJumps = 0;

>>>>>>> 4c0d247e229fac5299665c76fff8e0fcf4c228de

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
<<<<<<< HEAD
=======
            numJumps = 0;
>>>>>>> 4c0d247e229fac5299665c76fff8e0fcf4c228de
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

<<<<<<< HEAD
        if (Input.GetButtonDown("Jump")) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
=======
        if (doubleJump) {
            if (Input.GetButtonDown("Jump") && numJumps < 2) {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                numJumps++;
            }
        } else {
            if (Input.GetButtonDown("Jump") && isGrounded) {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
>>>>>>> 4c0d247e229fac5299665c76fff8e0fcf4c228de
        }

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}

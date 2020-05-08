﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 100f;
    public AudioSource walk;

    public float jumpHeight = 3f;

    public bool doubleJump = false;

    Vector3 velocity;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public Vector3 run;
    public float runSpeed;

    public LayerMask groundMask;

    bool isGrounded;

    int numJumps = 0;


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
            numJumps = 0;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (doubleJump) {
            if (Input.GetButtonDown("Jump") && numJumps < 2) {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                numJumps++;
            }
        } else {
            if (Input.GetButtonDown("Jump") && isGrounded) {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        run = move;
        runSpeed = move.magnitude;

        if (runSpeed >= .1f && walk.isPlaying == false)
        {
          walk.pitch = Random.Range(0.75f, 0.9f);
          walk.volume = Random.Range(0.65f,0.8f);
          // walk.time;

          walk.Play();


        }
        // if (walk.isPlaying == true)
        // {
        //
        //   walk.Stop();
        // }

    }
}

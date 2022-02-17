using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController2D controller;

    private float speed = 40f;
    private float horizontalMove = 0f;

    private bool jump = false;
    private bool crouch = false;

    private float startDelay = 0.25f;

    void Start()
    {
        controller = GetComponent<CharacterController2D>();
        jump = false;
        crouch = false;
        speed = 40f;
    }

    private void Update()
    {
        while (startDelay > 0)
        {
            startDelay -= Time.deltaTime;
            return;
        }

        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButton("Crouch"))
        {
            crouch = true;
        }
        else
        {
            crouch = false;
        }

        if (Input.GetButton("Sprint"))
        {
            speed = 60f;
        }
        else
        {
            speed = 40f;
        }

    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
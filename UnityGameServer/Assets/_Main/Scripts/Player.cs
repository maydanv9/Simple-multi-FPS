﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public struct InputValues
    {
        public float mouseX;
        public float mouseY;
        public float vertical;
        public float horizontal;
    }

    public int id;
    public string username;

    public CharacterController controller;
    private float gravity = -20f;
    public float speed;
    private float moveSpeed = .5f;
    private float runSpeed = 1f;
    private float crouchSpeed = .2f;
    private float jumpSpeed = 10f;

    private int animationStatus;
    public int AnimationStatus => animationStatus;

    private bool[] inputs;
    private float yVelocity = 0;
    private InputValues inputValues;
    private void Start()
    {
        gravity *= Time.fixedDeltaTime * Time.fixedDeltaTime;
        //moveSpeed *= Time.fixedDeltaTime;
        jumpSpeed *= Time.fixedDeltaTime;
    }

    public void Initialize(int _id, string _username)
    {
        id = _id;
        username = _username;
        inputValues = new InputValues();
        inputs = new bool[3];
    }

    /// <summary>Processes player input and moves the player.</summary>
    public void FixedUpdate()
    {
        Move(inputs, inputValues);
    }

    /// <summary>Calculates the player's desired movement direction and moves him.</summary>
    /// <param name="_inputDirection"></param>
    private void Move(bool[] _inputs, InputValues inputValues)
    {
        if (_inputs[Keys.Controls.IS_SHIFT_PPRESSED])
        {
            speed = runSpeed;
            animationStatus = Keys.Animations.ANIMATION_RUNNING;
        }
        else if (_inputs[Keys.Controls.IS_CTRL_PPRESSED])
        {
            speed = crouchSpeed;
            animationStatus = Keys.Animations.ANIMATION_CROUCHING;
        }
        else
        {
            speed = moveSpeed;
            animationStatus = Keys.Animations.ANIMATION_WALKING;
        }

        if(inputValues.horizontal == 0 && inputValues.vertical == 0)
        {
            animationStatus = Keys.Animations.ANIMATION_IDLE;
        }

        Vector3 moveVector = transform.right * inputValues.horizontal * speed + transform.forward * inputValues.vertical * speed;

        if (controller.isGrounded)
        {
            yVelocity = 0f;
            if (_inputs[Keys.Controls.IS_SPACE_PPRESSED])
            {
                yVelocity = jumpSpeed;
            }
        }

        yVelocity += gravity;
        moveVector.y = yVelocity;
        transform.position += moveVector;

        controller.Move(moveVector);

        ServerSend.PlayerPosition(this);
        ServerSend.PlayerRotation(this);
    }

    /// <summary>Updates the player input with newly received input.</summary>
    /// <param name="_inputs">The new key inputs.</param>
    /// <param name="_rotation">The new rotation.</param>
    public void SetInput(bool[] _inputs, Quaternion _rotation, float[] _inputsFloats)
    {
        inputValues.vertical = _inputsFloats[0];
        inputValues.horizontal = _inputsFloats[1];
        inputs = _inputs;
        transform.rotation = _rotation;
    }
}

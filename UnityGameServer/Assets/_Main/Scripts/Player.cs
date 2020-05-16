using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public struct InputValues
    {
        public float vertical;
        public float horizontal;
    }

    [Header("Player data: ")]
    public int id;
    public string username;

    [Header("Speed and movements: ")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed;
    public bool isGrounded => controller.isGrounded;
    private float gravity = -20f;
    private float jumpSpeed = 10f;
    private float yVelocity = 0;
    private InputValues inputValues;
    private bool[] inputs;

    public void Initialize(int _id, string _username)
    {
        jumpSpeed *= Time.fixedDeltaTime;
        gravity *= Time.fixedDeltaTime * Time.fixedDeltaTime;
        id = _id;
        username = _username;
        inputValues = new InputValues();
        inputs = new bool[9];
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

        this.controller.Move(moveVector);

        ServerSend.PlayerPosition(this);
        ServerSend.PlayerRotation(this);
    }    

    /// <summary>Updates the player input with newly received input.</summary>
    /// <param name="_inputs">The new key inputs.</param>
    /// <param name="_rotation">The new rotation.</param>
    public void SetMovement(Quaternion _rotation, float[] _inputsFloats)
    {
        inputValues.vertical = _inputsFloats[0];
        inputValues.horizontal = _inputsFloats[1];
        
        transform.rotation = _rotation;
        Debug.DrawRay(transform.position, transform.forward * 10, Color.red);

    }

    public void SetInputs(bool[] _inputs)
    {
        inputs = _inputs;
    }

}

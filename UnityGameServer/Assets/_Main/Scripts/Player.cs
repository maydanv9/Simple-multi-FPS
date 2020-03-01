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

    [Header("Player stats: ")]
    [SerializeField] private int playerHealth;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int playerArmor;
    [SerializeField] private int maxArmor = 100;

    [Header("Speed and movements: ")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed;
    [SerializeField] private Transform shootOrigin;

    private float gravity = -20f;
    private float moveSpeed = .5f;
    private float runSpeed = 1f;
    private float crouchSpeed = .2f;
    private float jumpSpeed = 10f;
    private float yVelocity = 0;
    private InputValues inputValues;
    private bool[] inputs;
    private int shootDistance = 20;
    [Header("Animation status: ")]
    [SerializeField] private string playerStatus;
    [SerializeField] private string playerAnimation;

    public string PlayerAnimation => playerAnimation;
    public string PlayerStatus => playerStatus;
    public int PlayerHealth => playerHealth;

    public void Initialize(int _id, string _username)
    {
        jumpSpeed *= Time.fixedDeltaTime;
        gravity *= Time.fixedDeltaTime * Time.fixedDeltaTime;

        id = _id;
        username = _username;
        inputValues = new InputValues();
        inputs = new bool[5];
        playerHealth = maxHealth;
    }

    /// <summary>Processes player input and moves the player.</summary>
    public void FixedUpdate()
    {
        if (playerHealth <= 0) return;

        Move(inputs, inputValues);
        Debug.Log("Player: " + id + " has status:" + playerStatus);
    }

    /// <summary>Calculates the player's desired movement direction and moves him.</summary>
    /// <param name="_inputDirection"></param>
    private void Move(bool[] _inputs, InputValues inputValues)
    {
        PlayerStatusCheck(_inputs);

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
        ServerSend.PlayerAnimation(this);
    }

    private void PlayerStatusCheck(bool[] _inputs)
    {
        //CHECK MOVEMENT
        if (_inputs[Keys.Controls.IS_SHIFT_PPRESSED])
        {
            speed = runSpeed;
            playerStatus = Keys.PlayerStatus.ANIMATION_RUNNING;
        }
        else if (_inputs[Keys.Controls.IS_CTRL_PPRESSED])
        {
            speed = crouchSpeed;
            playerStatus = Keys.PlayerStatus.ANIMATION_CROUCHING;
        }
        else
        {
            speed = moveSpeed;
            playerStatus = Keys.PlayerStatus.ANIMATION_WALKING;
        } 

        if (inputValues.horizontal == 0 && inputValues.vertical == 0)
        {
            playerAnimation = Keys.PlayerAnimation.ANIMATION_IDLE;
            playerStatus = Keys.PlayerStatus.ANIMATION_WALKING;
            speed = moveSpeed;
        }

        //CHECK MOUSE
        if (_inputs[Keys.Controls.IS_LMB_PPRESSED])
        {
            playerAnimation = Keys.PlayerAnimation.ANIMATION_SHOOT;
        } else playerAnimation = Keys.PlayerAnimation.ANIMATION_IDLE;
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

    public void Shoot(Vector3 _viewDirection)
    {
        if (Physics.Raycast(shootOrigin.position, _viewDirection, out RaycastHit _hit, shootDistance))
        {
            if (_hit.collider.CompareTag(Keys.Tags.PLAYER_TAG))
            {
                _hit.collider.GetComponent<Player>().TakeDamage(50);
            }
        }
    }

    public void TakeDamage(int _damage)
    {
        if (playerHealth <= 0f)
        {
            return;
        }

        playerHealth -= _damage;
        if (playerHealth <= 0f)
        {
            controller.enabled = false;
            transform.position = new Vector3(0f, 25f, 0f);
            ServerSend.PlayerPosition(this);
            StartCoroutine(Respawn());
        }

        ServerSend.PlayerHealth(this);
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(5f);

        playerHealth = maxHealth;
        controller.enabled = true;
        ServerSend.PlayerRespawned(this);
    }
}

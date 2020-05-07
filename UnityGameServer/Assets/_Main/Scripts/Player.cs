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
    public bool isGrounded => controller.isGrounded;
    public bool isGrounded1;
    private float gravity = -20f;
    private float moveSpeed = .08f;
    private float runSpeed = .15f;
    private float crouchSpeed = .05f;
    private float jumpSpeed = 10f;
    private float yVelocity = 0;
    private InputValues inputValues;
    private bool[] inputs;
    private int shootDistance = 20;
    [Header("Animation status: ")]
    [SerializeField] private string playerMovementStatus;
    [SerializeField] private string playerActionStatus;
    [SerializeField] private string playerWeaponStatus;
    //[Header("Weapon: ")]
    //to do weapon
    //switch 1.2.3,4 to weapon type
    //header EQ
    public string PlayerActionStatus => playerActionStatus;
    public string PlayerMovementStatus => playerMovementStatus;
    public string PlayerWeaponStatus => playerWeaponStatus;
    public int PlayerHealth => playerHealth;

    public void Initialize(int _id, string _username)
    {
        jumpSpeed *= Time.fixedDeltaTime;
        gravity *= Time.fixedDeltaTime * Time.fixedDeltaTime;

        id = _id;
        username = _username;
        inputValues = new InputValues();
        inputs = new bool[9];
        playerHealth = maxHealth;
    }

    /// <summary>Processes player input and moves the player.</summary>
    public void FixedUpdate()
    {
        if (playerHealth <= 0) return;
        Move(inputs, inputValues);
        Debug.Log("Player: " + id + " has status:" + playerMovementStatus);
    }

    /// <summary>Calculates the player's desired movement direction and moves him.</summary>
    /// <param name="_inputDirection"></param>
    private void Move(bool[] _inputs, InputValues inputValues)
    {
        if (playerHealth <= 0) return;
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
            playerMovementStatus = Keys.PlayerMovement.ANIMATION_RUNNING;
        }
        else if (_inputs[Keys.Controls.IS_CTRL_PPRESSED])
        {
            speed = crouchSpeed;
            playerMovementStatus = Keys.PlayerMovement.ANIMATION_CROUCHING;
        }
        else
        {
            speed = moveSpeed;
            playerMovementStatus = Keys.PlayerMovement.ANIMATION_WALKING;
        }

        if (inputValues.horizontal == 0 && inputValues.vertical == 0)
        {
            speed = 0;
            playerMovementStatus = Keys.PlayerMovement.ANIMATION_IDLE;
        }

        //CHECK MOUSE
        if (_inputs[Keys.Controls.IS_LMB_PPRESSED])
        {
            playerActionStatus = Keys.PlayerAction.ANIMATION_SHOOT;
        }
        else playerActionStatus = Keys.PlayerAction.ANIMATION_IDLE;

        //WEAPON KEYS
        if (_inputs[Keys.Controls.IS_ALPHA_1_PRESSED]) { playerWeaponStatus = Keys.PlayerWeapon.WEAPON_KNIFE; }
        else if (_inputs[Keys.Controls.IS_ALPHA_2_PRESSED]) { playerWeaponStatus = Keys.PlayerWeapon.WEAPON_PISTOL; }
        else if (_inputs[Keys.Controls.IS_ALPHA_3_PRESSED]) { playerWeaponStatus = Keys.PlayerWeapon.WEAPON_RIFLE; }
        else if (_inputs[Keys.Controls.IS_ALPHA_4_PRESSED]) { playerWeaponStatus = Keys.PlayerWeapon.WEAPON_GRENADE; }
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

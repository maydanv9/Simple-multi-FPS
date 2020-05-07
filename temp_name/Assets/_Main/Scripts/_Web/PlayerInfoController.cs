using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoController : MonoBehaviour
{
    [Header("Player server info: ")]
    [SerializeField] private int id;
    [SerializeField] private string username;

    [Header("Player stats info: ")]
    [SerializeField] private string playerMovement;
    [SerializeField] private string playerAction;
    [SerializeField] private string playerWeapon;
    [SerializeField] private int playerHealth;
    [SerializeField] private int playerArmor;
    [SerializeField] private int max = 100;

    [Header("Player model info: ")]
    [SerializeField] private SkinnedMeshRenderer playerMesh;
    [SerializeField] private Animator animator;
    public bool hasGun = false;
    public void SetServerInfo(int _id, string _username)
    {
        id = _id;
        username = _username;
        playerArmor = 100;
        playerHealth = 100;
    }

    public void SetHealth(int _hp, int _armor)
    {
        playerHealth = _hp;
        playerArmor = _armor;

        if (playerHealth <= 0)
        {
            Die();
        }
    }

    public void SetAnimation(string _playerAction, string _playerMovement, string _playerWeapon)
    {
        playerMovement = _playerMovement;
        playerAction = _playerAction;
        playerWeapon = _playerWeapon;

        switch (playerWeapon)
        {
            case "PISTOL":
                animator.SetFloat("Gun", 0f);
                break;
            case "RIFLE":
                animator.SetFloat("Gun", 1f);
                break;
            default:
                //animator.SetFloat("Action", 0f);
                break;
        }

        switch (playerAction)
        {
            case "SHOOTING":
                break;
            case "AIM":
                break;
            default:
                //animator.SetFloat("Action", 0f);
                break;
        }

        switch (playerMovement)
        {
            case "WALKING":
                animator.SetFloat("Speed", 0.5f);
                break;
            case "RUNNING":
                animator.SetFloat("Speed", 1f);
                break;
            default:
                animator.SetFloat("Speed", 0f);
                break;

        }


    }

    public void Die()
    {
        playerMesh.enabled = false;
    }

    public void Respawn()
    {
        playerMesh.enabled = true;
        SetHealth(100, 100);
    }
}
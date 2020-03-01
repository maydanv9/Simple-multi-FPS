using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoController : MonoBehaviour
{
    [Header("Player server info: ")]
    [SerializeField] private int id;
    [SerializeField] private string username;

    [Header("Player stats info: ")]
    [SerializeField] private string playerAnimation;
    [SerializeField] private string playerStatus;
    [SerializeField] private int playerHealth;
    [SerializeField] private int playerArmor;
    [SerializeField] private int max = 100;

    [Header("Player model info: ")]
    [SerializeField] private SkinnedMeshRenderer playerMesh;

    public void SetServerInfo(int _id, string _username)
    {
        id = _id;
        username = _username;
        playerArmor = 100;
        playerHealth = 100;
    }
    private void Update()
    {
        Debug.Log(playerHealth);
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

    public void SetAnimation(string _playerAnimation, string _playerStatus)
    {
        playerAnimation = _playerAnimation;
        playerStatus = _playerStatus;
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
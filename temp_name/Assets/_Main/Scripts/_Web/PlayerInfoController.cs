using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoController : MonoBehaviour
{
    [Header("Player server info: ")]
    [SerializeField] private int id;
    [SerializeField] private string username;

    public void SetServerInfo(int _id, string _username)
    {
        id = _id;
        username = _username;
    }
}
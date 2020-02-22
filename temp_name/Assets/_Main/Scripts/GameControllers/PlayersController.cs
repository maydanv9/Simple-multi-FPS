using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersController : MonoBehaviour
{
    public Dictionary<int, PlayerInfoController> players = new Dictionary<int, PlayerInfoController>();
    public List<PlayerController> playerControllerList = new List<PlayerController>();

    public GameObject localPlayerPrefab;
    public GameObject playerPrefab;

    public void SpawnPlayer(int _id, string _username, Vector3 _position, Quaternion _rotation)
    {
        GameObject _player;
        if (_id == Client.instance.myId)
        {
            _player = Instantiate(localPlayerPrefab, _position, _rotation);
            playerControllerList.Add(_player.GetComponent<PlayerController>());
        }
        else
        {
            _player = Instantiate(playerPrefab, _position, _rotation);
        }
        //TO DO: SORT OF INITATION
        _player.GetComponent<PlayerInfoController>().id = _id;
        _player.GetComponent<PlayerInfoController>().username = _username;
        players.Add(_id, _player.GetComponent<PlayerInfoController>());
    }
}

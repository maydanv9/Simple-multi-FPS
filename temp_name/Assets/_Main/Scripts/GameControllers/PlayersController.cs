using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersController : MonoBehaviour
{
    private GameController gameController;
    public Dictionary<int, PlayerInfoController> players = new Dictionary<int, PlayerInfoController>();

    [SerializeField] private GameObject localPlayerPrefab;
    [SerializeField] private GameObject playerPrefab;

    private PlayerController localPlayer;
    public PlayerController LocalPlayer => localPlayer;
    public void Init(GameController _gameController)
    {
        this.gameController = _gameController;
    }

    public void SpawnPlayer(int _id, string _username, Vector3 _position, Quaternion _rotation)
    {
        GameObject _player;
        if (_id == Client.instance.myId)
        {
            _player = Instantiate(localPlayerPrefab, _position, _rotation, gameController.SceneReferences.PlayersTransform);
        }
        else
        {
            _player = Instantiate(playerPrefab, _position, _rotation, gameController.SceneReferences.PlayersTransform);
        }

        localPlayer = _player.GetComponent<PlayerController>();
        localPlayer.Init();
        //TO DO: SORT OF INITATION
        _player.GetComponent<PlayerInfoController>().id = _id;
        _player.GetComponent<PlayerInfoController>().username = _username;
        players.Add(_id, _player.GetComponent<PlayerInfoController>());
    }
}

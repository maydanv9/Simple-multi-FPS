using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ClientHandle : MonoBehaviour
{
    public static void Welcome(Packet _packet)
    {
        string _msg = _packet.ReadString();
        int _myId = _packet.ReadInt();

        Debug.Log($"Message from server: {_msg}");
        Client.instance.myId = _myId;
        ClientSend.WelcomeReceived();

        Client.instance.udp.Connect(((IPEndPoint)Client.instance.tcp.socket.Client.LocalEndPoint).Port);
    }

    public static void SpawnPlayer(Packet _packet)
    {
        int _id = _packet.ReadInt();
        string _username = _packet.ReadString();
        Vector3 _position = _packet.ReadVector3();
        Quaternion _rotation = _packet.ReadQuaternion();

        GameController.gameControllerInstance.PlayersController.SpawnPlayer(_id, _username, _position, _rotation);
    }

    public static void PlayerPosition(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Vector3 _position = _packet.ReadVector3();
        GameController.gameControllerInstance.PlayersController.players[_id].transform.position = _position;
    }

    public static void PlayerRotation(Packet _packet)
    {
        int _id = _packet.ReadInt();
        Quaternion _rotation = _packet.ReadQuaternion();
        GameController.gameControllerInstance.PlayersController.players[_id].transform.rotation = _rotation; 
    }

    public static void PlayerAnimation(Packet _packet)
    {
        int _id = _packet.ReadInt();
        string _playerAnimation = _packet.ReadString();
        string _playerStatus = _packet.ReadString();
        string _playerWeapon = _packet.ReadString();
        GameController.gameControllerInstance.PlayersController.players[_id].SetAnimation(_playerAnimation, _playerStatus, _playerWeapon);
    }

    public static void PlayerDisconnected(Packet _packet)
    {
        int _id = _packet.ReadInt();

        Destroy(GameController.gameControllerInstance.PlayersController.players[_id].gameObject);
        GameController.gameControllerInstance.PlayersController.RemovePlayer(_id);
    }

    public static void PlayerHealth(Packet _packet)
    {
        int _id = _packet.ReadInt();
        int _health = _packet.ReadInt();
        GameController.gameControllerInstance.PlayersController.players[_id].SetHealth(_health, 0);
    }

    public static void PlayerRespawned(Packet _packet)
    {
        int _id = _packet.ReadInt();
        GameController.gameControllerInstance.PlayersController.players[_id].Respawn();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientSend : MonoBehaviour
{
    private static void SendTCPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.tcp.SendData(_packet);
    }

    private static void SendUDPData(Packet _packet)
    {
        _packet.WriteLength();
        Client.instance.udp.SendData(_packet);
    }

    #region Packets
    public static void WelcomeReceived()
    {
        using (Packet _packet = new Packet((int)ClientPackets.welcomeReceived))
        {
            _packet.Write(Client.instance.myId);
            _packet.Write(Client.instance.myLogin);

            SendTCPData(_packet);
        }
    }

    public static void PlayerMovement(float[] _inputsFloats)
    {
        using (Packet _packet = new Packet((int)ClientPackets.playerMovement))
        {

            _packet.Write(_inputsFloats.Length);
            foreach (float _inputFloat in _inputsFloats)
            {
                _packet.Write(_inputFloat);
            }

            _packet.Write(GameController.gameControllerInstance.PlayersController.players[Client.instance.myId].transform.rotation);

            SendUDPData(_packet);
        }
    }

    public static void PlayerInputs(bool[] _inputs)
    {
        using (Packet _packet = new Packet((int)ClientPackets.playerInputs))
        {
            _packet.Write(_inputs.Length);
            foreach (bool _input in _inputs)
            {
                _packet.Write(_input);
            }

            SendUDPData(_packet);
        }
    }

    public static void PlayerShoot(Vector3 _facing)
    {
        using (Packet _packet = new Packet((int)ClientPackets.playerShoot))
        {
            _packet.Write(_facing);

            SendTCPData(_packet);
        }
    }
    #endregion
}
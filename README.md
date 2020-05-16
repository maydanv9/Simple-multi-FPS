# Simple multi FPS
Simple project of multiplayer FPS game with local server.

## Branch Master
Game has implemented basic blend tree with animations, shooting and respawn system.
Handling packets via TCP and UDP.
Serverside movement, health, current player status, collisions.
Clientside rotation, shoot detection, inputs, animation look based on status.


## Branch Clean_project
Example project with comments showing how to implement this in your project.

Uses TCP and UDP packets.

###### UnityGameServer:
Player.cs - instance of each player spawned on scene with data and params.  
  
ServerSend.cs - sends data from server to client/s.   
  
ServerHandle.cs - reads data from packets.  
  
###### Server.cs -
  
InitializeServerData() -> packetHandlers needs to have all ClientPackets connected with PacketHandler(method from ServerHandle.cs)  
eg:
```
packetHandlers = new Dictionary<int, PacketHandler>()
            {
                { (int)ClientPackets.welcomeReceived, ServerHandle.WelcomeReceived }
            }
```

```public class ServerHandle
{

    public static void WelcomeReceived(int _fromClient, Packet _packet)
    {
        int _clientIdCheck = _packet.ReadInt();
        string _username = _packet.ReadString();

        Debug.Log($"{Server.clients[_fromClient].tcp.socket.Client.RemoteEndPoint} connected successfully and is now player {_fromClient}.");
        if (_fromClient != _clientIdCheck)
        {
            Debug.Log($"Player \"{_username}\" (ID: {_fromClient}) has assumed the wrong client ID ({_clientIdCheck})!");
        }
        Server.clients[_fromClient].SendIntoGame(_username);
    }
``` 
  
###### Universal:  
Packet.cs:  **CLASS HAS TO BE THE SAME IN BOTH CLIENT AND SERVER**
enum ServerPackets -> packets that server send to client/s.  
enum ClientPackets -> packets that client send to server.  
```
public enum ClientPackets
{
    welcomeReceived,
}

public enum ServerPackets
{
    welcome = 1,
}
```  

###### Client(temp_name):
**Note: If you are playing, you are client. If you see someone, its guest.**  
PlayerController.cs - handles client operations(movement, rotation of client).    
PlayerController.cs - handles guests and client operations(like spawn, respawn, remove).   
PlayerInfoController.cs - information from server about all guests(and client itself).    
ClientSend.cs - sends data to server.  
ClientHandle.cs - reads data from server and applies it to client and quests.  

Client.cs -  
InitializeClientData() -> same as in server, but its info from server now.
```
packetHandlers = new Dictionary<int, PacketHandler>()
        {
            { (int)ServerPackets.welcome, ClientHandle.Welcome },
				}
```
  
```
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
}
```

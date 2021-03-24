using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class ServerClient
{
    public int connectionId;
    public string playerName;
    public Vector3 position;
    public string chatMessage;
}


public class Server : MonoBehaviour
{
    private const int MAX_CONNECTION = 100;

    private int port = 5701;
    private int webPort = 5702;

    private int hostId;
    private int webHostId;

    private int reliableChannel;
    private int unreliableChannel;

    private bool isStarted = false;
    private byte error;

    private List<ServerClient> clients = new List<ServerClient>();

    private void Start()
    {
        NetworkTransport.Init();
        ConnectionConfig cc = new ConnectionConfig();

        reliableChannel = cc.AddChannel(QosType.Reliable);
        unreliableChannel = cc.AddChannel(QosType.Unreliable);

        HostTopology topo = new HostTopology(cc, MAX_CONNECTION);

        hostId = NetworkTransport.AddHost(topo, port, null);
        webHostId = NetworkTransport.AddWebsocketHost(topo, webPort, null);

        isStarted = true;
        

    }

    private float lastMovementUpdate;
    private float movementUpdateRate = 0.5f;


    private void Update()
    {
        if (!isStarted)
            return;

        int recHostId;
        int connectionId;
        int channelId;
        byte[] recBuffer = new byte[1024];
        int bufferSize = 1024;
        int dataSize;
        byte error;
        NetworkEventType recData = NetworkTransport.Receive(out recHostId, out connectionId, out channelId, recBuffer, bufferSize, out dataSize, out error);
        switch (recData)
        {

            case NetworkEventType.ConnectEvent: //2
                Debug.Log("Player " + connectionId + " has connected");
                OnConnection(connectionId);
                break;
            case NetworkEventType.DataEvent: //3
                string msg = Encoding.Unicode.GetString(recBuffer, 0, dataSize);
                Debug.Log("Receiving from " + connectionId + " : " + msg);
                string[] splitData = msg.Split('|');

                switch (splitData[0])
                {
                    case "NAMEIS":
                        OnNameIs(connectionId, splitData[1]);
                        break;

                    case "MYPOSITION":
                        OnMyPosition(connectionId, float.Parse(splitData[1]), float.Parse(splitData[2]), float.Parse(splitData[3]));
                        break;

                    case "CHATMSG":
                        OnChatMessage(connectionId, splitData[2], splitData[3]);
                        break;

                    default:
                        Debug.Log("Invalid message : " + msg);
                        break;
                }

                break;


            case NetworkEventType.DisconnectEvent: //4
                Debug.Log("Player " + connectionId + " has disconnected");
                OnDisconnection(connectionId);
                break;
        }

        //ask player for position
        if(Time.time -lastMovementUpdate > movementUpdateRate)
        {
            lastMovementUpdate = Time.time;
            string m = "ASKPOSITION|";
            foreach (ServerClient sc in clients)
                m += sc.connectionId.ToString() + '%' + sc.position.x.ToString() + '%' + sc.position.y.ToString() + '%' + sc.position.z.ToString() + '|';
            m = m.Trim('|');

            Send(m, unreliableChannel, clients);
        }

    }

    private void OnConnection(int cnnId)
    {
        // add them to a list
        ServerClient c = new ServerClient();
        c.connectionId = cnnId;
        c.playerName = "TEMP";
        clients.Add(c);


        //when player joins server, tell them the ID
        //request name and send name of all other players
        string msg = "ASKNAME|" + cnnId + "|";
        foreach(ServerClient sc in clients)
            msg += sc.playerName + '%' + sc.connectionId + '|';

        msg = msg.Trim('|');

        // ASKNAME|3|DAVE%1|MICHHAEL%2|TEMP%3
        Send(msg, reliableChannel, cnnId);

    }
    private void OnDisconnection(int cnnId)
    {
        //remove this player from client list
        clients.Remove(clients.Find(x => x.connectionId == cnnId));

        //tell everyone that someone else has disconnected
        Send("DC|" + cnnId, reliableChannel, clients);
        
    }



    private void OnNameIs(int cnnId, string playerName)
    {
        // link name to the connection Id
        clients.Find(x => x.connectionId == cnnId).playerName = playerName;


        // tell everybody that a new player has connected
        Send("CNN|" + playerName + '|' + cnnId, reliableChannel, clients);

    }

    private void OnMyPosition(int cnnId, float x, float y, float z)
    {
        clients.Find(c => c.connectionId == cnnId).position = new Vector3(x, y, z);
    }


    private void OnChatMessage(int cnnId, string chatName, string chatMessage)
    {
        
        Send("MSG|" + cnnId + '|' + chatName + '|' + chatMessage, reliableChannel, clients);

    }

    private void Send(string message, int channelId, int cnnId)
    {
        List<ServerClient> c = new List<ServerClient>();
        c.Add(clients.Find(x => x.connectionId == cnnId));
        Send(message, channelId, c);
    }

    private void Send(string message, int channelId, List<ServerClient> c)
    {
        Debug.Log("Sending :" + message);
        byte[] msg = Encoding.Unicode.GetBytes(message);
        foreach(ServerClient sc in c)
        {
            //web
           //NetworkTransport.Send(webHostId, sc.connectionId, channelId, msg, message.Length * sizeof(char), out error);

            //standalone
            NetworkTransport.Send(hostId, sc.connectionId, channelId, msg, message.Length * sizeof(char), out error);
        }
    }
}

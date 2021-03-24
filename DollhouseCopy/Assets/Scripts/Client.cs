using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class Player
{
    public string playerName;
    public GameObject avatar;
    public int connectionId;
}

public class Client : MonoBehaviour
{
    public string ipAddress;

    private const int MAX_CONNECTION = 100;

    private int port = 5701;
    private int webPort = 5702;

    private int hostId;
    private int webHostId;

    private int reliableChannel;
    private int unreliableChannel;

    private int ourClientId;
    private int connectionId;

    private float connectionTime;
    private bool isConnected = false;
    private bool isStarted = false;
    private byte error;

    private string playerName;
    private string cMessage;
    private string chatMessage;
    private string myName;

    public GameObject playerPrefab;
    public Dictionary<int,Player> players = new Dictionary<int, Player>();
    public Transform textBox;
    public GameObject ChatText;

    public Canvas EnableLook;

    public void Connect()
    {
        //Does the player have a name?
        string pName = GameObject.Find("NameInput").GetComponent<InputField>().text;
        if(pName == "")
        {
            Debug.Log("You must enter a name!");
            return;
        }

        playerName = pName;
        myName = playerName;

        NetworkTransport.Init();
        ConnectionConfig cc = new ConnectionConfig();

        reliableChannel = cc.AddChannel(QosType.Reliable);
        unreliableChannel = cc.AddChannel(QosType.Unreliable);

        HostTopology topo = new HostTopology(cc, MAX_CONNECTION);


//#if UNITY_WEBGL
        // WebGL client
      webHostId = NetworkTransport.AddHost(topo, 0);
      connectionId = NetworkTransport.Connect(webHostId, ipAddress, webPort, 0, out error);
//#else
//      hostId = NetworkTransport.AddHost(topo, 0);
//      connectionId = NetworkTransport.Connect(hostId, "127.0.0.1", port, 0, out error);
//#endif


        connectionTime = Time.time;
        isConnected = true;

    }

    private void Update()
    {
        if (!isConnected)
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
            case NetworkEventType.DataEvent:
                string msg = Encoding.Unicode.GetString(recBuffer, 0, dataSize);
                //Debug.Log("Receiving : " + msg);
                string[] splitData = msg.Split('|');


                switch (splitData[0])
                {
                    case "ASKNAME":
                        OnAskName(splitData);
                        break;
                    case "CNN":
                        SpawnPlayer(splitData[1], int.Parse(splitData[2]));
                        break;
                    case "DC":
                        PlayerDisconnected(int.Parse(splitData[1]));
                        break;
                    case "ASKPOSITION":
                        OnAskPosition(splitData);
                        break;
                    case "MSG":
                        OnAskMsg(splitData);
                        break;
                    default:
                        Debug.Log("Invalid message : " + msg);
                        break;
                }

                break;

        }

    }

    private void OnAskName(string[] data)
    {
        //set this client
        ourClientId = int.Parse(data[1]);


        //Send our name to the server
        Send("NAMEIS|" + playerName, reliableChannel);
        

        //create all the other players
        for (int i = 2; i < data.Length-1; i++)
        {
            string[] d = data[i].Split('%');
            //SpawnPlayer(d[0], int.Parse(d[1]));
            if (d[0] != "TEMP")
                SpawnPlayer(d[0], int.Parse(d[1]));
        }

        //Debug.Log(data.Length);

    }

    private void OnAskPosition(string[] data)
    {
        if (!isStarted)
            return;

        //update everyone else
        for (int i=1;i<data.Length; i++)
        {
            string[] d = data[i].Split('%');

            //prevent the server from updating us
            if (ourClientId != int.Parse(d[0]))
            {
                Vector3 position = Vector3.zero;
                position.x = float.Parse(d[1]);
                position.y = float.Parse(d[2]);
                position.z = float.Parse(d[3]);
                players[int.Parse(d[0])].avatar.transform.position = position;

            }

        }

        //send our own position
        Vector3 myPosition = players[ourClientId].avatar.transform.position;
        string m = "MYPOSITION|" + myPosition.x.ToString() + '|' + myPosition.y.ToString() + '|' + myPosition.z.ToString();
        Send(m, unreliableChannel);

    }

    private void SpawnPlayer(string playerName, int cnnId)
    {
        //Player p = new Player();
        //p.connectionId = cnnId;
        //players.Add(cnnId, p);

        GameObject go = Instantiate(playerPrefab) as GameObject;

        //is this ours?
        if (cnnId == ourClientId)
        {
            
            go.AddComponent<PlayerMotor>();
            go.tag = "thisplayer";
            GameObject.Find("Canvas").SetActive(false);
            
            isStarted = true;


        }


        Player p = new Player();
        p.avatar = go;
        p.playerName = playerName;
        p.connectionId = cnnId;


        p.avatar.GetComponentInChildren<TextMesh>().text = playerName;
        players.Add(cnnId,p);

        EnableLook.enabled = true;

    }

    public void SendMsg()
    {

        GameObject chatinput = GameObject.Find("ChatInput");
        TMP_InputField messageInput = chatinput.GetComponent<TMP_InputField>();

        string cMessage = messageInput.text;
        
        if (cMessage != "")
        { 
            Send("CHATMSG|" + connectionId + '|' + myName + '|' + cMessage, reliableChannel);
        }

        messageInput.DeactivateInputField();

    }


    private void OnAskMsg(string[] data)
    {
        GameObject ct = Instantiate(ChatText) as GameObject;
        ct.transform.SetParent(textBox,false);

        playerName = data[2];
        chatMessage = data[3];


        ct.GetComponentInChildren<Text>().text = playerName + ": " + chatMessage;
        //Debug.Log(playerName + " sent the message: " + chatMessage);

    }

    private void PlayerDisconnected(int cnnId)
    {
        Destroy(players[cnnId].avatar);
        players.Remove(cnnId);
    }

    private void Send(string message, int channelId)
    {
        //Debug.Log("Sending :" + message);
        byte[] msg = Encoding.Unicode.GetBytes(message);


//#if UNITY_WEBGL
       NetworkTransport.Send(webHostId, connectionId, channelId, msg, message.Length * sizeof(char), out error);

        //#else
//        NetworkTransport.Send(hostId, connectionId, channelId, msg, message.Length * sizeof(char), out error);
// #endif

    }
}


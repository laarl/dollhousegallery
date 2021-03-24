using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startDownloadBenSound : MonoBehaviour
{
    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            GameObject.Find("tocaveroom-bensound").GetComponent<EnterRoomAudio1>().enabled = true;
        }
    }
}

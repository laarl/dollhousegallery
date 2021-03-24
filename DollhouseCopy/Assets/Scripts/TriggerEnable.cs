using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnable : MonoBehaviour
{
    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            GameObject.Find("AudioEnterroom").GetComponent<EnterRoomAudio>().enabled = true;
        }
    }
    
}

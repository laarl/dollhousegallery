using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDownloadDoorAudio : MonoBehaviour
{
    public string AudioSourceScript;
    
    private void OnTriggerEnter(Collider player)
        {
            if (player.tag == "thisplayer")
            {
                GameObject.Find(AudioSourceScript).GetComponent<EnterRoomAudio1>().enabled = true;
            }
    }
    
}

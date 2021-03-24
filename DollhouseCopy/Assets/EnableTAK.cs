using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTAK : MonoBehaviour
{
    public GameObject startDownload;

    void OnTriggerEnter(Collider player)
    {

        if (player.tag == "thisplayer")
        {
            startDownload.GetComponent<DownloadTAK>().enabled = true;
            startDownload.GetComponent<DissolveEffectTrigger>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if(player.tag == "thisplayer")
        {
            startDownload.GetComponent<DissolveEffectTrigger>().enabled = false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopStairAudio : MonoBehaviour
{
    public GameObject StairAudio;

    void OnTriggerEnter(Collider player)
    {

        if (player.tag == "thisplayer")
        {
            StairAudio.SetActive(false);
        }
    }

}

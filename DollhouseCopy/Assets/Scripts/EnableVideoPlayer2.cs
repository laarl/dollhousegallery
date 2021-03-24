using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EnableVideoPlayer2 : MonoBehaviour
{

    public VideoPlayer videoplayer1;


    void Start()
    {

        videoplayer1.enabled = false;
    }


    private void OnTriggerEnter(Collider player)
    {

        if (player.tag== "thisplayer"){

            
            videoplayer1.enabled = true;
            
        }
        
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            
            videoplayer1.enabled = false;
            
        }
    }
}

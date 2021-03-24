using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EnableVideoPlayer : MonoBehaviour
{


    public VideoPlayer videoplayer1;
    public VideoPlayer videoplayer2;
    public VideoPlayer videoplayer3;

    

    void Start()
    {
        
        videoplayer1.enabled = false;
        videoplayer2.enabled = false;
        videoplayer3.enabled = false;
    }


    private void OnTriggerEnter(Collider player)
    {

        if (player.tag== "thisplayer"){

            
            videoplayer1.enabled = true;
            videoplayer2.enabled = true;
            videoplayer3.enabled = true;

        }
        
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            
            videoplayer1.enabled = false;
            videoplayer2.enabled = false;
            videoplayer3.enabled = false;
        }
    }
}

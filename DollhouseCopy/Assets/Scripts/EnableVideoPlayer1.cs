using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EnableVideoPlayer1 : MonoBehaviour
{
    GameObject looker;

    public VideoPlayer videoplayer1;
    public GameObject MovingVideo;



    void Start()
    {
        MovingVideo.GetComponent<MoveWithMouse>().enabled = false;
        videoplayer1.enabled = false;
        
    }


    private void OnTriggerEnter(Collider player)
    {

       
       

        if (player.tag== "thisplayer"){

            //looker = GameObject.FindGameObjectWithTag("looker");
            //looker.GetComponent<CameraLook>().enabled = false;

            MovingVideo.GetComponent<MoveWithMouse>().enabled = true;
            videoplayer1.enabled = true;
            

        }
        
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            MovingVideo.GetComponent<MoveWithMouse>().enabled = false;
            videoplayer1.enabled = false;
            //looker.GetComponent<CameraLook>().enabled = true;

        }
    }
}

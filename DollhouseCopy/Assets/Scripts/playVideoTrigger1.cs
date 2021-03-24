using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class playVideoTrigger1 : MonoBehaviour
{

    public VideoPlayer videoPlayer;
    public GameObject Screen;
    public Material BlackMaterial;
    public Material ScreenMaterial;

    private void Start()
    {
        
        Screen.GetComponent<MeshRenderer>().material = BlackMaterial;
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            Screen.GetComponent<MeshRenderer>().material = ScreenMaterial;
            videoPlayer.Play();
        }
    }

    private void OnTriggerExit(Collider player)
    {

        if (player.tag == "thisplayer")
        {
            videoPlayer.Pause();
            Screen.GetComponent<MeshRenderer>().material = BlackMaterial;
        }
    }

    
}

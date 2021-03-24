using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableLinksCanvas : MonoBehaviour
{
    public Canvas LinkCanvas;

    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            LinkCanvas.enabled = true;
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            LinkCanvas.enabled = false;
        }
    }
}

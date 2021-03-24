using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableRaycast : MonoBehaviour
{
    private void OnTriggerEnter(Collider player)
    {
        if(player.tag == "thisplayer")
        {

        
        GameObject.Find("Amberphotos").GetComponent<RaycastMousePos>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.tag == "thisplayer")
        {


            GameObject.Find("Amberphotos").GetComponent<RaycastMousePos>().enabled = false;
        }
    }
}

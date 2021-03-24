using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableScratch : MonoBehaviour
{

    public GameObject scratch1;
    public GameObject scratch2;
    

    public bool hasentered = false;

    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            if (!hasentered)
            {
                scratch1.SetActive(true);
                scratch2.SetActive(true);
                

                scratch1.GetComponent<ScratchCard>().enabled = true;
                //scratch2.GetComponent<ScratchCard>().enabled = true;
                //scratch3.GetComponent<ScratchCard>().enabled = true;

                hasentered = true;
            }
        }
    }
    
    private void OnTriggerExit(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            scratch1.GetComponent<ScratchCard>().enabled = false;
            //scratch2.GetComponent<ScratchCard>().enabled = false;
            //scratch3.GetComponent<ScratchCard>().enabled = false;
        }
    }
}

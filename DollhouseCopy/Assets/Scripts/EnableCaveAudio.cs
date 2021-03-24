using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCaveAudio : MonoBehaviour
{
    public GameObject Bird1Sound;
    public GameObject Bird1Flight;

    public GameObject Bird2Sound;
    public GameObject Bird2Flight;

    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            Bird1Sound.GetComponent<Bird1Audio>().enabled = true;
            Bird1Sound.GetComponent<Animation>().enabled = true;
            Bird1Flight.GetComponent<FlyingPatterns>().enabled = true;


            //Bird2Sound.GetComponent<Bird1Audio>().enabled = true;
            Bird2Sound.GetComponent<Animation>().enabled = true;
            Bird2Flight.GetComponent<FlyingPatterns>().enabled = true;
            GameObject.Find("Amberphotos").GetComponent<RaycastMousePos>().enabled = false;
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            Bird1Sound.GetComponent<Bird1Audio>().enabled = false;
            Bird1Sound.GetComponent<Animation>().enabled = false;
            Bird1Flight.GetComponent<FlyingPatterns>().enabled = false;

            //Bird2Sound.GetComponent<Bird1Audio>().enabled = false;
            Bird2Sound.GetComponent<Animation>().enabled = false;
            Bird2Flight.GetComponent<FlyingPatterns>().enabled = false;
        }
    }
}

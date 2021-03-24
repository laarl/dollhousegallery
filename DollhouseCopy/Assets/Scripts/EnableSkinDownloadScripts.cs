using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableSkinDownloadScripts : MonoBehaviour
{
    public GameObject[] scripts = new GameObject[6];

	public GameObject SoniaScript;

    private void OnTriggerEnter(Collider player)
    {
        if(player.tag == "thisplayer"){

			SoniaScript.GetComponent<RingMakeupSlideshow>().enabled = true;

			foreach (GameObject go in scripts)
            {
                go.GetComponent<GetTextureFromUrl>().enabled = true;
            }

			
        }

    }
}

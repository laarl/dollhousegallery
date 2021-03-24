using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownloadWalls : MonoBehaviour
{
    public GameObject thisroom;


    public static int blockadeColliders = 2;

    public GameObject[] scripts = new GameObject[6];


    //public int wallsDownloaded = 0;

    //public GameObject blockade;



    public bool areDownloaded;



    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "thisplayer")
        {

            //areDownloaded = thisroom.GetComponent<WallsDownloaded>().wallsDownloaded;

            if (areDownloaded == false)
            {

                StartCoroutine(WaitThenGet());
                

                areDownloaded = true;




                //blockade.GetComponent<BoxCollider>().enabled = false;

            }

            
        }

        IEnumerator WaitThenGet()
        {
            foreach (GameObject go in scripts)
            {
                yield return new WaitForSeconds(1f);
                go.GetComponent<GetTextureFromUrl>().enabled = true;

                //wallsDownloaded++;

            }
            
        }
    }
}

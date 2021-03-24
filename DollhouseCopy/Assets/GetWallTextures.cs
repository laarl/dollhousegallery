using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetWallTextures : MonoBehaviour
{

    public AudioSource audioSource1;
    AudioClip myClip1;
    public string doorurl;
    public bool DoorhasPlayed = false;
    public Canvas replayaudio;


    public string floorUrl;
    public Texture floorTexture;
    public Renderer floorRenderer;

    public string ceilingUrl;
    public Texture ceilingTexture;
    public Renderer ceilingRenderer;

    public string rightUrl;
    public Texture rightTexture;
    public Renderer rightRenderer;

    public string leftUrl;
    public Texture leftTexture;
    public Renderer leftRenderer;

    public string frontUrl;
    public Texture frontTexture;
    public Renderer frontRenderer;

    public string backUrl;
    public Texture backTexture;
    public Renderer backRenderer;

    public GameObject[] windows;

    public bool wallsDownloaded;
    public int thisRoom;

    public Canvas loadingtext;



    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            switch (thisRoom)
            {
                case 9:
                    wallsDownloaded = WallsDownloaded.paintingWallsDownloaded;
                    break;
                case 8:
                    wallsDownloaded = WallsDownloaded.fishWallsDownloaded;
                    break;
                case 7:
                    wallsDownloaded = WallsDownloaded.ingaWallsDownloaded;
                    break;
                case 6:
                    wallsDownloaded = WallsDownloaded.jacquelineWallsDownloaded;
                    break;
                case 5:
                    wallsDownloaded = WallsDownloaded.amandaWallsDownloaded;
                    break;
                case 4:
                    wallsDownloaded = WallsDownloaded.skinWallsDownloaded;
                    break;
                case 3:
                    wallsDownloaded = WallsDownloaded.dollMixWallsDownloaded;
                    break;
                case 2:
                    wallsDownloaded = WallsDownloaded.dollUpWallsDownloaded;
                    break;
                case 1:
                    wallsDownloaded = WallsDownloaded.dollDownWallsDownloaded;
                    break;
                default:
                    break;
            }



            if (DoorhasPlayed)
            {
                replayaudio.enabled = true;
            }

            
            isThisDownloading.itemsDownloaded = 0;
            isThisDownloading.itemsToDownload = 0;
            StartCoroutine(GetAudioAndWalls());
        }

    }

        IEnumerator GetAudioAndWalls()
    {
      

        if(wallsDownloaded == true)
        {
            yield return null;
            isThisDownloading.isDownloading = false;
        }

        if (!wallsDownloaded)
        {
            isThisDownloading.isDownloading = true;

            loadingtext.enabled = true;


            isThisDownloading.itemsToDownload = isThisDownloading.itemsToDownload + 1;
            isThisDownloading.ChangeText();
            



            Coroutine a = StartCoroutine(GetDoorAudio());

            yield return a;


            isThisDownloading.itemsToDownload = isThisDownloading.itemsToDownload + 6;

            isThisDownloading.ChangeText();


            Coroutine b = StartCoroutine(GetCeiling());
            Coroutine c = StartCoroutine(GetRight());
            Coroutine d = StartCoroutine(GetLeft());
            Coroutine e = StartCoroutine(GetFront());
            Coroutine f = StartCoroutine(GetBack());
            Coroutine g = StartCoroutine(GetFloor());


            switch (thisRoom)
            {
                case 9:
                    WallsDownloaded.paintingWallsDownloaded = true;
                    break;
                case 8:
                    WallsDownloaded.fishWallsDownloaded = true;
                    break;
                case 7:
                    WallsDownloaded.ingaWallsDownloaded = true;
                    break;
                case 6:
                    WallsDownloaded.jacquelineWallsDownloaded = true;
                    break;
                case 5:
                    WallsDownloaded.amandaWallsDownloaded = true;
                    break;
                case 4:
                    WallsDownloaded.skinWallsDownloaded = true;
                    break;
                case 3:
                    WallsDownloaded.dollMixWallsDownloaded = true;
                    break;
                case 2:
                    WallsDownloaded.dollUpWallsDownloaded = true;
                    break;
                case 1:
                    WallsDownloaded.dollDownWallsDownloaded = true;
                    break;
                default:
                    break;
            }



            yield return b;
            yield return c;
            yield return d;
            yield return e;
            yield return f;
            yield return g;
            wallsDownloaded = true;

            foreach(GameObject go in windows)
            {
                go.GetComponent<MeshRenderer>().enabled = false;
            }

            isThisDownloading.isDownloading = false;
            

        }

        loadingtext.enabled = false;

    }


    IEnumerator GetDoorAudio()
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(doorurl, AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                myClip1 = DownloadHandlerAudioClip.GetContent(www);
                audioSource1.clip = myClip1;
                Debug.Log("Audio1 has downloaded.");

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSource1.Play();
                DoorhasPlayed = true;
                
            }
        }
    }

    IEnumerator GetCeiling()
    {

    
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(ceilingUrl);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            isThisDownloading.itemsDownloaded++;
            isThisDownloading.ChangeText();
            ceilingTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            ceilingRenderer.material.SetTexture("_MainTex", ceilingTexture);
            
        }
    }

    IEnumerator GetFloor()
    {


        UnityWebRequest www = UnityWebRequestTexture.GetTexture(floorUrl);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            isThisDownloading.itemsDownloaded++;
            isThisDownloading.ChangeText();
            floorTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            floorRenderer.material.SetTexture("_MainTex", floorTexture);
        }
    }

    IEnumerator GetRight()
    {


        UnityWebRequest www = UnityWebRequestTexture.GetTexture(rightUrl);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            isThisDownloading.itemsDownloaded++;
            isThisDownloading.ChangeText();
            rightTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            rightRenderer.material.SetTexture("_MainTex", rightTexture);
        }
    }

    IEnumerator GetLeft()
    {


        UnityWebRequest www = UnityWebRequestTexture.GetTexture(leftUrl);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            isThisDownloading.itemsDownloaded++;
            isThisDownloading.ChangeText();
            leftTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            leftRenderer.material.SetTexture("_MainTex", leftTexture);
        }
    }

    IEnumerator GetBack()
    {


        UnityWebRequest www = UnityWebRequestTexture.GetTexture(backUrl);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            isThisDownloading.itemsDownloaded++;
            isThisDownloading.ChangeText();
            backTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            backRenderer.material.SetTexture("_MainTex", backTexture);

        }
    }

    IEnumerator GetFront()
    {


        UnityWebRequest www = UnityWebRequestTexture.GetTexture(frontUrl);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            isThisDownloading.itemsDownloaded++;
            isThisDownloading.ChangeText();
            frontTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            frontRenderer.material.SetTexture("_MainTex", frontTexture);
        }
    }


    private void OnTriggerExit(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            replayaudio.enabled = false;
        }
    }
    public void ReplayDoorAudio()
    {
        audioSource1.Play();
    }
}

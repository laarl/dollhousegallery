using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetAllJacqueline : MonoBehaviour
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





    public string Url1;
    public Texture Texture1;
    public Renderer Renderer1;

    public string Url2;
    public Texture Texture2;
    public Renderer Renderer2;

    public string Url3;
    public Texture Texture3;
    public Renderer Renderer3;

    public string Url4;
    public Texture Texture4;
    public Renderer Renderer4;

    public string Url5;
    public Texture Texture5;
    public Renderer Renderer5;

    public string Url6;
    public Texture Texture6;
    public Renderer Renderer6;

    public string Url7;
    public Texture Texture7;
    public Renderer Renderer7;



    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            wallsDownloaded = WallsDownloaded.jacquelineWallsDownloaded;


            if (DoorhasPlayed)
            {
                replayaudio.enabled = true;
            }

            if (!WallsDownloaded.jacquelineWallsDownloaded) { 
                isThisDownloading.itemsDownloaded = 0;
                isThisDownloading.itemsToDownload = 0;
                StartCoroutine(GetAudioAndWalls());
            }
        }

    }

    IEnumerator GetAudioAndWalls()
    {


        if (wallsDownloaded == true)
        {
            yield return null;
            isThisDownloading.isDownloading = false;
        }

        if (!WallsDownloaded.jacquelineWallsDownloaded)
        {

            isThisDownloading.isDownloading = true;
            isThisDownloading.itemsToDownload = isThisDownloading.itemsToDownload + 1;
            isThisDownloading.ChangeText();
            loadingtext.enabled = true;



            Coroutine a = StartCoroutine(GetDoorAudio());

            yield return a;



           // isThisDownloading.isDownloading = true;
            isThisDownloading.itemsToDownload = isThisDownloading.itemsToDownload + 13;

           // loadingtext.enabled = true;
            isThisDownloading.ChangeText();


            Coroutine b = StartCoroutine(GetCeiling());
            Coroutine c = StartCoroutine(GetRight());
            Coroutine d = StartCoroutine(GetLeft());
            Coroutine e = StartCoroutine(GetFront());
            Coroutine f = StartCoroutine(GetBack());
            Coroutine g = StartCoroutine(GetFloor());


            Coroutine h = StartCoroutine(GetImage1());
            Coroutine i = StartCoroutine(GetImage2());
            Coroutine j = StartCoroutine(GetImage3());
            Coroutine k = StartCoroutine(GetImage4());
            Coroutine l = StartCoroutine(GetImage5());
            Coroutine m = StartCoroutine(GetImage6());
            Coroutine n = StartCoroutine(GetImage7());



            yield return b;
            yield return c;
            yield return d;
            yield return e;
            yield return f;
            yield return g;
            yield return h;
            yield return i;
            yield return j;
            yield return k;
            yield return l;
            yield return m;
            yield return n;

            wallsDownloaded = true;

            foreach (GameObject go in windows)
            {
                go.GetComponent<MeshRenderer>().enabled = false;
            }

            isThisDownloading.isDownloading = false;


        }

        loadingtext.enabled = false;
        WallsDownloaded.jacquelineWallsDownloaded = true;

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




    IEnumerator GetImage1()
    {


        UnityWebRequest www = UnityWebRequestTexture.GetTexture(Url1);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            isThisDownloading.itemsDownloaded++;
            isThisDownloading.ChangeText();
            Texture1 = ((DownloadHandlerTexture)www.downloadHandler).texture;
            Renderer1.material.SetTexture("_MainTex", Texture1);
        }
    }


    IEnumerator GetImage2()
    {


        UnityWebRequest www = UnityWebRequestTexture.GetTexture(Url2);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            isThisDownloading.itemsDownloaded++;
            isThisDownloading.ChangeText();
            Texture2 = ((DownloadHandlerTexture)www.downloadHandler).texture;
            Renderer2.material.SetTexture("_MainTex", Texture2);

        }
    }


    IEnumerator GetImage3()
    {


        UnityWebRequest www = UnityWebRequestTexture.GetTexture(Url3);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            isThisDownloading.itemsDownloaded++;
            isThisDownloading.ChangeText();
            Texture3 = ((DownloadHandlerTexture)www.downloadHandler).texture;
            Renderer3.material.SetTexture("_MainTex", Texture3);
        }
    }

    IEnumerator GetImage4()
    {


        UnityWebRequest www = UnityWebRequestTexture.GetTexture(Url4);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            isThisDownloading.itemsDownloaded++;
            isThisDownloading.ChangeText();
            Texture4 = ((DownloadHandlerTexture)www.downloadHandler).texture;
            Renderer4.material.SetTexture("_MainTex", Texture4);
        }
    }

    IEnumerator GetImage5()
    {


        UnityWebRequest www = UnityWebRequestTexture.GetTexture(Url5);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            isThisDownloading.itemsDownloaded++;
            isThisDownloading.ChangeText();
            Texture5 = ((DownloadHandlerTexture)www.downloadHandler).texture;
            Renderer5.material.SetTexture("_MainTex", Texture5);

        }
    }

    IEnumerator GetImage6()
    {


        UnityWebRequest www = UnityWebRequestTexture.GetTexture(Url6);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            isThisDownloading.itemsDownloaded++;
            isThisDownloading.ChangeText();
            Texture6 = ((DownloadHandlerTexture)www.downloadHandler).texture;
            Renderer6.material.SetTexture("_MainTex", Texture6);
        }
    }

    IEnumerator GetImage7()
    {


        UnityWebRequest www = UnityWebRequestTexture.GetTexture(Url7);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            isThisDownloading.itemsDownloaded++;
            isThisDownloading.ChangeText();
            Texture7 = ((DownloadHandlerTexture)www.downloadHandler).texture;
            Renderer7.material.SetTexture("_MainTex", Texture7);
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
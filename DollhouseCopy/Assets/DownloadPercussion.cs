using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DownloadPercussion : MonoBehaviour
{
    public Canvas loadingtext;
    

    public AudioSource audioSource1;
    AudioClip myClip1;
    public string url1;
    



    public AudioSource audioSource2;
    AudioClip myClip2;
    public string url2;
    
    public AudioSource audioSource3;
    AudioClip myClip3;
    public string url3;
    

    public AudioSource audioSource4;
    AudioClip myClip4;
    public string url4;
    
    public AudioSource audioSource5;
    AudioClip myClip5;
    public string url5;
    

    public AudioSource audioSource6;
    AudioClip myClip6;
    public string url6;

    public AudioSource audioSource7;
    AudioClip myClip7;
    public string url7;
    

    public bool hasdownloaded = false;

    void OnTriggerEnter(Collider player)
    {

        if (player.tag == "thisplayer")
        {

            
                LoadPercAudio();

            

        }
    }





    public void LoadPercAudio()
    {


        if (!hasdownloaded)
        {


            isThisDownloading.isDownloading = true;

            isThisDownloading.itemsDownloaded = 0;
            isThisDownloading.itemsToDownload = 10;
            isThisDownloading.ChangeText();

            loadingtext.enabled = true;

            StartCoroutine(GetPercAudio());


            hasdownloaded = true;


        }
        else
        {
            audioSource1.enabled = true;
            audioSource2.enabled = true;
            audioSource3.enabled = true;
            audioSource4.enabled = true;
            audioSource5.enabled = true;
            audioSource6.enabled = true;
            audioSource7.enabled = true;




        }

    }
    IEnumerator GetPercAudio()
    {
        Coroutine a = StartCoroutine(GetPercAudio1());
        Coroutine b = StartCoroutine(GetPercAudio2());
        Coroutine c = StartCoroutine(GetPercAudio3());
        Coroutine d = StartCoroutine(GetPercAudio4());
        Coroutine e = StartCoroutine(GetPercAudio5());
        Coroutine f = StartCoroutine(GetPercAudio6());
        Coroutine g = StartCoroutine(GetPercAudio7());


        yield return a;
        yield return b;
        yield return c;
        yield return d;
        yield return e;
        yield return f;
        yield return g;



        loadingtext.enabled = false;
        isThisDownloading.isDownloading = false;
    }

    IEnumerator GetPercAudio1()
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url1, AudioType.WAV))
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

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSource1.enabled = true;


            }
        }
    }

    IEnumerator GetPercAudio2()
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url2, AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                myClip2 = DownloadHandlerAudioClip.GetContent(www);
                audioSource2.clip = myClip2;

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSource2.enabled = true;


            }
        }
    }

    IEnumerator GetPercAudio3()
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url3, AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                myClip3 = DownloadHandlerAudioClip.GetContent(www);
                audioSource3.clip = myClip3;

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSource3.enabled = true;


            }
        }
    }

    IEnumerator GetPercAudio4()
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url4, AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                myClip4 = DownloadHandlerAudioClip.GetContent(www);
                audioSource4.clip = myClip4;

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSource4.enabled = true;


            }
        }
    }



    IEnumerator GetPercAudio5()
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url5, AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                myClip5 = DownloadHandlerAudioClip.GetContent(www);
                audioSource5.clip = myClip5;

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSource5.enabled = true;


            }
        }
    }

    IEnumerator GetPercAudio6()
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url6, AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                myClip6 = DownloadHandlerAudioClip.GetContent(www);
                audioSource6.clip = myClip6;

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSource6.enabled = true;


            }
        }
    }


    IEnumerator GetPercAudio7()
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url7, AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                myClip7 = DownloadHandlerAudioClip.GetContent(www);
                audioSource7.clip = myClip7;

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSource7.enabled = true;


            }
        }
    }


    void OnTriggerExit(Collider player)
    {

        if (player.tag == "thisplayer")
        {




            audioSource1.enabled = false;
            audioSource2.enabled = false;
            audioSource3.enabled = false;
            audioSource4.enabled = false;
            audioSource5.enabled = false;
            audioSource6.enabled = false;
            audioSource7.enabled = false;
            

        }
    }
}

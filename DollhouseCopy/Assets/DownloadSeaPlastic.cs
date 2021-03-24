using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DownloadSeaPlastic : MonoBehaviour
{
    public Canvas loadingtext;
    

    public AudioSource audioSource0;
    AudioClip myClip0;
    public string url0;

    public AudioSource audioSource1;
    AudioClip myClip1;
    public string url1;
    public MeshRenderer source1;
    public Canvas controls1;


    public AudioSource audioSource2;
    AudioClip myClip2;
    public string url2;
    public MeshRenderer source2;
    public Canvas controls2;


    public AudioSource audioSource3;
    AudioClip myClip3;
    public string url3;
    public MeshRenderer source3;
    public Canvas controls3;

    public AudioSource audioSource4;
    AudioClip myClip4;
    public string url4;
    public MeshRenderer source4;
    public Canvas controls4;

    public AudioSource audioSource5;
    AudioClip myClip5;
    public string url5;
    public MeshRenderer source5;
    public Canvas controls5;


    public bool hasdownloaded = false;



    void OnTriggerEnter(Collider player)
    {

        if (player.tag == "thisplayer")
        {
            LoadSeaAudio();

            

        }
    }
    public void LoadSeaAudio()
    {


        if (!hasdownloaded)
        {


            isThisDownloading.isDownloading = true;

            isThisDownloading.itemsDownloaded = 0;
            isThisDownloading.itemsToDownload = 6;
            isThisDownloading.ChangeText();

            loadingtext.enabled = true;

            StartCoroutine(GetSeaAudio());


            hasdownloaded = true;


        }
        else
        {
            audioSource1.enabled = true;
            audioSource2.enabled = true;
            audioSource3.enabled = true;
            audioSource4.enabled = true;
            audioSource5.enabled = true;

            controls1.enabled = true;
            controls2.enabled = true;
            controls3.enabled = true;
            controls4.enabled = true;
            controls5.enabled = true;

        }

    }


    IEnumerator GetSeaAudio()
    {
        Coroutine a = StartCoroutine(GetSeaDoor());
        Coroutine b = StartCoroutine(GetSeaAudio1());
        Coroutine c = StartCoroutine(GetSeaAudio2());
        Coroutine d = StartCoroutine(GetSeaAudio3());
        Coroutine e = StartCoroutine(GetSeaAudio4());
        Coroutine f = StartCoroutine(GetSeaAudio5());


        yield return a;
        yield return b;
        yield return c;
        yield return d;
        yield return e;
        yield return f;



        loadingtext.enabled = false;
        isThisDownloading.isDownloading = false;
    }

    IEnumerator GetSeaDoor()
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url0, AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                myClip0 = DownloadHandlerAudioClip.GetContent(www);
                audioSource0.clip = myClip0;

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSource0.enabled = true;


                audioSource0.Play();
            }
        }
    }






    IEnumerator GetSeaAudio1()
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
                source1.enabled = true;

                controls1.enabled = true;
            }
        }
    }

    IEnumerator GetSeaAudio2()
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
                source2.enabled = true;

                controls2.enabled = true;
            }
        }
    }

    IEnumerator GetSeaAudio3()
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
                source3.enabled = true;

                controls3.enabled = true;
            }
        }
    }

    IEnumerator GetSeaAudio4()
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
                source4.enabled = true;

                controls4.enabled = true;
            }
        }
    }

    IEnumerator GetSeaAudio5()
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
                source5.enabled = true;

                controls5.enabled = true;
            }
        }
    }


    void OnTriggerExit(Collider player)
    {

        if (player.tag == "thisplayer")
        {
            controls1.enabled = false;
            controls2.enabled = false;
            controls3.enabled = false;
            controls4.enabled = false;
            controls5.enabled = false;
        }
    }


    public void PlayAudio1()
    {
        audioSource1.Play();
    }

    public void PauseAudio1()
    {
        audioSource1.Pause();
    }

    public void StopAudio1()
    {
        audioSource1.Stop();
    }


    public void PlayAudio2()
    {
        audioSource2.Play();
    }

    public void PauseAudio2()
    {
        audioSource2.Pause();
    }

    public void StopAudio2()
    {
        audioSource2.Stop();
    }


    public void PlayAudio3()
    {
        audioSource3.Play();
    }

    public void PauseAudio3()
    {
        audioSource3.Pause();
    }

    public void StopAudio3()
    {
        audioSource3.Stop();
    }


    public void PlayAudio4()
    {
        audioSource4.Play();
    }

    public void PauseAudio4()
    {
        audioSource4.Pause();
    }

    public void StopAudio4()
    {
        audioSource4.Stop();
    }


    public void PlayAudio5()
    {
        audioSource5.Play();
    }

    public void PauseAudio5()
    {
        audioSource5.Pause();
    }

    public void StopAudio5()
    {
        audioSource5.Stop();
    }

}
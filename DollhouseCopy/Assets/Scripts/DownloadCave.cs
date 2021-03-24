using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DownloadCave: MonoBehaviour
{
    public Canvas loadCaveAudio;
    public Canvas loadingtext;

    public AudioSource audioSource1;
    AudioClip myClip1;
    public string url1;
    public MeshRenderer source1;

    public AudioSource audioSource2;
    AudioClip myClip2;
    public string url2;
    public MeshRenderer source2;


    public AudioSource audioSource3;
    AudioClip myClip3;
    public string url3;
    public MeshRenderer source3;

    public AudioSource audioSource4;
    AudioClip myClip4;
    public string url4;
    public MeshRenderer source4;

	public AudioSource audioSource5;
	AudioClip myClip5;
	public string url5;
	public MeshRenderer source5;

	public AudioSource audioSource6;
	AudioClip myClip6;
	public string url6;
	public MeshRenderer source6;

	public bool hasdownloaded = false;

    void OnTriggerEnter(Collider player)
    {

        if (player.tag == "thisplayer")
        {
            if (!hasdownloaded)
            {
                loadCaveAudio.enabled = true;
            }

            if(hasdownloaded)
            {
                LoadCaveAudio();
            }
            
        }
    }


    public void LoadCaveAudio()
    {
        GameObject.Find("TriggersBenJessAudio").GetComponent<TriggersBenJess>().enabled = true;

        if (!hasdownloaded)
        {


            isThisDownloading.isDownloading = true;

            isThisDownloading.itemsDownloaded = 0;
            isThisDownloading.itemsToDownload = isThisDownloading.itemsToDownload + 6;
            isThisDownloading.ChangeText();

            loadingtext.enabled = true;

            StartCoroutine(GetCaveAudio());


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
        }

    }


    IEnumerator GetCaveAudio()
    {
        Coroutine a = StartCoroutine(GetCaveAudio1());
        Coroutine b = StartCoroutine(GetCaveAudio2());
        Coroutine c = StartCoroutine(GetCaveAudio3());
        Coroutine d = StartCoroutine(GetCaveAudio4());
        Coroutine e = StartCoroutine(GetCaveAudio5());
        Coroutine f = StartCoroutine(GetCaveAudio6());

        yield return a;
        yield return b;
        yield return c;
        yield return d;
        yield return e;
        yield return f;

        loadCaveAudio.enabled = false;
        loadingtext.enabled = false;
        isThisDownloading.isDownloading = false;
    }


    IEnumerator GetCaveAudio1()
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

                audioSource1.Play();
            }
        }
    }

    IEnumerator GetCaveAudio2()
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

                audioSource2.Play();
            }
        }
    }

    IEnumerator GetCaveAudio3()
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

            }
        }
    }

    IEnumerator GetCaveAudio4()
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

            }
        }
    }

    IEnumerator GetCaveAudio5()
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


            }
        }
    }

    IEnumerator GetCaveAudio6()
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
                source6.enabled = true;


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


            loadCaveAudio.enabled = false;

            GameObject.Find("TriggersBenJessAudio").GetComponent<TriggersBenJess>().enabled = false;
        }
    }
}

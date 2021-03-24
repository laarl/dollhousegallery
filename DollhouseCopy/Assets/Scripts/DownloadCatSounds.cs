using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DownloadCatSounds : MonoBehaviour
{

    public Canvas loadingtext;
    public Canvas loadCatAudio;

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

    public string url5;
    public Texture Texture1;
    public Renderer Renderer1;




    public AudioSource audioSource5;
    AudioClip myClip5;
    public string url6;
    public MeshRenderer source5;

    public AudioSource audioSource6;
    AudioClip myClip6;
    public string url7;
    public MeshRenderer source6;

    public AudioSource audioSource7;
    AudioClip myClip7;
    public string url8;
    public MeshRenderer source7;

    public AudioSource audioSource8;
    AudioClip myClip8;
    public string url9;
    public MeshRenderer source8;

    public AudioSource audioSource9;
    AudioClip myClip9;
    public string url10;
    public MeshRenderer source9;

    public GameObject catsound1;
    public GameObject catsound2;
    public GameObject catsound3;
    public GameObject catsound4;
    public GameObject catsound5;
    public GameObject catsound6;
    public GameObject catsound7;
    public GameObject catsound8;
    public GameObject catsound9;

    public bool hasdownloaded = false;

    void OnTriggerEnter(Collider player)
    {

        if (player.tag == "thisplayer")
        {

            if (!hasdownloaded)
            {

                loadCatAudio.enabled = true;

                
                
            }

            catsound1.GetComponent<PlaySoundTrigger>().enabled = true;
            catsound2.GetComponent<PlaySoundTrigger>().enabled = true;
            catsound3.GetComponent<PlaySoundTrigger>().enabled = true;
            catsound4.GetComponent<PlaySoundTrigger>().enabled = true;
            catsound5.GetComponent<PlaySoundTrigger>().enabled = true;
            catsound6.GetComponent<PlaySoundTrigger>().enabled = true;
            catsound7.GetComponent<PlaySoundTrigger>().enabled = true;
            catsound8.GetComponent<PlaySoundTrigger>().enabled = true;
            catsound9.GetComponent<PlaySoundTrigger>().enabled = true;


        }
    }




    
    public void LoadCatAudio()
    {


        if (!hasdownloaded)
        {


            isThisDownloading.isDownloading = true;

            isThisDownloading.itemsDownloaded = 0;
            isThisDownloading.itemsToDownload = 10;
            isThisDownloading.ChangeText();

            loadingtext.enabled = true;

            StartCoroutine(GetCatAudio());


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
            audioSource8.enabled = true;
            audioSource9.enabled = true;



        }

    }
    IEnumerator GetCatAudio()
    {
        Coroutine a = StartCoroutine(GetCatAudio1());
        Coroutine b = StartCoroutine(GetCatAudio2());
        Coroutine c = StartCoroutine(GetCatAudio3());
        Coroutine d = StartCoroutine(GetCatAudio4());
        Coroutine e = StartCoroutine(GetCatAudio5());
        Coroutine f = StartCoroutine(GetCatAudio6());
        Coroutine g = StartCoroutine(GetCatAudio7());
        Coroutine h = StartCoroutine(GetCatAudio8());
        Coroutine i = StartCoroutine(GetCatAudio9());
        Coroutine j = StartCoroutine(GetImage1());

        yield return a;
        yield return b;
        yield return c;
        yield return d;
        yield return e;
        yield return f;
        yield return g;
        yield return h;
        yield return i;
        yield return j;

        loadCatAudio.enabled = false;
        loadingtext.enabled = false;
        isThisDownloading.isDownloading = false;
    }

    IEnumerator GetCatAudio1()
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

            }
        }
    }

    IEnumerator GetCatAudio2()
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

            }
        }
    }

    IEnumerator GetCatAudio3()
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

    IEnumerator GetCatAudio4()
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



    IEnumerator GetCatAudio5()
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
                myClip5 = DownloadHandlerAudioClip.GetContent(www);
                audioSource5.clip = myClip5;

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSource5.enabled = true;
                source5.enabled = true;

            }
        }
    }

    IEnumerator GetCatAudio6()
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
                myClip6 = DownloadHandlerAudioClip.GetContent(www);
                audioSource6.clip = myClip6;

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSource6.enabled = true;
                source6.enabled = true;

            }
        }
    }


    IEnumerator GetCatAudio7()
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url8, AudioType.WAV))
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
                source7.enabled = true;

            }
        }
    }

    IEnumerator GetCatAudio8()
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url9, AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                myClip8 = DownloadHandlerAudioClip.GetContent(www);
                audioSource8.clip = myClip8;

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSource8.enabled = true;
                source8.enabled = true;

            }
        }
    }

    IEnumerator GetCatAudio9()
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url10, AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                myClip9 = DownloadHandlerAudioClip.GetContent(www);
                audioSource8.clip = myClip9;

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSource9.enabled = true;
                source9.enabled = true;

            }
        }
    }


    IEnumerator GetImage1()
    {


        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url5);
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

    void OnTriggerExit(Collider player)
    {

        if (player.tag == "thisplayer")
        {

            loadCatAudio.enabled = false;


            audioSource1.enabled = false;
            audioSource2.enabled = false;
            audioSource3.enabled = false;
            audioSource4.enabled = false;
            audioSource5.enabled = false;
            audioSource6.enabled = false;
            audioSource7.enabled = false;
            audioSource8.enabled = false;
            audioSource9.enabled = false;

            catsound1.GetComponent<PlaySoundTrigger>().enabled = false;
            catsound2.GetComponent<PlaySoundTrigger>().enabled = false;
            catsound3.GetComponent<PlaySoundTrigger>().enabled = false;
            catsound4.GetComponent<PlaySoundTrigger>().enabled = false;
            catsound5.GetComponent<PlaySoundTrigger>().enabled = false;
            catsound6.GetComponent<PlaySoundTrigger>().enabled = false;
            catsound7.GetComponent<PlaySoundTrigger>().enabled = false;
            catsound8.GetComponent<PlaySoundTrigger>().enabled = false;
            catsound9.GetComponent<PlaySoundTrigger>().enabled = false;

        }
    }

}

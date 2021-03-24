using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LoadStairAudio : MonoBehaviour
{

    public Canvas loadBrian;
    public Canvas loadingtext;
    public Button LoadBrianButton;

    public bool hasdownloaded = false;
    public GameObject StairAudio;
    public GameObject masterTrigger;


    public GameObject Staircase;


    public AudioSource[] audioSources;
    public string[] urls;
    public AudioClip[] audioClips;

    


    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "thisplayer")
        {

        
            if (!hasdownloaded)
            {
            
                    loadBrian.enabled = true;
            }

            
            
            
        }

    }

    private void OnTriggerExit(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            loadBrian.enabled = false;

            if (hasdownloaded)
            {
                StairAudio.SetActive(false);
                masterTrigger.GetComponent<masteraudiotrigger>().enabled = false;
            }

            
        }
            

        
    }


    public void LoadBrian()
    {
        Staircase.SetActive(true);
        StairAudio.SetActive(true);

        isThisDownloading.isDownloading = true;

        isThisDownloading.itemsDownloaded = 0;
        isThisDownloading.itemsToDownload = 18;
        isThisDownloading.ChangeText();
        loadingtext.enabled = true;
        StartCoroutine(GetBrian());

    }

    
    IEnumerator GetBrian()
    {
        Coroutine a = StartCoroutine(GetAudioClip1());
        Coroutine b = StartCoroutine(GetAudioClip2());
        Coroutine c = StartCoroutine(GetAudioClip3());
        Coroutine d = StartCoroutine(GetAudioClip4());
        Coroutine e = StartCoroutine(GetAudioClip5());
        Coroutine f = StartCoroutine(GetAudioClip6());
        Coroutine g = StartCoroutine(GetAudioClip7());
        Coroutine h = StartCoroutine(GetAudioClip8());
        Coroutine i = StartCoroutine(GetAudioClip9());
        Coroutine j = StartCoroutine(GetAudioClip10());
        Coroutine k = StartCoroutine(GetAudioClip11());
        Coroutine l = StartCoroutine(GetAudioClip12());
        Coroutine m = StartCoroutine(GetAudioClip13());
        Coroutine n = StartCoroutine(GetAudioClip14());
        Coroutine o = StartCoroutine(GetAudioClip15());
        Coroutine p = StartCoroutine(GetAudioClip16());
        Coroutine q = StartCoroutine(GetAudioClip17());
        Coroutine r = StartCoroutine(GetAudioClip18());


        LoadBrianButton.enabled = false;
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
        yield return k;
        yield return l;
        yield return m;
        yield return n;
        yield return o;
        yield return p;
        yield return q;
        yield return r;

        loadBrian.enabled = false;
        
        isThisDownloading.isDownloading = false;
        hasdownloaded = true;
        loadingtext.enabled = false;
        masterTrigger.GetComponent<masteraudiotrigger>().enabled = true;
        isThisDownloading.itemsToDownload = 0;


    }


    IEnumerator GetAudioClip1()
    {


        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(urls[0], AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                audioClips[0] = DownloadHandlerAudioClip.GetContent(www);
                audioSources[0].clip = audioClips[0];

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSources[0].enabled = true;
                audioSources[0].enabled = true;

            }
        }
    }

    IEnumerator GetAudioClip2()
    {


        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(urls[1], AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                audioClips[1] = DownloadHandlerAudioClip.GetContent(www);
                audioSources[1].clip = audioClips[1];

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSources[1].enabled = true;
                audioSources[1].enabled = true;

            }
        }
    }

    IEnumerator GetAudioClip3()
    {


        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(urls[2], AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                audioClips[2] = DownloadHandlerAudioClip.GetContent(www);
                audioSources[2].clip = audioClips[2];

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSources[2].enabled = true;
                audioSources[2].enabled = true;

            }
        }
    }

    IEnumerator GetAudioClip4()
    {


        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(urls[3], AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                audioClips[3] = DownloadHandlerAudioClip.GetContent(www);
                audioSources[3].clip = audioClips[3];

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSources[3].enabled = true;
                audioSources[3].enabled = true;

            }
        }
    }

    IEnumerator GetAudioClip5()
    {


        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(urls[4], AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                audioClips[4] = DownloadHandlerAudioClip.GetContent(www);
                audioSources[4].clip = audioClips[4];

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSources[4].enabled = true;
                audioSources[4].enabled = true;

            }
        }
    }

    IEnumerator GetAudioClip6()
    {


        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(urls[5], AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                audioClips[5] = DownloadHandlerAudioClip.GetContent(www);
                audioSources[5].clip = audioClips[5];

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSources[5].enabled = true;
                audioSources[5].enabled = true;

            }
        }
    }

    IEnumerator GetAudioClip7()
    {


        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(urls[6], AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                audioClips[6] = DownloadHandlerAudioClip.GetContent(www);
                audioSources[6].clip = audioClips[6];

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSources[6].enabled = true;
                audioSources[6].enabled = true;

            }
        }
    }

    IEnumerator GetAudioClip8()
    {


        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(urls[7], AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                audioClips[7] = DownloadHandlerAudioClip.GetContent(www);
                audioSources[7].clip = audioClips[7];

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSources[7].enabled = true;
                audioSources[7].enabled = true;

            }
        }
    }

    IEnumerator GetAudioClip9()
    {


        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(urls[8], AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                audioClips[8] = DownloadHandlerAudioClip.GetContent(www);
                audioSources[8].clip = audioClips[8];

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSources[8].enabled = true;
                audioSources[8].enabled = true;

            }
        }
    }

    IEnumerator GetAudioClip10()
    {


        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(urls[9], AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                audioClips[9] = DownloadHandlerAudioClip.GetContent(www);
                audioSources[9].clip = audioClips[9];

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSources[9].enabled = true;
                audioSources[9].enabled = true;

            }
        }
    }

    IEnumerator GetAudioClip11()
    {


        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(urls[10], AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                audioClips[10] = DownloadHandlerAudioClip.GetContent(www);
                audioSources[10].clip = audioClips[10];

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSources[10].enabled = true;
                audioSources[10].enabled = true;

            }
        }
    }

    IEnumerator GetAudioClip12()
    {


        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(urls[11], AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                audioClips[11] = DownloadHandlerAudioClip.GetContent(www);
                audioSources[11].clip = audioClips[11];

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSources[11].enabled = true;
                audioSources[11].enabled = true;

            }
        }
    }

    IEnumerator GetAudioClip13()
    {


        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(urls[12], AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                audioClips[12] = DownloadHandlerAudioClip.GetContent(www);
                audioSources[12].clip = audioClips[12];

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();
                
                audioSources[12].enabled = true;
                audioSources[12].enabled = true;

            }
        }
    }

    IEnumerator GetAudioClip14()
    {


        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(urls[13], AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                audioClips[13] = DownloadHandlerAudioClip.GetContent(www);
                audioSources[13].clip = audioClips[13];

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSources[13].enabled = true;
                audioSources[13].enabled = true;

            }
        }
    }

    IEnumerator GetAudioClip15()
    {


        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(urls[14], AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                audioClips[14] = DownloadHandlerAudioClip.GetContent(www);
                audioSources[14].clip = audioClips[14];

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSources[14].enabled = true;
                audioSources[14].enabled = true;

            }
        }
    }

    IEnumerator GetAudioClip16()
    {


        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(urls[15], AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                audioClips[15] = DownloadHandlerAudioClip.GetContent(www);
                audioSources[15].clip = audioClips[15];

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSources[15].enabled = true;
                audioSources[15].enabled = true;

            }
        }
    }

    IEnumerator GetAudioClip17()
    {


        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(urls[16], AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                audioClips[16] = DownloadHandlerAudioClip.GetContent(www);
                audioSources[16].clip = audioClips[16];

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSources[16].enabled = true;
                audioSources[16].enabled = true;

            }
        }
    }

    IEnumerator GetAudioClip18()
    {


        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(urls[17], AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                audioClips[17] = DownloadHandlerAudioClip.GetContent(www);
                audioSources[17].clip = audioClips[17];

                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                audioSources[17].enabled = true;
                audioSources[17].enabled = true;

            }
        }
    }


}

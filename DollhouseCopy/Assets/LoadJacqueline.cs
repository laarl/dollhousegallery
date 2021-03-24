using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LoadJacqueline : MonoBehaviour
{
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


    public bool imagesDownloaded = false;


    public Canvas loadingtext;


    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            if (!imagesDownloaded)
            {
                StartCoroutine(GetJacquelinePhotos());
            }
        }

    }

    IEnumerator GetJacquelinePhotos()
    {

        if (imagesDownloaded == true)
        {
            yield return null;
            isThisDownloading.isDownloading = false;
        }

        if (!imagesDownloaded)
        {
            
            isThisDownloading.isDownloading = true;
            isThisDownloading.itemsToDownload = isThisDownloading.itemsToDownload + 7;

            loadingtext.enabled = true;
            isThisDownloading.ChangeText();


            Coroutine a = StartCoroutine(GetImage1());
            Coroutine b = StartCoroutine(GetImage2());
            Coroutine c = StartCoroutine(GetImage3());
            Coroutine d = StartCoroutine(GetImage4());
            Coroutine e = StartCoroutine(GetImage5());
            Coroutine f = StartCoroutine(GetImage6());
            Coroutine g = StartCoroutine(GetImage7());

            yield return a;
            yield return b;
            yield return c;
            yield return d;
            yield return e;
            yield return f;
            yield return g;

            imagesDownloaded = true;

           

            isThisDownloading.isDownloading = false;


        }

        loadingtext.enabled = false;

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
        
    }

    
}

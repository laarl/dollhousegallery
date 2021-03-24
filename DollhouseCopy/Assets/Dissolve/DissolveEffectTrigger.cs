using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DissolveEffectTrigger : MonoBehaviour
{
    
    public float speed, max;

    public string Url1;
    public Texture Texture1;
    public Material dissolveMaterial1;
    

    public string Url2;
    public Texture Texture2;
    public Material dissolveMaterial2;
    

    public string Url3;
    public Texture Texture3;
    public Material dissolveMaterial3;
    

    public string Url4;
    public Texture Texture4;
    public Material dissolveMaterial4;
    

    public string Url5;
    public Texture Texture5;
    public Material dissolveMaterial5;
    

    public string Url6;
    public Texture Texture6;
    public Material dissolveMaterial6;



    public static float currentY, startTime;


    public bool imagesDownloaded;


    public Canvas loadingtext;
    public Canvas IndiraImages;

    private void Start()
    {
        IndiraImages.sortingOrder = -1;
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            IndiraImages.enabled = true;

            if (!imagesDownloaded)
            {
                StartCoroutine(GetIndiraPhotos());
            }
        }

    }

    IEnumerator GetIndiraPhotos()
    {

        if (imagesDownloaded == true)
        {
            yield return null;
            isThisDownloading.isDownloading = false;
        }

        if (!imagesDownloaded)
        {
            
            isThisDownloading.isDownloading = true;
            isThisDownloading.itemsToDownload = isThisDownloading.itemsToDownload + 6;

            loadingtext.enabled = true;
            isThisDownloading.ChangeText();


            Coroutine a = StartCoroutine(GetImage1());
            Coroutine b = StartCoroutine(GetImage2());
            Coroutine c = StartCoroutine(GetImage3());
            Coroutine d = StartCoroutine(GetImage4());
            Coroutine e = StartCoroutine(GetImage5());
            Coroutine f = StartCoroutine(GetImage6());


            yield return a;
            yield return b;
            yield return c;
            yield return d;
            yield return e;
            yield return f;

            imagesDownloaded = true;

            //loadIndira.enabled = false;

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
            dissolveMaterial1.SetTexture("_MainTex", Texture1);
            dissolveMaterial1.SetTexture("_DissolveTexture", Texture1);
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
            dissolveMaterial2.SetTexture("_MainTex", Texture2);
            dissolveMaterial2.SetTexture("_DissolveTexture", Texture2);
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
            dissolveMaterial3.SetTexture("_MainTex", Texture3);
            dissolveMaterial3.SetTexture("_DissolveTexture", Texture3);
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
            dissolveMaterial4.SetTexture("_MainTex", Texture4);
            dissolveMaterial4.SetTexture("_DissolveTexture", Texture4);
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
            dissolveMaterial5.SetTexture("_MainTex", Texture5);
            dissolveMaterial5.SetTexture("_DissolveTexture", Texture5);

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
            dissolveMaterial6.SetTexture("_MainTex", Texture6);
            dissolveMaterial6.SetTexture("_DissolveTexture", Texture6);
        }
    }


    private void OnTriggerExit(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            IndiraImages.enabled = false;
        }
    }

    public void DownloadIndira()
    {
        StartCoroutine(GetIndiraPhotos());
    }


    

    private void Update()
    {
        
            dissolveMaterial1.SetFloat("_DissolveY", currentY);
            dissolveMaterial2.SetFloat("_DissolveY", currentY);
            dissolveMaterial3.SetFloat("_DissolveY", currentY);
            dissolveMaterial4.SetFloat("_DissolveY", currentY);
            dissolveMaterial5.SetFloat("_DissolveY", currentY);
            dissolveMaterial6.SetFloat("_DissolveY", currentY);
            currentY += Time.deltaTime * speed;
        

        //if (Input.GetKeyDown(KeyCode.E))
            //TriggerEffect();    
    }

    /*
    public static void TriggerEffect()
    {
        startTime = Time.time;
        currentY = 300;
    }
    */
}

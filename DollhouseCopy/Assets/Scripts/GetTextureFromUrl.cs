using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetTextureFromUrl : MonoBehaviour
{
    public string url;
    public Texture myTexture;
    Renderer myRenderer;

    public bool isDownloaded = false;

    void Start()
    {
        myRenderer = GetComponent<Renderer>();
        StartCoroutine(GetTexture());
    }

    IEnumerator GetTexture()
    {

        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            myRenderer.material.SetTexture("_MainTex", myTexture);

            isDownloaded = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RingMakeupSlideshow : MonoBehaviour
{
    public string[] urlArray = new string[23];
    public string[] descriptionArray = new string[23];

    int thisurl = 0;
    public string url;
    public string description;

    public Texture myTexture;
    Renderer myRenderer;

    public Canvas Buttons;
    public TextMesh descriptionText;

    public GameObject nextButton;
    public GameObject nextButtonText;

    public GameObject prevButton;
    public GameObject prevButtonText;



    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            url = urlArray[thisurl];
            description = descriptionArray[thisurl];

            myRenderer = GetComponent<Renderer>();
            StartCoroutine(GetTexture());

            Buttons.enabled = true;
            /*
            nextButton.GetComponent<Text>().enabled = true;
            nextButton.GetComponent<Image>().enabled = true;
            prevButton.GetComponent<Text>().enabled = true;
            prevButton.GetComponent<Image>().enabled = true;
            */
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            Buttons.enabled = false;
        }
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
        }

        descriptionText.GetComponent<TextMesh>().text = description;
    }

    public void NextImage()
    {
        if (thisurl != 22)
        {

            thisurl++;


            url = urlArray[thisurl];
            description = descriptionArray[thisurl];

            StartCoroutine(GetTexture());
        }
    }

    public void LastImage()
    {

        if(thisurl != 0) { 
            thisurl--;


            url = urlArray[thisurl];
            description = descriptionArray[thisurl];

            StartCoroutine(GetTexture());
        }
    }
}

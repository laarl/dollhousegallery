using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AudioLoadTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    AudioClip myClip;
    
    public string url;

    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            //audioSource = GetComponent<AudioSource>();
            StartCoroutine(GetAudioClip());
            Debug.Log("Starting to download the audio...");
        }
    }

    IEnumerator GetAudioClip()
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.WAV))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                myClip = DownloadHandlerAudioClip.GetContent(www);
                audioSource.clip = myClip;
                audioSource.Play();
                Debug.Log("Audio has downloaded.");
               

            }
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            audioSource.Stop();
        }
    }
}

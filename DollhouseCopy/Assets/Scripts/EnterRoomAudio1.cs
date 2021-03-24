using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Audio;
using UnityEngine.UI;

public class EnterRoomAudio1 : MonoBehaviour
{
    public AudioSource audioSource1;
    AudioClip myClip1;
    public string url1;
    private bool hasPlayed = false;
    public Canvas replayaudio;

    public Canvas loadingtext;


    IEnumerator GetAudioClip1()
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
                
                isThisDownloading.isDownloading = false;
                isThisDownloading.itemsDownloaded++;
                isThisDownloading.ChangeText();

                loadingtext.enabled = false;
                audioSource1.Play();
                hasPlayed = true;

            }
        }
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            if (!hasPlayed)
            {
                isThisDownloading.itemsDownloaded = 0;
                isThisDownloading.isDownloading = true;
                isThisDownloading.itemsToDownload = 1;

                loadingtext.enabled = true;
                isThisDownloading.ChangeText();

                StartCoroutine(GetAudioClip1());
                

            }

            else
            {
                loadingtext.enabled = false;
                replayaudio.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            replayaudio.enabled = false;
            loadingtext.enabled = false;
        }
    }


    public void playAudio1()
    {
        audioSource1.Play();
    }
}

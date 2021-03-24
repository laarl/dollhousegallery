using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Audio;
using UnityEngine.UI;

public class EnterRoomAudio : MonoBehaviour
{
    public AudioSource audioSource1;
    AudioClip myClip1;
    public string url1;
    private bool hasPlayed = false;
    public Canvas replayaudio;


    void Start()
    {
        StartCoroutine(GetAudioClip1());
        Debug.Log("Starting to download alex...");

    }

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
                Debug.Log("Audio1 has downloaded.");


            }
        }
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            if (!hasPlayed)
            {
                audioSource1.Play();
                hasPlayed = true;

            }

            else
            {
                replayaudio.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            replayaudio.enabled = false;
        }
    }


    public void playAudio1()
    {
        audioSource1.Play();
    }
}

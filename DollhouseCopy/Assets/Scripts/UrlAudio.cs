using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UrlAudio : MonoBehaviour
{

	AudioSource audioSource;
	AudioClip myClip;
    public GameObject Playbutton;
    public GameObject Playtext;
    public string url;
    

	void Start()
	{
        Playtext.GetComponent<Text>().enabled = false;
        Playbutton.GetComponent<Image>().enabled = false;


        audioSource = GetComponent<AudioSource>();
		StartCoroutine(GetAudioClip());
		Debug.Log("Starting to download the audio...");
	}

	IEnumerator GetAudioClip()
	{
		using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("http://wiggly.laar.world/vln5.wav", AudioType.WAV))
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
				//audioSource.Play();
				Debug.Log("Audio has downloaded.");
                Playtext.GetComponent<Text>().enabled = true;
                Playbutton.GetComponent<Image>().enabled = true;
                
			}
		}
	}


	public void pauseAudio()
	{
		audioSource.Pause();
	}

	public void playAudio()
	{
		audioSource.Play();
	}

	public void stopAudio()
	{
		audioSource.Stop();

	}
}
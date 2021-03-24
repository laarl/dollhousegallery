using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.Audio;

public class TriggerDownloadWAVSearoom : MonoBehaviour
{
    public AudioSource audioSource1;
    AudioClip myClip1;
    public string url1;
    public MeshRenderer source1;

    public GameObject Playbutton1;
    public GameObject Playtext1;
    public GameObject Pausebutton1;
    public GameObject Pausetext1;
    public GameObject Stopbutton1;
    public GameObject Stoptext1;

    public bool audioSource1downloaded = false;


    public AudioSource audioSource2;
    AudioClip myClip2;
    public string url2;
    public MeshRenderer source2;

    public GameObject Playbutton2;
    public GameObject Playtext2;
    public GameObject Pausebutton2;
    public GameObject Pausetext2;
    public GameObject Stopbutton2;
    public GameObject Stoptext2;

    public bool audioSource2downloaded = false;


    public AudioSource audioSource3;
    AudioClip myClip3;
    public string url3;
    public MeshRenderer source3;
    public GameObject Playbutton3;
    public GameObject Playtext3;
    public GameObject Pausebutton3;
    public GameObject Pausetext3;
    public GameObject Stopbutton3;
    public GameObject Stoptext3;

    public bool audioSource3downloaded = false;

    public Canvas buttons;

    void Start()
    {
        source1.enabled = false;
        source2.enabled = false;
        source3.enabled = false;

        //buttons.enabled = false;

        

        Playtext1.GetComponent<Text>().enabled = false;
        Playbutton1.GetComponent<Image>().enabled = false;
        Pausetext1.GetComponent<Text>().enabled = false;
        Pausebutton1.GetComponent<Image>().enabled = false;
        Stoptext1.GetComponent<Text>().enabled = false;
        Stopbutton1.GetComponent<Image>().enabled = false;

        

        Playtext2.GetComponent<Text>().enabled = false;
        Playbutton2.GetComponent<Image>().enabled = false;
        Pausetext2.GetComponent<Text>().enabled = false;
        Pausebutton2.GetComponent<Image>().enabled = false;
        Stoptext2.GetComponent<Text>().enabled = false;
        Stopbutton2.GetComponent<Image>().enabled = false;

        

        Playtext3.GetComponent<Text>().enabled = false;
        Playbutton3.GetComponent<Image>().enabled = false;
        Pausetext3.GetComponent<Text>().enabled = false;
        Pausebutton3.GetComponent<Image>().enabled = false;
        Stoptext3.GetComponent<Text>().enabled = false;
        Stopbutton3.GetComponent<Image>().enabled = false;
        
    }

    void OnTriggerEnter(Collider player) {

        if (player.tag == "thisplayer")
        {
            

            StartCoroutine(GetAudioClip1());
            Debug.Log("Starting to download audio1...");

            StartCoroutine(GetAudioClip2());
            Debug.Log("Starting to download audio2...");

            StartCoroutine(GetAudioClip3());
            Debug.Log("Starting to download audio3...");

            buttons.enabled = true;


            
        }
    }

    IEnumerator GetAudioClip1()
    {
        if (audioSource1downloaded == false) { 
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
                    Playtext1.GetComponent<Text>().enabled = true;
                    Playbutton1.GetComponent<Image>().enabled = true;
                    Pausetext1.GetComponent<Text>().enabled = true;
                    Pausebutton1.GetComponent<Image>().enabled = true;
                    Stoptext1.GetComponent<Text>().enabled = true;
                    Stopbutton1.GetComponent<Image>().enabled = true;

                    source1.enabled = true;

                    audioSource3downloaded = true;
                }
            }
        }
    }

    IEnumerator GetAudioClip2()
    {
        if (audioSource2downloaded == false)
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
                    Debug.Log("Audio2 has downloaded.");
                    Playtext2.GetComponent<Text>().enabled = true;
                    Playbutton2.GetComponent<Image>().enabled = true;
                    Pausetext2.GetComponent<Text>().enabled = true;
                    Pausebutton2.GetComponent<Image>().enabled = true;
                    Stoptext2.GetComponent<Text>().enabled = true;
                    Stopbutton2.GetComponent<Image>().enabled = true;


                    source2.enabled = true;

                    audioSource2downloaded = true;
                }
            }
        }
    }


    IEnumerator GetAudioClip3()
    {

        if (audioSource3downloaded == false)
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
                    Debug.Log("Audio3 has downloaded.");
                    Playtext3.GetComponent<Text>().enabled = true;
                    Playbutton3.GetComponent<Image>().enabled = true;
                    Pausetext3.GetComponent<Text>().enabled = true;
                    Pausebutton3.GetComponent<Image>().enabled = true;
                    Stoptext3.GetComponent<Text>().enabled = true;
                    Stopbutton3.GetComponent<Image>().enabled = true;


                    source3.enabled = true;

                    audioSource3downloaded = true;
                }
            }
        }
    }



    public void pauseAudio1()
    {
        audioSource1.Pause();
    }

    public void playAudio1()
    {
        audioSource1.Play();
    }

    public void stopAudio1()
    {
        audioSource1.Stop();

    }


    public void pauseAudio2()
    {
        audioSource2.Pause();
    }

    public void playAudio2()
    {
        audioSource2.Play();
    }

    public void stopAudio2()
    {
        audioSource2.Stop();

    }

    public void pauseAudio3()
    {
        audioSource3.Pause();
    }

    public void playAudio3()
    {
        audioSource3.Play();
    }

    public void stopAudio3()
    {
        audioSource3.Stop();

    }


    private void OnTriggerExit(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            audioSource1.Stop();
            audioSource2.Stop();
            audioSource3.Stop();

            buttons.enabled = false;

        }
    }

}

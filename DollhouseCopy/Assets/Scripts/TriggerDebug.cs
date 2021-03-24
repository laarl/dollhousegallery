using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class TriggerDebug : MonoBehaviour
{
    public AudioMixer Master;

    public AudioMixerSnapshot start;
    public AudioMixerSnapshot tak1;
    public AudioMixerSnapshot tak2;
    public AudioMixerSnapshot tak3;
    public AudioMixerSnapshot tak4;
    public AudioMixerSnapshot tak5;
    public AudioMixerSnapshot tak6;

    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource audioSource4;
    public AudioSource audioSource5;
    public AudioSource audioSource6;

    public RawImage RawImage1;
    public RawImage RawImage2;
    public RawImage RawImage3;
    public RawImage RawImage4;
    public RawImage RawImage5;
    public RawImage RawImage6;



    public bool Onehasplayed = false;
    public bool Twohasplayed = false;
    public bool Threehasplayed = false;
    public bool Fourhasplayed = false;
    public bool Fivehasplayed = false;
    public bool Sixhasplayed = false;

    public int id;
    private void Start()
    {
        AudioManager.current.onChangeAudioTrigger += OnChangeAudio;

    }

    private void OnChangeAudio(int id)
    {
        StartCoroutine(Wait(1f));

        if (id == 1) {

            if (!Onehasplayed)
            {
                RawImage1.enabled = true;
                Onehasplayed = true;
                
            }
            
            
            

            RawImage2.enabled = false;
            RawImage3.enabled = false;
            RawImage4.enabled = false;
            RawImage5.enabled = false;
            RawImage6.enabled = false;

            if (audioSource1) {

                StartCoroutine(StartShiftPitch(audioSource1, 2.5f, .12f));
                StartCoroutine(StartShiftPitch(audioSource2, 3.0f, .15f));
                StartCoroutine(StartShiftPitch(audioSource3, 2.5f, 1.04f));

                StartCoroutine(Wait(1f));


                tak1.TransitionTo(1.7f);

                StartCoroutine(StartShiftVol(audioSource2, 1.5f, 1f));
                StartCoroutine(StartShiftVol(audioSource3, 2.0f, .8f));
                StartCoroutine(StartShiftVol(audioSource4, 3f, .2f));


                if (!audioSource1.isPlaying)

                {

                    audioSource1.mute = false;

                    StartCoroutine(Wait(1f));
                    audioSource1.Play();


                }
            }

            

            
            
        }
        if (id == 2)
        {
            if (!Twohasplayed)
            {
                RawImage2.enabled = true;
                Twohasplayed = true;
                
            }
            

            RawImage1.enabled = false;
            RawImage3.enabled = false;
            RawImage4.enabled = false;
            RawImage5.enabled = false;
            RawImage6.enabled = false;

            if (audioSource2)
            {

                StartCoroutine(StartShiftPitch(audioSource2, 2.3f, .14f));
                StartCoroutine(StartShiftPitch(audioSource3, 1.75f, 1.2f));
                StartCoroutine(StartShiftPitch(audioSource4, .4f, 1.02f));


                StartCoroutine(Wait(1f));
                tak2.TransitionTo(2.2f);

                StartCoroutine(StartShiftVol(audioSource3, 3f, .9f));
                StartCoroutine(StartShiftVol(audioSource4, 2.2f, 1f));
                StartCoroutine(StartShiftVol(audioSource5, 2.3f, .2f));


                if (!audioSource2.isPlaying)
                {

                    audioSource2.mute = false;

                    StartCoroutine(Wait(1f));

                    audioSource2.Play();


                }
            }

            
        }
        if (id == 3)
        {
            if (!Threehasplayed)
            {
                RawImage3.enabled = true;
                Threehasplayed = true;
                
            }
            
            

            RawImage1.enabled = false;
            RawImage2.enabled = false;
            RawImage4.enabled = false;
            RawImage5.enabled = false;
            RawImage6.enabled = false;

            if (audioSource3)
            {

                StartCoroutine(StartShiftPitch(audioSource3, 1.63f, 1.02f));
                StartCoroutine(StartShiftPitch(audioSource4, .2f, 1.03f));
                StartCoroutine(StartShiftPitch(audioSource5, 1.9f, 1.04f));

                StartCoroutine(Wait(1f));
                tak3.TransitionTo(1.8f);


                StartCoroutine(StartShiftVol(audioSource4, 2.99f, .8f));
                StartCoroutine(StartShiftVol(audioSource5, .99f, .9f));
                StartCoroutine(StartShiftVol(audioSource6, 3.9f, .2f));

                if (!audioSource3.isPlaying)
                {

                    audioSource3.mute = false;

                    StartCoroutine(Wait(1f));
                    audioSource3.Play();


                }
            }

            
        }
        if (id == 4)
        {
            if (!Fourhasplayed) {
                RawImage4.enabled = true;
                Fourhasplayed = true;
               
            }

            

            RawImage1.enabled = false;
            RawImage2.enabled = false;
            RawImage3.enabled = false;
            RawImage5.enabled = false;
            RawImage6.enabled = false;

            if (audioSource4)
            {

                StartCoroutine(StartShiftPitch(audioSource4, .3f, .8f));
                StartCoroutine(StartShiftPitch(audioSource5, 1.9f, 1.07f));
                StartCoroutine(StartShiftPitch(audioSource6, 2.1f, .87f));

                tak4.TransitionTo(2.3f);

                StartCoroutine(StartShiftVol(audioSource5, .99f, .6f));
                StartCoroutine(StartShiftVol(audioSource6, 1.9f, .3f));
                StartCoroutine(StartShiftVol(audioSource1, 1.2f, 1f));


                if (!audioSource4.isPlaying)
                {

                    audioSource4.mute = false;

                    StartCoroutine(Wait(1f));
                    audioSource4.Play();


                }
            }

            
        }

        if (id == 5)
        {

            if (!Fivehasplayed)
            {
                RawImage5.enabled = true;
                Fivehasplayed = true;
                
            }
            
            

            RawImage1.enabled = false;
            RawImage2.enabled = false;
            RawImage3.enabled = false;
            RawImage4.enabled = false;
            RawImage6.enabled = false;

            if (audioSource5) {


                StartCoroutine(StartShiftPitch(audioSource5, 1.3f, .93f));
                StartCoroutine(StartShiftPitch(audioSource6, .4f, .88f));
                StartCoroutine(StartShiftPitch(audioSource1, 1.3f, .18f));

                tak5.TransitionTo(2.5f);


                StartCoroutine(StartShiftVol(audioSource6, 1.9f, .3f));
                StartCoroutine(StartShiftVol(audioSource1, 2f, .9f));
                StartCoroutine(StartShiftVol(audioSource2, 1.9f, 1f));

                if (!audioSource5.isPlaying)
                {
                    StartCoroutine(Wait(1f));
                    audioSource5.mute = false;

                    StartCoroutine(Wait(1f));
                    audioSource5.Play();


                }
            }

            
        }

        if (id == 6)
        {
            if (!Sixhasplayed)
            {
                RawImage6.enabled = true;
                Sixhasplayed = true;
                

            }
           

            RawImage1.enabled = false;
            RawImage2.enabled = false;
            RawImage3.enabled = false;
            RawImage4.enabled = false;
            RawImage5.enabled = false;

            if (audioSource6){

                StartCoroutine(StartShiftPitch(audioSource1, 2.3f, .15f));
                StartCoroutine(StartShiftPitch(audioSource6, .3f, 1.02f));
                StartCoroutine(StartShiftPitch(audioSource2, .75f, .13f));

                tak6.TransitionTo(2.8f);

                StartCoroutine(StartShiftVol(audioSource2, 1.2f, .8f));
                StartCoroutine(StartShiftVol(audioSource6, 1.9f, .6f));
                StartCoroutine(StartShiftVol(audioSource3, 1.9f, 1f));

                if (!audioSource6.isPlaying)
                {
                    StartCoroutine(Wait(1f));
                    audioSource6.mute = false;

                    StartCoroutine(Wait(1f));
                    audioSource6.Play();


                }
            }

            

        }
        
    }


    IEnumerator Wait(float seconds)
    {
        
        yield return new WaitForSeconds(seconds);
        
    }

    public static IEnumerator StartShiftPitch(AudioSource audioSource, float duration, float targetPitch)
    {
        float currentTime = 0;
        float start = audioSource.pitch;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.pitch = Mathf.Lerp(start, targetPitch, currentTime / duration);
            yield return null;
        }
        yield break;
    }


    public static IEnumerator StartShiftVol(AudioSource audioSource, float duration, float targetVol)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVol, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}

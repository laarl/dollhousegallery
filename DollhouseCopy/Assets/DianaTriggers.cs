using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DianaTriggers : MonoBehaviour
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

        if (id == 1)
        {

            if (!Onehasplayed)
            {
               
                Onehasplayed = true;

            }




            if (audioSource1)
            {

               
                StartCoroutine(Wait(1f));


                tak1.TransitionTo(1.7f);

                StartCoroutine(StartShiftVol(audioSource2, 1.5f, .3f));
                StartCoroutine(StartShiftVol(audioSource3, 2.0f, .2f));
                StartCoroutine(StartShiftVol(audioSource4, 3f, .5f));


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
               
                Twohasplayed = true;

            }

            if (audioSource2)
            {



                StartCoroutine(Wait(1f));
                tak2.TransitionTo(2.2f);

                StartCoroutine(StartShiftVol(audioSource3, 3f, .2f));
                StartCoroutine(StartShiftVol(audioSource4, 2.2f, .7f));
                StartCoroutine(StartShiftVol(audioSource5, 2.3f, .1f));


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
                
                Threehasplayed = true;

            }



            if (audioSource3)
            {


                StartCoroutine(Wait(1f));
                tak3.TransitionTo(1.8f);


                StartCoroutine(StartShiftVol(audioSource4, 2.99f, .3f));
                StartCoroutine(StartShiftVol(audioSource5, .99f, .4f));
                StartCoroutine(StartShiftVol(audioSource6, 3.9f, .1f));

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
            if (!Fourhasplayed)
            {
                
                Fourhasplayed = true;

            }



            if (audioSource4)
            {


                tak4.TransitionTo(2.3f);

                StartCoroutine(StartShiftVol(audioSource5, .99f, .3f));
                StartCoroutine(StartShiftVol(audioSource6, 1.9f, .3f));
                StartCoroutine(StartShiftVol(audioSource1, 1.2f, .7f));


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
                
                Fivehasplayed = true;

            }


            if (audioSource5)
            {


                tak5.TransitionTo(2.5f);


                StartCoroutine(StartShiftVol(audioSource6, 1.9f, .3f));
                StartCoroutine(StartShiftVol(audioSource1, 2f, .1f));
                StartCoroutine(StartShiftVol(audioSource2, 1.9f, .5f));

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
                
                Sixhasplayed = true;


            }


            if (audioSource6)
            {
                

                tak6.TransitionTo(2.8f);

                StartCoroutine(StartShiftVol(audioSource2, 1.2f, .4f));
                StartCoroutine(StartShiftVol(audioSource6, 1.9f, .3f));
                StartCoroutine(StartShiftVol(audioSource3, 1.9f, .5f));

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


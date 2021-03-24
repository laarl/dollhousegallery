using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TriggersBenJess : MonoBehaviour
{
    public AudioSource audioSource1;
    public AudioSource audioSource2;

    public int id;
    private void Start()
    {
        AudioManager.current.onChangeAudioTrigger += OnChangeAudio;
    }
    private void OnChangeAudio(int id)
    {
        //StartCoroutine(Wait(1f));

        if (id == 1)
        {
            StartCoroutine(Wait(1f));
            if(!audioSource1.isPlaying)
                audioSource1.Play();
            StartCoroutine(StartShiftVol(audioSource1, 1.5f, .7f, 5f));
            StartCoroutine(StartShiftVol(audioSource2, 1.5f, 0f, 5f));
            
        }
        if (id == 2)
        {
            StartCoroutine(Wait(1f));
            if (!audioSource2.isPlaying)
                audioSource2.Play();
            StartCoroutine(StartShiftVol(audioSource1, 3.5f, .5f, 7f));
            StartCoroutine(StartShiftVol(audioSource2, 6.5f, .1f, 7f));
            
        }
        if (id == 3)
        {
            StartCoroutine(Wait(1f));
            if (!audioSource2.isPlaying)
                audioSource2.Play();
            StartCoroutine(StartShiftVol(audioSource1, 1.5f, .1f, 7f));
            StartCoroutine(StartShiftVol(audioSource2, 2.5f, .6f, 7f));
        }
        if (id == 4)
        {
            StartCoroutine(Wait(1f));
            if (!audioSource1.isPlaying)
                audioSource1.Play();
            StartCoroutine(StartShiftVol(audioSource1, 6.5f, .2f, 7f));
            StartCoroutine(StartShiftVol(audioSource2, 5.5f, .3f, 7f));
        }
        if (id == 5)
        {
            StartCoroutine(Wait(1f));
            if (!audioSource1.isPlaying)
                audioSource1.Play();
            StartCoroutine(StartShiftVol(audioSource1, 1.5f, .5f, 7f));
            StartCoroutine(StartShiftVol(audioSource2, 2.5f, .5f, 7f));
        }
        if (id == 6)
        {
            StartCoroutine(Wait(1f));
            if (!audioSource1.isPlaying)
                audioSource1.Play();
            StartCoroutine(StartShiftVol(audioSource1, 2.5f, .1f, 7f));
            StartCoroutine(StartShiftVol(audioSource2, 1.5f, .9f, 7f));
        }
    }
    IEnumerator Wait(float seconds)
    {

        yield return new WaitForSeconds(seconds);

    }

    public static IEnumerator StartShiftVol(AudioSource audioSource, float duration, float targetVol, float waitSeconds)
    {

        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVol, currentTime / duration);
            yield return null;
        }
        //yield return new WaitForSeconds(waitSeconds);
        yield break;
    }

}

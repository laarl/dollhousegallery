using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Bird1Audio : MonoBehaviour
{

    public AudioSource birdcall1;
    public AudioSource birdcall2;

    void Start()
    {
        
            StartCoroutine(WaitThenPlay(12f, birdcall1));
            StartCoroutine(WaitThenPlay(25f, birdcall2));
            StartCoroutine(WaitThenPlay(40f, birdcall1));
            StartCoroutine(WaitThenPlay(60f, birdcall2));
            StartCoroutine(WaitThenPlay(80f, birdcall2));
            StartCoroutine(WaitThenPlay(113f, birdcall1));
            StartCoroutine(WaitThenPlay(130f, birdcall1));
            StartCoroutine(WaitThenPlay(170f, birdcall2));
            StartCoroutine(WaitThenPlay(190f, birdcall1));

    }

        IEnumerator WaitThenPlay(float seconds, AudioSource birdcall)
    {

        yield return new WaitForSeconds(seconds);
        birdcall.Play();

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird2Audio : MonoBehaviour
{
    public AudioSource birdcall1;
    public AudioSource birdcall2;

    void Start()
    {

        StartCoroutine(WaitThenPlay(15f, birdcall1));
        StartCoroutine(WaitThenPlay(30f, birdcall2));
        StartCoroutine(WaitThenPlay(46f, birdcall1));
        StartCoroutine(WaitThenPlay(70f, birdcall2));
        StartCoroutine(WaitThenPlay(90f, birdcall2));
        StartCoroutine(WaitThenPlay(120f, birdcall1));
        StartCoroutine(WaitThenPlay(152f, birdcall2));
        StartCoroutine(WaitThenPlay(170f, birdcall1));

    }

    IEnumerator WaitThenPlay(float seconds, AudioSource birdcall)
    {

        yield return new WaitForSeconds(seconds);
        birdcall.Play();

    }
}

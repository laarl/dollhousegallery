using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class masteraudiotrigger : MonoBehaviour
{
    public AudioSource c1;
    public AudioSource c2;
    public AudioSource c3;
    public AudioSource c4;
    public AudioSource c5;
    public AudioSource c6;
    public AudioSource c7;
    public AudioSource c8;
    public AudioSource glocks1;
    public AudioSource glocks2;
    public AudioSource glocks3;
    public AudioSource glocks4;
    public AudioSource banjo1;
    public AudioSource banjo2;
    public AudioSource trump1;
    public AudioSource trump2;
    public AudioSource violin1;
    public AudioSource bass1;
    // Start is called before the first frame update
    void Start(){
        c1.Play();
        c1.volume = 0;
        c2.Play();
        c2.volume = 0;
        c3.Play();
        c3.volume = 0;
        c4.Play();
        c4.volume = 0;
        c5.Play();
        c5.volume = 0;
        c6.Play();
        c6.volume = 0;
        c7.Play();
        c7.volume = 0;
        c8.Play();
        c8.volume = 0;
        glocks1.Play();
        glocks1.volume = 0;
        glocks2.Play();
        glocks2.volume = 0;
        glocks3.Play();
        glocks3.volume = 0;
        glocks4.Play();
        glocks4.volume = 0;

        banjo1.Play();
        banjo1.volume = 0;
        banjo2.Play();
        banjo2.volume = 0;

        trump1.Play();
        trump1.volume = 0;
        trump2.Play();
        trump2.volume = 0;

        violin1.Play();
        violin1.volume = 0;

        bass1.Play();
        bass1.volume = 0;


    }
    /*
    private void OnTriggerExit(Collider other){
        c1.Stop();
        c2.Stop();
        c3.Stop();
        c4.Stop();
        c5.Stop();
        c6.Stop();
        c7.Stop();
        c8.Stop();
        glocks1.Stop();
        glocks2.Stop();
        glocks3.Stop();
        glocks4.Stop();

        banjo1.Stop();
        banjo2.Stop();
        trump1.Stop();
        trump2.Stop();
        violin1.Stop();
        bass1.Stop();
    }
    */
}

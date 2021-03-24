using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlaySoundTrigger : MonoBehaviour
{
    
    public AudioSource source;
    public AudioClip clip;
    

    public void Start()
    {
        source = GetComponent<AudioSource>();
        
    }

    public void OnTriggerEnter(Collider other)
    {
        source.Play();
        //Debug.Log("playsound");
    }


}

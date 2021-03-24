using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiotriggerscript : MonoBehaviour
{
	public AudioSource audiosource;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other){
    	StartCoroutine(FadeAudioSource.StartFade(audiosource, 2, (float)0.35));
    }
    private void OnTriggerExit(Collider other){
    	StartCoroutine(FadeAudioSource.StartFade( audiosource, 2, 0));
    }
}

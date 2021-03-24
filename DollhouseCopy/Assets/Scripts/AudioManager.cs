using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class AudioManager : MonoBehaviour
{
    

    public static AudioManager current;

    private void Awake()
    {
        current = this;
    }

    public event Action<int> onChangeAudioTrigger;

    public void ChangeAudioTrigger(int id)
    {
        if(onChangeAudioTrigger != null)
        {
            onChangeAudioTrigger(id);
        }
    }
}
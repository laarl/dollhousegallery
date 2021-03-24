using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisRedTrigger : MonoBehaviour
{
    public int id;
    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "thisplayer")
        {
            AudioManager.current.ChangeAudioTrigger(id);
            DissolveEffectTrigger.startTime = Time.time;
            DissolveEffectTrigger.currentY = 300f;
        }

        
    }
}

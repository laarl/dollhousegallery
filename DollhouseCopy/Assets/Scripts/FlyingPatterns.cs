using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingPatterns : MonoBehaviour
{

    public Transform[] TravelLocations;
    public float speed, reachDist;
    public float startSpeed;
    public int current_loc;
    public Animation Birdbob;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 dir = TravelLocations[current_loc].position - transform.position;
        
        transform.position += dir * Time.deltaTime * speed;

        
        //transform.LookAt(TravelLocations[current_loc]);

        
        
        if (dir.magnitude <= reachDist)
        {
            
            current_loc++;
            
        }
        
        if (current_loc >= TravelLocations.Length)
        {
            speed = 0f;
            Birdbob.enabled = false;
            StartCoroutine(WaitToFly(5f));
            current_loc = 0;
        }

    }

    IEnumerator WaitToFly(float seconds)
    {

        yield return new WaitForSeconds(seconds);
        Birdbob.enabled = true;
        speed = startSpeed;
    }

}

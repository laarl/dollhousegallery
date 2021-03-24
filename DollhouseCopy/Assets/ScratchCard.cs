using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScratchCard : MonoBehaviour
{

    public GameObject maskPrefab;
    private bool isPressed = false;
    public Camera playerCamera;
    public float mousePosz;

    public int percint = 1;

    public float mapPitch = 1f;


    public AudioSource perc1;
    public AudioSource perc2;
    public AudioSource perc3;
    public AudioSource perc4;
    public AudioSource perc5;
    public AudioSource perc6;
    public AudioSource perc7;

    void Start()
    {
        playerCamera = GameObject.FindWithTag("playercamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

        var mousePos = Input.mousePosition;
        mousePos.z = mousePosz;
        mousePos = playerCamera.ScreenToWorldPoint(mousePos);

        if(isPressed == true)
        {
            GameObject maskSprite = Instantiate(maskPrefab, mousePos, Quaternion.identity);
            maskSprite.transform.parent = gameObject.transform;
        }
        else
        {

        }

        if (Input.GetMouseButtonDown(0))
        {
            isPressed = true;

            percint = (Random.Range(1, 7));
           
            mapPitch = Mathf.Clamp((Input.mousePosition.x / Screen.width) * 2f, 0f, 1f);
            Debug.Log(mapPitch);

            switch (percint)
            {
                case 7:
                    perc7.pitch = mapPitch;
                    perc7.Play();
                    break;
                case 6:
                    perc6.pitch = mapPitch;
                    perc6.Play();
                    break;
                case 5:
                    perc5.pitch = mapPitch;
                    perc5.Play();
                    break;
                case 4:
                    perc4.pitch = mapPitch;
                    perc4.Play();
                    break;
                case 3:
                    perc3.pitch = mapPitch;
                    perc3.Play();
                    break;
                case 2:
                    perc2.pitch = mapPitch;
                    perc2.Play();
                    break;
                case 1:
                    perc1.pitch = mapPitch;
                    perc1.Play();
                    break;
                default:
                    break;
            }


        }
        else if (Input.GetMouseButtonUp(0))
        {
            isPressed = false;

            
        }








    }

}

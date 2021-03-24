using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CameraLook1 : MonoBehaviour
{

    private GameObject chatinput;

    private TMP_InputField messageInput;

    [SerializeField] Transform cam;
    [SerializeField] float sensitivity = 35f;
    [SerializeField] float headRotationLimit = 70f;

    float headRotation = 0f;

    public Button resetOrientation;
    public Canvas lostCanvas;

    void Start()
    {
        cam = GameObject.FindWithTag("playercamera").transform;

        chatinput = GameObject.Find("ChatInput");

        messageInput = chatinput.GetComponent<TMP_InputField>();

        resetOrientation = GameObject.Find("Reset").GetComponent<Button>();
        resetOrientation.onClick.AddListener(ClickReset);

        lostCanvas = GameObject.Find("lostcanvas").GetComponent<Canvas>();

    }

    
    
    void Update()
    {
        if (CursorLookToggle.CursorEnabled)
        {
            if (!messageInput.isFocused)
            {

                float x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
                float y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime * -1f;
                headRotation += y;

                if (!isThisDownloading.isDownloading)
                {
                    Cursor.lockState = CursorLockMode.None;

                    transform.Rotate(0f, x, 0f);

                    headRotation = Mathf.Clamp(headRotation, -headRotationLimit, headRotationLimit);
                    cam.localEulerAngles = new Vector3(headRotation, 0f, 0f);


                }

                else
                {
                    cam.localEulerAngles = new Vector3(0, 0f, 0f);
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
        }
        else
        {
            cam.localEulerAngles = new Vector3(0, 0f, 0f);
        }

        
    }


    void ClickReset()
    {
        lostCanvas.enabled = false;
        headRotation = 0f;
        cam.localEulerAngles = new Vector3(headRotation, 0f, 0f);
        //resetOrientation.enabled = false;
        
    }

}

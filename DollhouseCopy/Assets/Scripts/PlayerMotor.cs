using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMotor : MonoBehaviour
{
	private CharacterController controller;
	private float verticalVelocity;
	public float speed = 3.0f;
	public float rotationSpeed = 50f;
    

    private Vector3 rotation;

    private GameObject PlayerCamera;

    private GameObject chatinput;

    private TMP_InputField messageInput;

    public float lookspeed = 3;


    public Canvas lostButton;

    
    //bool isDownloading;
    //Vector3 move;

    private void Start()
	{
		controller = GetComponent<CharacterController>();
        this.gameObject.AddComponent<CameraLook1>();

        GameObject Looker = new GameObject();
        Looker.transform.SetParent(this.transform);
        Looker.tag = "looker";
        //Looker.AddComponent<CameraLook>();
        Looker.AddComponent<AudioListener>();

        PlayerCamera = new GameObject();
        PlayerCamera.transform.SetParent(Looker.transform);
        PlayerCamera.AddComponent<Camera>().fieldOfView = 85.0f;
        PlayerCamera.tag = "playercamera";

        GameObject.Find("Chat_Canvas").GetComponent<Canvas>().enabled = true;


        chatinput = GameObject.Find("ChatInput");
        

        messageInput = chatinput.GetComponent<TMP_InputField>();
        lostButton = GameObject.Find("Lostbuttoncanvas").GetComponent<Canvas>();
        lostButton.enabled = true;

        //isDownloading = new bool  GameObject.Find("isThisDownloading").GetComponent<isThisDownloading>().isDownloading;
        //isDownloading = isThisDownloading.isDownloading;

    }

    private void Update()
	{


        if (!messageInput.isFocused) {

            if (!isThisDownloading.isDownloading) { 

            Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal") * Time.deltaTime, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);

            


            if (Input.GetKey(KeyCode.Period) || Input.GetKey(KeyCode.Comma))
            {
                move = new Vector3(0, 0, 0);


                this.rotation = new Vector3(0, rotationSpeed * Time.deltaTime, 0);

                if (Input.GetKey(KeyCode.Comma))
                {
                    rotationSpeed = -50f;
                }
                else
                rotationSpeed = 50f;
            }

                
               
            else
                {
                this.rotation = new Vector3(0, 0, 0);
                }
            
            


            
            

            



            if (Input.GetButton("Jump"))
        {
            verticalVelocity = .013f;
            Debug.Log("Jump");
        }

        else
        {
            verticalVelocity -= .02f * Time.deltaTime;
        }

        move.y = verticalVelocity;

        

        move = this.transform.TransformDirection(move);
        controller.Move(move * speed);
        this.transform.Rotate(this.rotation);

        }

        }

    }

    
    

}

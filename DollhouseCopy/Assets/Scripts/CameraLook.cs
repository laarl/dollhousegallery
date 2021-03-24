using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraLook : MonoBehaviour
{

    // Mouse direction.
    private Vector2 mDir;

    private Transform myBody;

    public Button resetOrientation;


    void Start()
    {
       
        myBody = this.transform.parent.transform;
        resetOrientation = GameObject.Find("Reset").GetComponent<Button>();

    }


    void Update()
    {


        // How much has mouse moved across screen?
        Vector2 mc = new Vector2(Input.GetAxisRaw("Mouse X"),
            Input.GetAxisRaw("Mouse Y"));

        // Add new movement to current mouse direction.
        mDir += mc;

        // Rotate head up or down.
        // This rotates the camera on X-axis.
        /*
        this.transform.localRotation =
            Quaternion.AngleAxis(-mDir.y, Vector3.right);

        this.transform.localRotation =
            Quaternion.AngleAxis(mDir.x, Vector3.up);
        */

        this.transform.localEulerAngles = new Vector3(-mDir.y, mDir.x, 0.0f);
    }
}

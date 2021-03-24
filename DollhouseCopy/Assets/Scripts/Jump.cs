using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float jumpForce = 50;
    private bool canJump;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canJump =false;
    }

    private void FixedUpdate()
    {
        if (canJump)
        {
            canJump = false;
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canJump = true;
        }
    }
}

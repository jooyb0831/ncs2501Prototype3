using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed;
    private float verticalInput;
    private float horizontalInput;
    private Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        
        if(verticalInput>0)
        {
            transform.Translate(Vector3.forward* Time.deltaTime * speed);
        }
        */



        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MovePlayer(Vector3.forward);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MovePlayer(Vector3.back);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MovePlayer(Vector3.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MovePlayer(Vector3.right);
        }
    }

    private void MovePlayer(Vector3 val)
    {
        playerRb.AddForce(val * 5.0f, ForceMode.Impulse);
    }
}

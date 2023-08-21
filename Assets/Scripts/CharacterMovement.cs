using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 2.0f;
    public float turnSpeed = 5.0f;
    public float horizontalInput;
    public float forwardInput;
    public float jumpForce = 10.0f;
    public bool isOnGround = true;

    [SerializeField]
    public float gravityModifier = 9.81f;

    [SerializeField]
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // use the arrow keys to move the character

        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // move the character forward based on horizontal input
        // flip the character to face the direction it's moving

        if (horizontalInput > 0 )
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        }
        else if (horizontalInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        // transform.Translate(Vector3.left * Time.deltaTime * speed * Time.deltaTime);
        transform.Translate(Vector3.left * Time.deltaTime * speed * horizontalInput);
        }


        // move the camera with the character but slightly offset it so i can still see the ground

        mainCamera.transform.position = transform.position + new Vector3(0, 0, -3);

// if character is colliding with the ground, set isOnGround to true
// otherwise, apply gravity to the character
if (Physics.Raycast(transform.position, Vector3.down, 0.6f))
        {
            isOnGround = true;
        }
        else
        {
            transform.Translate(Vector3.down * gravityModifier * Time.deltaTime);
        }

        // make the character jump when the space bar or arrow up is pressed

        if (isOnGround && Input.GetKeyDown(KeyCode.Space) || isOnGround && forwardInput > 0)
        {
            transform.Translate(Vector3.up * jumpForce * Time.deltaTime);
            isOnGround = false;
        }

        // check if the character is on the ground





    }
}

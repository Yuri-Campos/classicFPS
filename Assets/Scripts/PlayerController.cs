using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerVel;
    public float aimSensitivity;
    private Vector2 keyInput;
    private Vector2 mouseMovement;
    private Vector2 input2d;
    public Rigidbody2D playerRigidBody;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //calling the movePlayer function once per frame
        //we will be using this function in order to achieve the pseudo 3d effect of the classic doom
        movePlayer();
        cameraMovement();

        //scrapped test movement for a future project
        //traditional2dMove();

        //debug to check if unity is returning the correct position
        //Debug.Log(playerRigidBody.position);
    }

    private void movePlayer()
    {
        //creating a vector2 object containing the horizontal and vertical axis calculated by unity controller input
        //subject to change since the ideia is to check key pressed using C# code
        keyInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //vector3 variables recieving the postion, rotation and scale of the object stored in the transform method
        //we take this Transform and multiply by the keyInput in the axis required
        //note that we will use the transform up (y) times the input on X in order to achieve that pseudo 3d effect of doom
        Vector3 pMovementHorizontal = transform.up * -keyInput.x;
        Vector3 pMovementVertical = transform.right * keyInput.y;

        //applying the movement result times the predefined speed of the gameObject to its rigidBody
        playerRigidBody.velocity = (pMovementHorizontal + pMovementVertical) * playerVel;
    }

    //traditional 2d movement 
    //will be used later
    /*
    private void traditional2dMove()
    {
        input2d = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 horizontal2d = transform.up * input2d.y;
        Vector3 vertical2d = transform.right * input2d.x;

        playerRigidBody.velocity = (horizontal2d + vertical2d) * playerVel;
    }
    */


    //function to rotate the camera in the z axis
    //this code will not feature a x axis rotation since we're trying to replicate the classic doom camera
    private void cameraMovement()
    {
        mouseMovement = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y") * aimSensitivity);

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseMovement.x);
    }

}

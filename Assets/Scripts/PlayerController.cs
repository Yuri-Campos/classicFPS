using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerVel;
    private Vector2 keyInput;
    public Rigidbody2D playerRigidBody;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    private void movePlayer()
    {
        keyInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 pMovementHorizontal = transform.up * -keyInput.x;
        Vector3 pMovementVertical = transform.right * keyInput.y;

        playerRigidBody.velocity = (pMovementHorizontal + pMovementVertical) * playerVel;
    }
}

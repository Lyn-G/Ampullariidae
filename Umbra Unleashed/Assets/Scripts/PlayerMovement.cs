using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraFollower : MonoBehaviour
{

    private float horizontalInput;
    private float verticalInput;
    private Vector3 moveDirection;

    public float moveSpeed;
    public Rigidbody playerBody;
    // Start is called before the first frame update
    void Start()
    {
        if (playerBody == null)
        {
            playerBody = GetComponent<Rigidbody>();
        }
        playerBody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
        SpeedControl();
        MovePlayer();
    }

    //gets horizontal/vertical input from arrow keys or WASD
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        Debug.Log(horizontalInput);
    }

    //normalize velocity
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(playerBody.velocity.x, 0f, playerBody.velocity.z);
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed; //calculate max velocity
            playerBody.velocity = new Vector3(limitedVel.x, playerBody.velocity.y, limitedVel.z);
        }
    }

    //move the player
    private void MovePlayer()
    {
        //calculate direction
        moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        playerBody.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }


}

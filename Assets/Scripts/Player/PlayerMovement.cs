using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float sprintSpeed;
    private float tempSprintSpeed;

    public float moveSpeed;
    [SerializeField] private Rigidbody2D _rigidBody;

    public float moveX;
    public float moveY;
    public Vector3 moveVector;

    // Update is called once per frame
    void Update()
    {
        //Get Input
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        //Sprinting
        if (Input.GetKey(KeyCode.LeftShift)) tempSprintSpeed = sprintSpeed;
        else tempSprintSpeed = 0;

    }

    private void FixedUpdate()
    {
        moveVector.x = moveX;
        moveVector.y = moveY;
        _rigidBody.velocity = moveVector.normalized * (moveSpeed + tempSprintSpeed);

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Character variables
    public CharacterController controller;
    public float speed = 12f;

    //These are to do with gravity
    Vector3 velocity;
    public float gravity = -12.81f;
    public LayerMask groundMask;
    bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;

    public Light light;
    //Jump vars
    public float jumpHeight = 3f;
    // Update is called once per frame
    void Update()
    {
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Setting these variables to when WASD is pressed for movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Jump
        if(Input.GetButtonDown("Jump") && isGrounded) //when space is pressed and we are on the floor...
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); //... set y axis to the square root of jump height(3) x -2 x gravity(-9.81)
        }

        //Calculate the direction to move and then move
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        //Use gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;

    //speed is visible in Inspector due to SerializeField,
    //so we can play with speed while in the Unity Interface,
    //instead of jumping between the interface and the script
    [SerializeField] private int speed;
    private Animator playerAnimator;

    //We begin by getting the Rigidbody and the Animator on the player
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    //We're working with Rigidbody which uses Unitys physics engine
    //so we use FixedUpdate, as it updates in line with Unitys physics engine
    private void FixedUpdate()
    {
        rb.velocity = movement * speed;
    }

    private void OnMovement(InputValue value)
    {
        //movement is set as equal to the Vector value of our input from the Unity Input System
        movement = value.Get<Vector2>();

        //an if-else statement, to determine whether the character is walking or not
        //based on if it registers an value from Unity Input System
        if (movement.x != 0 || movement.y != 0)
        {
            //The vector values that we get from the Unity Input system
            //determine the direction of the character.
            //These values are then placed in below parameters. 
            //This then triggers the correct animation for the sprite, when moving a certain direction
            playerAnimator.SetFloat("x", movement.x);
            playerAnimator.SetFloat("y", movement.y);

            //if the method has a Vector value, then it activates, and therefore isWalking is true
            playerAnimator.SetBool("isWalking", true); 
        }
        else
        {
            //if movement.x or movement.y er both equal to 0, then it isWalking has to be false,
            //and the character will stop moving
            playerAnimator.SetBool("isWalking", false); 
        }    

    }

}

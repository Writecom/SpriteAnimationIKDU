using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    [SerializeField] private int speed;
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        rb.velocity = movement * speed;
    }

    private void OnMovement(InputValue value)
    {
    
        movement = value.Get<Vector2>();

        if (movement.x != 0 || movement.y != 0)
        {
            playerAnimator.SetFloat("x", movement.x);
            playerAnimator.SetFloat("y", movement.y);

            playerAnimator.SetBool("isWalking", true); //Hvis funktionen har bevægelse træder den i kraft, og derfor er isWalking også true
        }
        else
        {
            playerAnimator.SetBool("isWalking", false); //Hvis movement.x eller movement.y begge er lig med 0
        }    

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Rigidbody2D rigidbody2D;

    public float speed = 40;
    private float horizontalMovement;

    private bool jump;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));
        
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }

        if (rigidbody2D.linearVelocity.y < -2)
        {
            animator.SetBool("isFalling", true);
        }

        else
        {
            animator.SetBool("isFalling", false);
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMovement * Time.deltaTime, false, jump);
        jump = false;
    }

    public void LandedOnGround()
    {
        animator.SetBool("isJumping", false);
    }

}



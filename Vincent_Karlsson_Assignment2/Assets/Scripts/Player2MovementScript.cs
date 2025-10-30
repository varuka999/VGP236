using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2MovementScript : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public Rigidbody2D rigidbody2D;

    public float speed = 40;
    private float horizontalMovement2;

    private bool jump;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement2 = Input.GetAxisRaw("Horizontal2") * speed;
        animator.SetFloat("Speed2", Mathf.Abs(horizontalMovement2));
        Debug.Log(rigidbody2D.linearVelocity.y);

        if (rigidbody2D.linearVelocity.y < -9)
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
        controller.Move(horizontalMovement2 * Time.deltaTime, false, jump);
        jump = false;
    }
}

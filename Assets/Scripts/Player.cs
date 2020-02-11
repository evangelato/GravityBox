using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private CharacterController2D controller;
    private float horizontalMove = 0f;
    [SerializeField] private float runSpeed = 40f;
    private bool jump = false;
    [SerializeField] private Animator animator;
    private bool isGravityFlipped = false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && controller.IsGrounded())
        {
            Physics2D.gravity = new Vector2(0, 9.8f);
            transform.Rotate(180f, 0f, 0f, Space.Self);
            isGravityFlipped = true;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && controller.IsGrounded())
        {
            Physics2D.gravity = new Vector2(0, -9.8f);
            transform.Rotate(180f, 0f, 0f, Space.Self);
            isGravityFlipped = false;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        if (jump)
        {
            jump = false;
        }
    }
    
    public bool IsGravityFlipped()
    {
        return isGravityFlipped;
    }
}

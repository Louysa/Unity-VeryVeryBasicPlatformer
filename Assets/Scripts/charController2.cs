using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController2 : MonoBehaviour
{
    float jumpForce = 8.0f;
    float speed = 5.0f;
    float moveDirection;

    bool moving;
    bool jump;
    bool grounded = true;
    Rigidbody2D rigidbody2D;
    Animator animator;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        rigidbody2D.freezeRotation = true;
        if(rigidbody2D.velocity != Vector2.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
  
        }
        rigidbody2D.velocity = new Vector2(speed * moveDirection, rigidbody2D.velocity.y);

        if (jump)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
            jump = false;

        }

    }
    private void Update()
    {
        if( (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.A))
            {

                moveDirection = -1.0f;
                animator.SetFloat("speed", speed);
                spriteRenderer.flipX = true;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                animator.SetFloat("speed", speed);
                spriteRenderer.flipX = false;

            }
        }
        else if (grounded)
        {
            moveDirection = 0.0f;
            animator.SetFloat("speed", 0.0f);

        }

        if(grounded && Input.GetKey(KeyCode.W))
        {
            jump = true;
            grounded = false;
            animator.SetTrigger("jump");
            animator.SetBool("grounded", false);

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            grounded = true;
            animator.SetBool("grounded", true);
        }

    }
}

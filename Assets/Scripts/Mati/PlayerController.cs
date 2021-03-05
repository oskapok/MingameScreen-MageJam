using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;

    [Header("Movement")]
    public bool canMove = true;
    [SerializeField] private float moveSpeed = 5f;
    private float horizontalMove;
    private Vector2 localScale;
    private bool facingRight;

    [Header("Jump")]
    public bool canJump = true;
    [SerializeField] private float jumpForce = 3f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;
    }

    void FixedUpdate()
    {
        Movement();
        FlipingSprite();
        Shooting();
    }

    void Movement()
    {
        if (canMove)
        {
            horizontalMove = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);

            if(horizontalMove > 0)
                facingRight = true;
            else if(horizontalMove < 0)
                facingRight = false;
        }

        if (canJump)
        {
            if (Input.GetKey(KeyCode.W) && rb.velocity.y == 0)
            {
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    void FlipingSprite()
    {
        if (facingRight)
        {
            transform.localScale = new Vector2(localScale.x * 1, localScale.y);
        }
        else if (!facingRight)
        {
            transform.localScale = new Vector2(localScale.x * -1, localScale.y);
        }
    }

    void Shooting()
    {

    }
}

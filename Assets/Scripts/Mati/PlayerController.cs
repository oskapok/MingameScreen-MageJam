using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    
    [Header("Controls")]
    [SerializeField] private int playerNumber;
    private string playerAxis;
    private int jumpKey;
    private int shootKey;

    [Header("Movement")]
    public bool canMove = true;
    [SerializeField] private float moveSpeed = 5f;
    private float horizontalMove;
    private Vector2 localScale;
    private bool facingRight;

    [Header("Jumping")]
    public bool canJump = true;
    [SerializeField] private float jumpForce = 8f;
    

    [Header("Shooting")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform outOfWeapon;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        localScale = transform.localScale;

        switch(playerNumber)
        {
            case 1:
                playerAxis = "Horizontal_P1";
                jumpKey = (int)KeyCode.W;
                shootKey = (int)KeyCode.Space;
                break;
            case 2:
                playerAxis = "Horizontal_P2";
                jumpKey = (int)KeyCode.UpArrow;
                shootKey = (int)KeyCode.RightShift;
                break;
        }
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
            horizontalMove = Input.GetAxis(playerAxis);
            rb.velocity = new Vector2(horizontalMove * moveSpeed, rb.velocity.y);

            if(horizontalMove > 0)
                facingRight = true;
            else if(horizontalMove < 0)
                facingRight = false;
        }

        if (canJump)
        {
            if (Input.GetKey((KeyCode)(jumpKey)) && rb.velocity.y == 0)
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
        if(Input.GetKey((KeyCode)(shootKey)))
        {
            Instantiate(bulletPrefab, outOfWeapon.position, Quaternion.identity);
        }
    }
}

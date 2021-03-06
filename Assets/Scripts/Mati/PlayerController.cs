using System;
using System.Collections;
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
    public bool canShoot = true;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform outOfWeapon;
    [SerializeField] private float fireRate;
    [SerializeField] private float fireTimer;
    private bool isShooting = false;
    private Coroutine shootingRoutine;

    [Header("Gravity")]
    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform groundCheck1;
    [SerializeField] private Transform groundCheck2;
    [SerializeField] private float groundDist = 0.4f;
    [SerializeField] private LayerMask groundMask;


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
        Shoot();
    }
    void Update()
    {
        Jumping();
    }
    void Movement()
    {
        isGrounded = Physics2D.OverlapArea(groundCheck1.position, groundCheck2.position, groundMask);

        if (canMove)
        {
            horizontalMove = Input.GetAxis(playerAxis);
            rb.velocity = new Vector2(horizontalMove * moveSpeed, Mathf.Clamp(rb.velocity.y, -jumpForce, jumpForce));

            if(horizontalMove > 0)
                facingRight = true;
            else if(horizontalMove < 0)
                facingRight = false;
        }
    }

    void Jumping()
    {
        if (canJump)
        {
            if (Input.GetKeyDown((KeyCode)(jumpKey)) && isGrounded)
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
    /*
    void Shooting()
    {
        if (canShoot)
        {
            if (Input.GetKey((KeyCode)(shootKey)))
            {
                fireTimer += Time.deltaTime;
                if (fireTimer * 10 > fireRate)
                {
                    GameObject bullet = Instantiate(bulletPrefab, outOfWeapon.position, Quaternion.identity);
                    bullet.GetComponent<Bullet>().side = Convert.ToInt32(facingRight);
                    fireTimer = 0;
                }
            }
        }
    }
    */
    void Shoot()
    {
        if (canShoot)
        {
            if (Input.GetKey((KeyCode)(shootKey)) && !isShooting)
            {
                shootingRoutine = StartCoroutine(Shooting());
            }
        }
        else
        {
            shootingRoutine = null;
        }
    }

    IEnumerator Shooting()
    {
        GameObject bullet = Instantiate(bulletPrefab, outOfWeapon.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().side = Convert.ToInt32(facingRight);
        isShooting = true;
        yield return new WaitForSeconds(fireRate);
        isShooting = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck1.position, groundCheck2.position);
    }
}

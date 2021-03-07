using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    [HideInInspector] public Animator anim;


    [Header("Controls")]
    public int playerNumber;
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
    public int currentWeapon;
    [SerializeField] private SpriteRenderer gunSprite;

    [Header("Gravity")]
    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform groundCheck1;
    [SerializeField] private Transform groundCheck2;
    [SerializeField] private float groundDist = 0.4f;
    [SerializeField] private LayerMask groundMask;


    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;

        switch(playerNumber)
        {
            case 1:
                playerAxis = "Horizontal_P1";
                jumpKey = (int)KeyCode.W;
                shootKey = (int)KeyCode.S;
                break;
            case 2:
                playerAxis = "Horizontal_P2";
                jumpKey = (int)KeyCode.UpArrow;
                shootKey = (int)KeyCode.DownArrow;
                break;
            case 3:
                playerAxis = "Horizontal_P3";
                jumpKey = (int)KeyCode.I;
                shootKey = (int)KeyCode.K;
                break;
            case 4:
                playerAxis = "Horizontal_P4";
                jumpKey = (int)KeyCode.JoystickButton0;
                shootKey = (int)KeyCode.JoystickButton1;
                break;
        }

        playerNumber -= 1;
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
                SoundManager.Instance.PlaySFX("Jump");
            }
        }
    }

    void FlipingSprite()
    {
        if(canMove)
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
        
    }

    void Shoot()
    {
        if (canShoot)
        {
            if (Input.GetKeyDown((KeyCode)(shootKey)) && !isShooting)
            {
                if (GameManager.Instance.RemoveAmmo(playerNumber) == true)
                {
                    shootingRoutine = StartCoroutine(Shooting());

                    switch(currentWeapon)
                    {
                        case 0:
                            SoundManager.Instance.PlaySFX("PistolShot");
                            break;
                        case 1:
                            SoundManager.Instance.PlaySFX("RifleShot");
                            break;
                        case 2:
                            SoundManager.Instance.PlaySFX("ShotgunShot1");
                            break;
                    }

                }
                else
                {
                    Debug.Log("no ammo");
                    switch (currentWeapon)
                    {
                        case 0:
                            SoundManager.Instance.PlaySFX("PistolNoAmmo");
                            break;
                        case 1:
                            SoundManager.Instance.PlaySFX("RifleNoAmmo");
                            break;
                        case 2:
                            SoundManager.Instance.PlaySFX("ShotgunNoAmmo");
                            break;

                    }
                }
            }
        }
        else
        {
            shootingRoutine = null;
        }
    }

    IEnumerator Shooting()
    {
        if(currentWeapon == 0 || currentWeapon == 1)
        {
            GameObject bullet = Instantiate(bulletPrefab, outOfWeapon.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().side = Convert.ToInt32(facingRight);
        }
        if(currentWeapon == 2)
        {
            GameObject bullet1 = Instantiate(bulletPrefab, outOfWeapon.position, Quaternion.identity);
            GameObject bullet2 = Instantiate(bulletPrefab, outOfWeapon.position, Quaternion.identity);

            bullet1.GetComponent<Bullet>().side = Convert.ToInt32(facingRight);
            bullet2.GetComponent<Bullet>().side = Convert.ToInt32(facingRight);
            bullet1.GetComponent<Bullet>().isShotgun = true;
        }
        
        
        isShooting = true;
        anim.SetTrigger("shoot");
        yield return new WaitForSeconds(fireRate);
        isShooting = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck1.position, groundCheck2.position);
    }


    void DisablePlayer()
    {
        canMove = false;
        canJump = false;
        canShoot = false;
        SoundManager.Instance.PlaySFX("Dead1");
    }

    void DestroyPlayerFromMap()
    {
        //remove player from this round
    }


    public void ChangeGunSprite(Sprite _sprite)
    {
        gunSprite.sprite = _sprite;
        anim.SetInteger("weaponIndex", currentWeapon);
    }

}

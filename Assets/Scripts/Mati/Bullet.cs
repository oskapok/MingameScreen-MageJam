using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [HideInInspector] public int side; // 0 - left;   1 - right
    private Vector2 dirOfBullet;
    public bool isShotgun;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();



        switch(side)
        {
            case 0:
                dirOfBullet = Vector2.left;
                break;
            case 1:
                dirOfBullet = Vector2.right;
                break;
        }

        if(isShotgun)
            dirOfBullet += new Vector2(0f, 0.05f);

    }
    void FixedUpdate()
    {
        BulletFly();
    }

    void BulletFly()
    {
        rb.AddForce(dirOfBullet * 200f * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Collision with player");


            PlayerController player = collision.GetComponent<PlayerController>();

            player.anim.SetInteger("playerIndex", player.playerNumber);
            player.anim.SetTrigger("die");

            Destroy(this.gameObject, 0.03f);
        }
        if(collision.CompareTag("Environment"))
        {
            Debug.Log("Collision with environment");

                
            Destroy(this.gameObject, 0.03f);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}

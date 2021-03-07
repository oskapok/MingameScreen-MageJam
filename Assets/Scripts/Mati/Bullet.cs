using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [HideInInspector] public int side; // 0 - left;   1 - right
    private Vector2 dirOfBullet;
    [SerializeField] private ParticleSystem wallCollision;
    [SerializeField] private ParticleSystem playerCollision;

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

            if (!playerCollision.isPlaying)
            {
                var main = playerCollision.main;
                main.startDelay = 0.07f;
                playerCollision.Play();
            }

            PlayerController player = collision.GetComponent<PlayerController>();

            player.anim.SetInteger("playerIndex", player.playerNumber);
            player.anim.SetTrigger("die");

            Destroy(this.gameObject, 0.03f);
        }
        if(collision.CompareTag("Environment"))
        {
            Debug.Log("Collision with environment");

            if(!wallCollision.isPlaying)
            {
                //var main = playerCollision.main;
                //main.startDelay = 0.02f;

                wallCollision.Play();
            }
                

            Destroy(this.gameObject, 0.03f);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}

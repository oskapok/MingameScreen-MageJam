using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    [HideInInspector] public int side; // 0 - left;   1 - right
    private Vector2 dirOfBullet;

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
        rb.AddForce(dirOfBullet * 300f * Time.fixedDeltaTime, ForceMode2D.Impulse);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //kill
            Destroy(this.gameObject);
        }
        if(collision.CompareTag("Environment"))
        {
            Destroy(this.gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}

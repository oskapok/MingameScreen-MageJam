using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            CollectingAmmo(collision.GetComponent<PlayerController>().playerNumber);
            Destroy(this.gameObject);
        }
    }

    void CollectingAmmo(int playerIndex)
    {
        GameManager.Instance.AddAmmo(playerIndex);
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}

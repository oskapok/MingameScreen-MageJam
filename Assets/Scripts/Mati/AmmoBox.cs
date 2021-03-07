using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{

    [SerializeField] private GameObject parachuteSprite;

    void Start()
    {
        parachuteSprite.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            CollectingAmmo(collision.GetComponent<PlayerController>().playerNumber);
            Destroy(this.gameObject);
        }
        if(collision.CompareTag("Environment"))
        {
            parachuteSprite.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Environment"))
        {
            parachuteSprite.SetActive(true);
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

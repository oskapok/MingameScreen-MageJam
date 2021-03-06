using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBox : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CollectingWeapon(collision.GetComponent<PlayerController>().playerNumber);
            Destroy(this.gameObject);
        }
    }

    void CollectingWeapon(int playerIndex)
    {
        int randomWeapon = Random.Range(0, 3);
        GameManager.Instance.SwitchWeapon(playerIndex, (Weapon)randomWeapon);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBox : MonoBehaviour
{

    public List<Sprite> listOfIdleWeapons;
    [SerializeField] private GameObject parachuteSprite;

    void Start()
    {
        parachuteSprite.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CollectingWeapon(collision.GetComponent<PlayerController>());
            Destroy(this.gameObject);
        }
        if(collision.CompareTag("Environment") || collision.CompareTag("Box"))
        {
            parachuteSprite.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Environment") || collision.CompareTag("Box"))
        {
            parachuteSprite.SetActive(true);
        }
    }
    void CollectingWeapon(PlayerController player)
    {
        int randomWeapon = Random.Range(0, 3);
        while(randomWeapon == player.currentWeapon)
        {
            randomWeapon = Random.Range(0, 3);
            player.currentWeapon = randomWeapon;
        }
        GameManager.Instance.SwitchWeapon(player.playerNumber, (Weapon)randomWeapon);
        player.currentWeapon = randomWeapon;
        player.ChangeGunSprite(listOfIdleWeapons[randomWeapon]);
        Debug.Log("Current weapon: " + player.currentWeapon);
        Debug.Log("Random weapon: " + randomWeapon);
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}

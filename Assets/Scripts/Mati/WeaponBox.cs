using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBox : MonoBehaviour
{

    public List<Sprite> listOfIdleWeapons;
    [SerializeField] private GameObject parachuteSprite;
    int randomWeapon;

    void Start()
    {
        parachuteSprite.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CollectingWeapon(collision.GetComponent<PlayerController>());
            SoundManager.Instance.PlaySFX("GetNewWeapon");
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
        randomWeapon = Random.Range(0, 3);
        if (randomWeapon == player.currentWeapon)
        {
            randomWeapon = Random.Range(0, 3);
        }
        GameManager.Instance.SwitchWeapon(player.playerNumber, (Weapon)randomWeapon);
        player.currentWeapon = randomWeapon;
        player.ChangeGunSprite(listOfIdleWeapons[randomWeapon]);

        switch(player.currentWeapon)
        {
            case 0:
                player.fireRate = 0.7f;
                break;
            case 1:
                player.fireRate = 0.3f;
                break;
            case 2:
                player.fireRate = 0.5f;
                break;
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}

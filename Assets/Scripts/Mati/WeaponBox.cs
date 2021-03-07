using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBox : MonoBehaviour
{

    public List<Sprite> listOfIdleWeapons;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CollectingWeapon(collision.GetComponent<PlayerController>());
            Destroy(this.gameObject);
        }
    }

    void CollectingWeapon(PlayerController player)
    {
        int randomWeapon = Random.Range(0, 3);
        while(randomWeapon == player.currentWeapon)
        {
            randomWeapon = Random.Range(0, 3);
        }
        GameManager.Instance.SwitchWeapon(player.playerNumber, (Weapon)randomWeapon);
        player.currentWeapon = randomWeapon;
        player.ChangeGunSprite(listOfIdleWeapons[randomWeapon]);
    }
}

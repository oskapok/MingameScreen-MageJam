using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class UI_Player : MonoBehaviour
{
    public UI_Game uI;

    [SerializeField]
    GameObject ammoPrefabPistol;

    [SerializeField]
    GameObject ammoPrefabRifle;

    [SerializeField]
    GameObject ammoPrefabShothgun;

    [SerializeField]
    GameObject ammoGrid;

    [SerializeField]
    Sprite currentWeaponAmmoType;

    Weapon currentWeapon;

    public void AddAmmo()
    {
        switch(currentWeapon)
        {
            case Weapon.Pistol:
                Instantiate(ammoPrefabPistol, ammoGrid.transform);
                break;
            case Weapon.Rifle:
                Instantiate(ammoPrefabRifle, ammoGrid.transform);
                break;
            case Weapon.Shotgun:
                Instantiate(ammoPrefabShothgun, ammoGrid.transform);
                break;
        }
    }

    public void SwitchWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
        switch (weapon)
        {
            case Weapon.Pistol:
                currentWeaponAmmoType = uI.sprites[0];
            break;
            case Weapon.Rifle:
                currentWeaponAmmoType = uI.sprites[1];
                break;
            case Weapon.Shotgun:
                currentWeaponAmmoType = uI.sprites[2];
                break;
        }
        ChangeAmmoSrpites();
    }


    void ChangeAmmoSrpites()
    {
        foreach(Image spriteAmmo in ammoGrid.transform.GetComponentsInChildren<Image>())
        {
            spriteAmmo.sprite = currentWeaponAmmoType;
        }
    }

    private void Start()
    {
        int myIndex = Int32.Parse(this.gameObject.name.Substring(9, 1))-1;
        int currentAmmo = GameManager.Instance.GetCurrentAmmo(myIndex);
        for (int i = 0; i<currentAmmo;i++)
        {
            Instantiate(ammoPrefabPistol, ammoGrid.transform);
        }

        if (uI == null)
            uI = GameObject.FindObjectOfType<UI_Game>().GetComponent<UI_Game>();
        currentWeaponAmmoType = uI.sprites[0];
    }
}

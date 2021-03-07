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

    int maxAmmo;

    [SerializeField]
    GameObject ammoEmptyPrefabPistol;

    [SerializeField]
    GameObject ammoEmptyPrefabRifle;

    [SerializeField]
    GameObject ammoEmptyPrefabShothgun;

    [SerializeField]
    GameObject ammoGrid;

    [SerializeField]
    Sprite currentWeaponAmmo;

    [SerializeField]
    Sprite currentWeaponAmmoEmpty;

    Weapon currentWeapon;

    public void AddAmmo(int currentAmmo)
    {
        for (int i = 0; i < currentAmmo; i++)
        {
            ammoGrid.transform.GetChild(i).GetComponent<Image>().sprite = currentWeaponAmmo;
        }

    }
    public void RemoveAmmo(int currentAmmo)
    {
        ammoGrid.transform.GetChild(currentAmmo).GetComponent<Image>().sprite = currentWeaponAmmoEmpty;
    }

    public void SwitchWeapon(Weapon weapon, int currentAmmo)
    {
        foreach (Transform child in ammoGrid.transform)
        {
            ammoGrid.transform.DetachChildren();
            Destroy(child.gameObject);
        }
        currentWeapon = weapon;
        switch (weapon)
        {
            case Weapon.Pistol:
                currentWeaponAmmoEmpty = uI.sprites[3];
                currentWeaponAmmo = uI.sprites[0];
                maxAmmo = GameManager.Instance.MaxPistolAmmo;
                for (int i = 0; i < maxAmmo; i++)
                {
                    Instantiate(ammoEmptyPrefabPistol, ammoGrid.transform);
                }
                break;
            case Weapon.Rifle:
                currentWeaponAmmoEmpty = uI.sprites[4];
                currentWeaponAmmo = uI.sprites[1];
                maxAmmo = GameManager.Instance.MaxRifleAmmo;
                for (int i = 0; i < maxAmmo; i++)
                {
                    Instantiate(ammoEmptyPrefabRifle, ammoGrid.transform);
                }
                break;
            case Weapon.Shotgun:
                currentWeaponAmmoEmpty = uI.sprites[5];
                currentWeaponAmmo = uI.sprites[2];
                maxAmmo = GameManager.Instance.MaxShotgunAmmo;
                for (int i = 0; i < maxAmmo; i++)
                {
                    Instantiate(ammoEmptyPrefabShothgun, ammoGrid.transform);
                }
                break;
        }
        AddAmmo(currentAmmo);
    }

    private void Awake()
    {
        int myIndex = Int32.Parse(this.gameObject.name.Substring(9, 1)) - 1;
        int currentAmmo = GameManager.Instance.GetCurrentAmmo(myIndex);
        if (uI == null)
            uI = GameObject.FindObjectOfType<UI_Game>().GetComponent<UI_Game>();
        SwitchWeapon(Weapon.Pistol, currentAmmo);
    }
    private void Start()
    {

        //SwitchWeapon(Weapon.Pistol,currentAmmo);
        //currentWeaponAmmoEmpty = uI.sprites[3];
        //currentWeaponAmmo = uI.sprites[0];

    }
}

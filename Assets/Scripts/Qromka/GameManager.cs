using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static event EventHandler<PlayerEventArgs> updateAmmoEvent;
    public static event EventHandler<PlayerEventArgs> updateWeaponEvent;

    public UI_Game UI;

    List<PlayerData> playerDatas = new List<PlayerData>();

    [Header("Game-Settings")]
    [SerializeField]
    int numberOfPlayers = 2;

    [SerializeField]
    int startPistolAmmo = 1;

    [SerializeField]
    int maxPistolAmmo = 4;

    [SerializeField]
    int maxRifleAmmo = 6;

    [SerializeField]
    int maxShotgunAmmo = 3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            SetUpScene();
        }


        //If duplicate abort
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Mark as permament
        DontDestroyOnLoad(gameObject);
    }

    public int GetNumberOfPlayers()
    {
        return numberOfPlayers;
    }
    void SetUpScene()
    {
        //Create Player datas 
        switch (numberOfPlayers)
        {
            case 2:
                playerDatas.Add(new PlayerData());
                playerDatas.Add(new PlayerData());
                break;
            case 3:
                playerDatas.Add(new PlayerData());
                playerDatas.Add(new PlayerData());
                playerDatas.Add(new PlayerData());
                break;
            case 4:
                playerDatas.Add(new PlayerData());
                playerDatas.Add(new PlayerData());
                playerDatas.Add(new PlayerData());
                playerDatas.Add(new PlayerData());
                break;
        }

        //Assign Default Values
        for (int i = 0; i < numberOfPlayers; i++)
        {
            playerDatas[i].player = GameObject.Find("P" + i.ToString());
            playerDatas[i].weapon = Weapon.Pistol;
            playerDatas[i].ammo = startPistolAmmo;
            playerDatas[i].isAlive = true;
        }

        //Synchronize UI
        ConnectUI();
        UI.Initialize(numberOfPlayers);
    }


    void ConnectUI()
    {
        if(UI == null)
        {
            UI = GameObject.FindObjectOfType<UI_Game>();
        }
    }

    public int GetCurrentAmmo(int playerIndex)
    {
        return playerDatas[playerIndex].ammo;
    }

    public bool AddAmmo(int playerIndex)
    {
        PlayerData selectedPlayer = playerDatas[playerIndex];
        switch(selectedPlayer.weapon)
        {
            case Weapon.Pistol:
                if (selectedPlayer.ammo < maxPistolAmmo)
                {
                    selectedPlayer.ammo++;
                    updateAmmoEvent?.Invoke(this, new PlayerEventArgs(playerIndex));
                    return true;
                }
                break;
            case Weapon.Rifle:
                if (selectedPlayer.ammo < maxRifleAmmo)
                {
                    selectedPlayer.ammo++;
                    updateAmmoEvent?.Invoke(this, new PlayerEventArgs(playerIndex));
                    return true;
                }
                break;
            case Weapon.Shotgun:
                if (selectedPlayer.ammo < maxShotgunAmmo)
                {
                    selectedPlayer.ammo++;
                    updateAmmoEvent?.Invoke(this, new PlayerEventArgs(playerIndex));
                    return true;
                }
                break;
        }
        return false;
    }
    public bool RemoveAmmo(int playerIndex)
    {
        PlayerData selectedPlayer = playerDatas[playerIndex];
        if (selectedPlayer.ammo > 1)
        {
            selectedPlayer.ammo--;
            updateAmmoEvent?.Invoke(this, new PlayerEventArgs(playerIndex));
            return true;
        }    
        return false;
    }

    public bool SwitchWeapon(int playerIndex, Weapon newWeapon)
    {
        PlayerData selectedPlayer = playerDatas[playerIndex];
        if(selectedPlayer.weapon != newWeapon)
        {
            selectedPlayer.weapon = newWeapon;
            switch (newWeapon)
            {
                case Weapon.Pistol:
                    selectedPlayer.ammo = 4;
                    updateAmmoEvent?.Invoke(this, new PlayerEventArgs(playerIndex));
                    break;
                case Weapon.Rifle:
                    selectedPlayer.ammo = 3;
                    updateAmmoEvent?.Invoke(this, new PlayerEventArgs(playerIndex));
                    break;
                case Weapon.Shotgun:
                    selectedPlayer.ammo = 2;
                    updateAmmoEvent?.Invoke(this, new PlayerEventArgs(playerIndex));
                    break;
            }
            
            updateWeaponEvent?.Invoke(this, new PlayerEventArgs(playerIndex,newWeapon));
            return true;
        }
        else
            return false;

    }
}

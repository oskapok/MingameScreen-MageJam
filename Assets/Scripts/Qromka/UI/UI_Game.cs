using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Game : MonoBehaviour
{
    List<UI_Player> uI_Players = new List<UI_Player>();

    [Header("UI Prefabs")]
    [SerializeField]
    GameObject uI_Player1InfoPrefab;
    [SerializeField]
    GameObject uI_Player2InfoPrefab;
    [SerializeField]
    GameObject uI_Player3InfoPrefab;
    [SerializeField]
    GameObject uI_Player4InfoPrefab;

    [Header("UI Sprites")]
    public List<Sprite> sprites = new List<Sprite>();


    public void Initialize(int numberOfPlayers)
    {
        GameObject current;
        switch (numberOfPlayers)
        {
            case 2:
                if (uI_Player1InfoPrefab == null || uI_Player2InfoPrefab == null)
                    Debug.LogWarning("Please assign UI 1 & 2 Player Info prefab!");
                else
                {
                    current = Instantiate(uI_Player1InfoPrefab, transform);
                    uI_Players.Add(current.GetComponent<UI_Player>());
                    current = Instantiate(uI_Player2InfoPrefab, transform);
                    uI_Players.Add(current.GetComponent<UI_Player>());
                }
                break;
            case 3:
                if (uI_Player1InfoPrefab == null || uI_Player2InfoPrefab == null || uI_Player3InfoPrefab == null)
                    Debug.LogWarning("Please assign UI 1 & 2 & 3 Player Info prefab!");
                else
                {
                    current = Instantiate(uI_Player1InfoPrefab, transform);
                    uI_Players.Add(current.GetComponent<UI_Player>());
                    current = Instantiate(uI_Player2InfoPrefab, transform);
                    uI_Players.Add(current.GetComponent<UI_Player>());
                    current = Instantiate(uI_Player3InfoPrefab, transform);
                    uI_Players.Add(current.GetComponent<UI_Player>());
                }
                break;
            case 4:
                if (uI_Player1InfoPrefab == null || uI_Player2InfoPrefab == null || uI_Player3InfoPrefab == null || uI_Player4InfoPrefab == null)
                    Debug.LogWarning("Please assign UI 1 & 2 & 3 & 4 Player Info prefab!");
                else
                {
                    current = Instantiate(uI_Player1InfoPrefab, transform);
                    uI_Players.Add(current.GetComponent<UI_Player>());
                    current = Instantiate(uI_Player2InfoPrefab, transform);
                    uI_Players.Add(current.GetComponent<UI_Player>());
                    current = Instantiate(uI_Player3InfoPrefab, transform);
                    uI_Players.Add(current.GetComponent<UI_Player>());
                    current = Instantiate(uI_Player4InfoPrefab, transform);
                    uI_Players.Add(current.GetComponent<UI_Player>());
                }
                break;
        }
    }




    void UpdateAmmo(object sender, PlayerEventArgs e)
    {
        uI_Players[e.playerIndex].AddAmmo();
    }

    void UpdateWeapon(object sender, PlayerEventArgs e)
    {
        uI_Players[e.playerIndex].SwitchWeapon(e.weapon);
    }

    void Start()
    {
        GameManager.updateAmmoEvent += UpdateAmmo;
        GameManager.updateWeaponEvent += UpdateWeapon;
    }
    void OnDestroy()
    {
        GameManager.updateAmmoEvent -= UpdateAmmo;
    }
}

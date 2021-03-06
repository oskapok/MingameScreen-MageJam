using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UI_Game : MonoBehaviour
{
    public List<UI_Player> uI_Players = new List<UI_Player>();




    void UpdateAmmo(object sender, PlayerEventArgs e)
    {
        uI_Players[e.playerIndex].AddAmmo();
    }

    void Start()
    {
        GameManager.updateAmmoEvent += UpdateAmmo;
    }
    void OnDestroy()
    {
        GameManager.updateAmmoEvent -= UpdateAmmo;
    }
}

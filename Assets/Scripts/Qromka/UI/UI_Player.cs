using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Player : MonoBehaviour
{
    [SerializeField]
    GameObject ammoPrefab;


    [SerializeField]
    GameObject ammoGrid;

    public void AddAmmo()
    {
        Instantiate(ammoPrefab, ammoGrid.transform);
    }
}

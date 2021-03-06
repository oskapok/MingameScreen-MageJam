using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Weapon
{
    Pistol,
    Rifle,
    Shotgun
}
public class  PlayerData
{
   public GameObject player;
    public Weapon weapon;
    public int ammo;
    public bool isAlive;
}

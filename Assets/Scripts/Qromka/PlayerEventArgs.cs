using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerEventArgs : EventArgs
{
    private readonly int _playerIndex;
    private readonly bool _ammoIncrease;
    private readonly Weapon _playerWeapon;

    public PlayerEventArgs(int playerIndex)
    {
        _playerIndex = playerIndex;
    }

    public PlayerEventArgs(int playerIndex, Weapon weapon)
    {
        _playerIndex = playerIndex;
        _playerWeapon = weapon;
    }
    public PlayerEventArgs(int playerIndex, bool ammoIncrease)
    {
        _playerIndex = playerIndex;
        _ammoIncrease = ammoIncrease;
    }
    public PlayerEventArgs(int playerIndex, Weapon weapon, bool ammoIncrease)
    {
        _playerIndex = playerIndex;
        _playerWeapon = weapon;
        _ammoIncrease = ammoIncrease;
    }


    public int playerIndex
    {
        get { return _playerIndex; }
    }
    public Weapon weapon
    {
        get { return _playerWeapon; }
    }
    public bool ammoIncrease
    {
        get { return _ammoIncrease; }
    }
}

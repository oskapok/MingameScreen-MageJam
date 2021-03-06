using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerEventArgs : EventArgs
{
    private readonly int _playerIndex;
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

    public int playerIndex
    {
        get { return _playerIndex; }
    }
    public Weapon weapon
    {
        get { return _playerWeapon; }
    }
}

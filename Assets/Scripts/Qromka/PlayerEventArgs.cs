using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerEventArgs : EventArgs
{
    private readonly int _playerIndex;

    public PlayerEventArgs(int playerIndex)
    {
        _playerIndex = playerIndex;
    }

    public int playerIndex
    {
        get { return _playerIndex; }
    }
}

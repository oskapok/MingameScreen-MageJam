using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardEventArgs : EventArgs
{
    private readonly int _playerIndex;
    private readonly ScoreType _scoreType;

    public BoardEventArgs(int playerIndex)
    {
        _playerIndex = playerIndex;
    }

    public BoardEventArgs(int playerIndex, ScoreType scoreType)
    {
        _playerIndex = playerIndex;
        _scoreType = scoreType;
    }

    public int playerIndex
    {
        get { return _playerIndex; }
    }
    public ScoreType scoreType
    {
        get { return _scoreType; }
    }
}

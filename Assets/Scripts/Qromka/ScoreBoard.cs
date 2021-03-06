using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int numberOfPlayers;

    List<int> points = new List<int>();

    public static ScoreBoard Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            PrepareBoard();
        }


        //If duplicate abort
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Mark as permament
        DontDestroyOnLoad(gameObject);
    }
    public void AddPoint(int playerIndex)
    {
        points[playerIndex] += 1;
    }

    void PrepareBoard()
    {
        for (int i = 0; i< numberOfPlayers; i++)
        {
            points.Add(0);
        }
    }
    
}

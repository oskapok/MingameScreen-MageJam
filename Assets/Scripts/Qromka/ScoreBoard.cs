using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    int numberOfPlayers;

    public static event EventHandler<BoardEventArgs> updateScoreBoard;

    static List<string> points = new List<string>();

    public static ScoreBoard Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        //If duplicate abort
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Mark as permament
        DontDestroyOnLoad(gameObject);
    }
    public void AddPoint(int playerIndex, ScoreType score)
    {
        points[playerIndex] += ((int)(score)).ToString();
        updateScoreBoard?.Invoke(this, new BoardEventArgs(playerIndex,score));
    }

    public string  GetPoints(int playerIndex)
    {
        return points[playerIndex];
    }
    private void Start()
    {
        PrepareBoard();
    }
    void PrepareBoard()
    {
        numberOfPlayers = GameManager.Instance.GetNumberOfPlayers();
        if(points.Count ==0)
        {
            for (int i = 0; i< numberOfPlayers; i++)
            {
                points.Add("");
            }
        }
    }
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UI_ScoreBoard : MonoBehaviour
{
    [SerializeField]
    GameObject uI_Board;

    [SerializeField]
    float duration = 4f;

    [SerializeField]
    Text countDownText;


    [SerializeField]
    GameObject winTagPrefab;

    [SerializeField]
    GameObject KillTagPrefab;


    [SerializeField]
    GameObject uI_Player1Board;
    [SerializeField]
    GameObject uI_Player2Board;
    [SerializeField]
    GameObject uI_Player3Board;
    [SerializeField]
    GameObject uI_Player4Board;

    private void OnEnable()
    {
        countDownText.text = duration.ToString();
        StartCoroutine(CountDown());
    }
    private IEnumerator CountDown()
    {
        int remaingSeconds = (int)duration;
        while (remaingSeconds >= 1)
        {
             yield return new WaitForSeconds(1);
            remaingSeconds--;
            countDownText.text = remaingSeconds.ToString();

        }
        uI_Board.SetActive(false);
    }
    void AddScore(object sender, BoardEventArgs e)
    {
        ScoreType type = e.scoreType;

        GameObject scoreTag;
        if (type == ScoreType.killPoint)
            scoreTag = winTagPrefab;
        else
            scoreTag = KillTagPrefab;

        switch (e.playerIndex)
        {
            case 0:
                Instantiate(scoreTag, uI_Player1Board.transform.GetChild(1).transform);
                break;
            case 1:
                Instantiate(scoreTag, uI_Player2Board.transform.GetChild(1).transform);
                break;
            case 2:
                Instantiate(scoreTag, uI_Player3Board.transform.GetChild(1).transform);
                break;
            case 3:
                Instantiate(scoreTag, uI_Player4Board.transform.GetChild(1).transform);
                break;
        }
    }

   void SetUpBoard()
    {
        switch(GameManager.Instance.GetNumberOfPlayers())
        {
            case 2:
                uI_Player3Board.SetActive(false);
                uI_Player4Board.SetActive(false);
                break;
            case 3:
                uI_Player4Board.SetActive(false);
                break;
            case 4:
                break;
        }
        
        
    }
    void Start()
    {
        ScoreBoard.updateScoreBoard += AddScore;
        SetUpBoard();
    }
    void OnDestroy()
    {
        ScoreBoard.updateScoreBoard -= AddScore;
    }


}

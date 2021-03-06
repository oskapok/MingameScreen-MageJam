using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEST : MonoBehaviour
{
    private void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            ScoreBoard.Instance.AddPoint(0,ScoreType.killPoint);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            ScoreBoard.Instance.AddPoint(1, ScoreType.winPoint);
        }
    }
}

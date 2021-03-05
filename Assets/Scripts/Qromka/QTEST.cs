using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEST : MonoBehaviour
{
    private void Start()
    {

        SoundManager.Instance.PlayMusic("19Floor");
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SoundManager.Instance.PlaySFX("laserWave");
        }
    }
}

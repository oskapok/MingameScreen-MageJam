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
            Debug.Log(GameManager.Instance.AddAmmo(0));
        }
        else if(Input.GetKeyDown(KeyCode.Keypad2))
        {
            Debug.Log(GameManager.Instance.AddAmmo(1));
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            Debug.Log(GameManager.Instance.AddAmmo(2));
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            Debug.Log(GameManager.Instance.AddAmmo(3));
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(GameManager.Instance.SwitchWeapon(0,Weapon.Rifle));
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log(GameManager.Instance.SwitchWeapon(1, Weapon.Shotgun));
        }
    }
}

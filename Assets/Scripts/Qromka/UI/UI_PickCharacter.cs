using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PickCharacter : MonoBehaviour
{


    Sprite notReady;
    public UI_Game uI;


    [SerializeField]
    Image p1_Head, p2_Head, p3_Head, p4_Head, p1_Tag, p2_Tag, p3_Tag, p4_Tag;

    bool p1Playing, p2Playing, p3Playing, p4Playing,canStart;

    [SerializeField]
    Text infoText;

    int numberofplayers = 2;

    private void Start()
    {
        SoundManager.Instance.PlayMusic("RPS_-_The_Game_Is_Here_loop");
        p1Playing = false; 
        p2Playing = false;
        p3Playing = false;
        p4Playing = false;
    }

    private void Update()
    {
        if(!p1Playing)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                p1Playing = true;
                PlayerReady(0);
            }
        }

        if (!p2Playing)
        {
           if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                p2Playing = true;
                PlayerReady(1);
            }
        }

        if (!p3Playing)
        {
            if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L))
            {
                p3Playing = true;
                PlayerReady(2);
            }
        }

        if (!p4Playing)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetAxisRaw("Horizontal_P4") <= 0.6)
            {
                p4Playing = true;
                PlayerReady(3);
            }
        }

        if(p1Playing && p2Playing && !p3Playing && !p3Playing)
        {
            infoText.text = "P1 & P2 - Space to Start";
            numberofplayers = 2;
            canStart = true;
        }
        else if (p1Playing && p2Playing && p3Playing && !p4Playing)
        {
            infoText.text = "P1 & P2 & P3 - Space to Start";
            numberofplayers = 3;
            canStart = true;
        }
        else if (p1Playing && p2Playing && p3Playing && p4Playing)
        {
            infoText.text = "P1 & P2 & P3 & P4 - Space to Start";
            numberofplayers = 4;
            canStart = true;
        }

        if(Input.GetKeyDown(KeyCode.Space) && canStart)
        {
            GameManager.Instance.SetUpScene(numberofplayers);
            Destroy(this);
        }
    }

    private void Awake()
    {
        if (uI == null)
            uI = GameObject.FindObjectOfType<UI_Game>().GetComponent<UI_Game>();
    }

    void PlayerReady(int playerIndex)
    {
        switch(playerIndex)
        {
            case 0:
                p1_Head.sprite = uI.sprites[6];
                p1_Tag.sprite = uI.sprites[10];
                break;

            case 1:
                p2_Head.sprite = uI.sprites[7];
                p2_Tag.sprite = uI.sprites[11];
                break;

            case 2:
                p3_Head.sprite = uI.sprites[8];
                p3_Tag.sprite = uI.sprites[12];
                break;

            case 3:
                p4_Head.sprite = uI.sprites[9];
                p4_Tag.sprite = uI.sprites[13];
                break;
        }
    }


}

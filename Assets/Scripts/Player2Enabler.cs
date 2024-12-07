using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Enabler : MonoBehaviour
{
    public GameObject player2;

    public bool player2IsHere;

    // Start is called before the first frame update
    void Start()
    {
        if(player2.active)
        {
            player2IsHere = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("RHorizontal") != 0.0f || Input.GetAxisRaw("RVertical") != 0.0f)
        {
            player2.SetActive(true);
            player2IsHere = true;
        }
        if (Input.GetKey(KeyCode.JoystickButton0) ||
            Input.GetKey(KeyCode.JoystickButton1) ||
            Input.GetKey(KeyCode.JoystickButton2) ||
            Input.GetKey(KeyCode.JoystickButton3) ||
            Input.GetKey(KeyCode.JoystickButton4) ||
            Input.GetKey(KeyCode.JoystickButton5) ||
            Input.GetKey(KeyCode.JoystickButton6) ||
            Input.GetKey(KeyCode.JoystickButton7) ||
            Input.GetKey(KeyCode.JoystickButton8) ||
            Input.GetKey(KeyCode.JoystickButton9) ||
            Input.GetKey(KeyCode.JoystickButton10)
            )
        {
            player2.SetActive(true);
            player2IsHere = true;
        }

        if (player2IsHere && Input.GetKey(KeyCode.Joystick1Button9))
        {
            player2.SetActive(false);
            player2IsHere = false;
        } 
    }
}

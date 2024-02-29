using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static Action PlayerLeftEvent;
    public static Action PlayerRightEvent;
    public static Action PlayerUpEvent;
    public static Action PlayerDownEvent;

    private void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            PlayerLeftEvent?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            PlayerRightEvent?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PlayerUpEvent?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            PlayerDownEvent?.Invoke();
        }
    }
}
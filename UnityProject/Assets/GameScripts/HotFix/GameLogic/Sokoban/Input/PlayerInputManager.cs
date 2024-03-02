using System;
using UnityEngine;

namespace GameLogic.Sokoban
{
    public class PlayerInputManager : GameBase.Manager
    {
        public static Action PlayerLeftEvent;
        public static Action PlayerRightEvent;
        public static Action PlayerUpEvent;
        public static Action PlayerDownEvent;

        public override void Awake()
        {
            base.Awake();
            _GameRoot.OnUpdate += OnUpdate;

        }

        private void OnUpdate()
        {
            PlayerInput();
        }

        public void OnReset()
        {
            PlayerLeftEvent  = null;
            PlayerRightEvent = null;
            PlayerUpEvent    = null;
            PlayerDownEvent  = null;
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
}
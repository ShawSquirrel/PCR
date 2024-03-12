﻿using System.Collections.Generic;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class SurvivorGameRoot : GameBase.GameRoot
    {
        public FSM<Enum_SurvivorProcedure> _FSM;
        public InputSystem _Input;
        public CharacterSystem _Character;
        public EnemySystem _Enemy;
        public TimeSystem _Time;
        public UIEvent _UIEvent;

        protected override void OnInit()
        {
            base.OnInit();
            FSMInit();
            AddUIListen();
        }

        private void AddUIListen()
        {
            _UIEvent = new UIEvent();
            _UIEvent.AddListen();
        }

        private void RemoveUIListen()
        {
            _UIEvent.RemoveListen();
            _UIEvent = null;
        }

        private void AddSystem()
        {
            _Input = AddManager<InputSystem>();
            _Character = AddManager<CharacterSystem>();
            _Enemy = AddManager<EnemySystem>();
            _Time = AddManager<TimeSystem>();
            
        }

        private void AddListen()
        {
            GameEvent.AddEventListener(EventID_Survivor.Survivor_Release, Release);
        }

        private void RemoveListen()
        {
            GameEvent.RemoveEventListener(EventID_Survivor.Survivor_Release, Release);
        }

        private void FSMInit()
        {
            _FSM = new FSM<Enum_SurvivorProcedure>();
            _FSM.AddState(Enum_SurvivorProcedure.Menu, new SurvivorMenuProcedure(_FSM, this));
            _FSM.AddState(Enum_SurvivorProcedure.GameLaunching, new SurvivorLaunchingProcedure(_FSM, this));
            _FSM.StartState(Enum_SurvivorProcedure.Menu);
            
            
            Utility.Unity.AddUpdateListener(_FSM.Update);
        }

        protected override void Release()
        {
            base.Release();
            _Input.Release();
            _Character.Release();
            _Enemy.Release();
        }

        protected override void Destroy()
        {
            base.Destroy();
            _UIEvent.RemoveListen();
            _UIEvent = null;
        }

        public SurvivorGameRoot(GameObject obj) : base(obj)
        {
        }

        public void Init()
        {
            AddListen();
            AddSystem();
            _Character.LoadCharacter("佩可");
        }
    }
}
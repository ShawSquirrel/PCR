using System.Collections.Generic;
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
        public SkillSystem _Skill;
        public UIEvent _UIEvent;

        protected override void OnInit()
        {
            base.OnInit();
            FSMInit();
            AddListen();
            AddUIListen();
            AddSystem();
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
            _Skill = AddManager<SkillSystem>();
            
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

        private float lastGenTime = 0;
        public void CreateEnemy()
        {
            if (lastGenTime > 5f)
            {
                Game._SurvivorGameRoot._Enemy.CreateEnemy("镜华");
                lastGenTime = 0;
            }

            lastGenTime += Time.deltaTime;
        }
        
        public SurvivorGameRoot(GameObject obj) : base(obj)
        {
        }

        public void StartGame(string name)
        {
            _Character.LoadCharacter(name);
            _Skill.CreateSkill("Sword");
        }
    }
}
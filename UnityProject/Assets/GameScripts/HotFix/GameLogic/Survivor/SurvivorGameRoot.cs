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
        public Config.ConfigSystem _Config;
        public MapSystem _Map;
        public UIEvent _UIEvent;

        protected override void OnInit()
        {
            base.OnInit();
            AddSystem();
            AddListen();
            AddUIListen();
            // FSMInit();
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
            _Config = AddManager<Config.ConfigSystem>();
            _Map = AddManager<MapSystem>();
        }

        private void AddListen()
        {
            GameEvent.AddEventListener(EventID_Survivor.Survivor_Release, Release);
        }

        private void RemoveListen()
        {
            GameEvent.RemoveEventListener(EventID_Survivor.Survivor_Release, Release);
        }

        public void FSMInit()
        {
            _FSM = new FSM<Enum_SurvivorProcedure>();
            _FSM.AddState(Enum_SurvivorProcedure.Menu, new SurvivorMenuProcedure(_FSM, this));
            _FSM.AddState(Enum_SurvivorProcedure.GameLaunching, new SurvivorLaunchingProcedure(_FSM, this));
            _FSM.AddState(Enum_SurvivorProcedure.GameTest, new SurvivorLaunchingProcedure(_FSM, this));
            _FSM.StartState(Enum_SurvivorProcedure.Menu);


            Utility.Unity.AddUpdateListener(_FSM.Update);
        }

        public override void Release()
        {
            base.Release();
            _Input.Release();
            _Character.Release();
            _Enemy.Release();
        }

        public override void Destroy()
        {
            base.Destroy();
            _UIEvent.RemoveListen();
            _UIEvent = null;
        }

        private float _lastGenTime = 0;

        public void CreateEnemy()
        {
            if (_lastGenTime > 5f)
            {
                Game._SurvivorGameRoot._Enemy.CreateEnemy("镜华");
                _lastGenTime = 0;
            }

            _lastGenTime += Time.deltaTime;
        }

        public SurvivorGameRoot(GameObject obj) : base(obj)
        {
        }

        public void StartGame(string name)
        {
            _Character.LoadCharacter(name);
            _Map.LoadMap(_Character.TFCharacter);
            _Skill.CreateSkill("Sword");
        }
    }
}
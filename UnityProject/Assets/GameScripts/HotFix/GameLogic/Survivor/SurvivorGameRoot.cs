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
        public UISystem _UI;
        public CameraSystem _Camera;
        public LevelSystem _Level;

        public SurvivorGameRoot(GameObject obj) : base(obj)
        {
            Utility.Unity.AddDestroyListener(Destroy);
        }

        public override void Init()
        {
            base.Init();
            AddSystem();
            AddListen();
            FSMInit();

            _UI.Start();
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
            _UI = AddManager<UISystem>();
            _Camera = AddManager<CameraSystem>();
            _Level = AddManager<LevelSystem>();
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


        public void Start(string name)
        {
            _Character.LoadCharacter(name);
            _Map.Start();
            _Skill.Start();
            _Input.Start();
            _Enemy.Start();
            _Camera.Start();
            _Level.Start();
        }

        public override void Release()
        {
            base.Release();
            _Character.Release();
            _Skill.Release();
            _Input.Release();
            _Map.Release();
            _Enemy.Release();
            _Camera.Release();
            _Level.Release();
        }

        public override void Destroy()
        {
            base.Destroy();
            _UI.Release();
        }
    }
}
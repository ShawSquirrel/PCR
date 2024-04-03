using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class SurvivorGameRoot : GameBase.GameRoot
    {
        private FSM<Enum_SurvivorProcedure> _FSM;
        private InputSystem _Input;
        public CharacterSystem _Character;
        public EnemySystem _Enemy;
        private TimeSystem _Time;
        public SkillSystem _Skill;
        public Config.ConfigSystem _Config;
        private MapSystem _Map;
        private UISystem _UI;
        private CameraSystem _Camera;
        private LevelSystem _Level;

        public SurvivorGameRoot(GameObject obj) : base(obj)
        {
            Utility.Unity.AddDestroyListener(Destroy);
        }

        public override void Init()
        {
            base.Init();
            AddSystem();
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

        private void FSMInit()
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
            // TODO:后续做成无参变量
            _Character.LoadCharacter(name);
            _Map.Start();
            _Skill.Start();
            _Input.Start();
            _Enemy.Start();
            _Camera.Start();
            _Level.Start();
        }

        /// <summary>
        /// 释放资源
        /// </summary>
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
            Release();
            _UI.Release();
        }

        /// <summary>
        /// 改变状态机状态
        /// </summary>
        /// <param name="procedure"></param>
        public void ChangeState(Enum_SurvivorProcedure procedure)
        {
            _FSM.ChangeState(procedure);
        }

        public Transform GetCharacterTransform()
        {
            return _Character.GetCharacterTransform();
        }

        public float GetSKillTowards()
        {
            return _Skill.Angle;
        }
        public LevelSystem GetLevel()
        {
            return _Level;
        }

        public void CreateEnemy()
        {
            _Enemy.CreateEnemy();
        }
    }
}
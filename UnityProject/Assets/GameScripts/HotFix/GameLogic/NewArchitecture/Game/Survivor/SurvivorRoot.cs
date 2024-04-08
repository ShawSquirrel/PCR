using GameConfig;
using GameLogic.NewArchitecture.Core;
using TEngine;
using UnityEngine;
using Utility = TEngine.Utility;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class SurvivorRoot : Core.Game, ISingleton
    {
        public static SurvivorRoot Instance => SingletonGroup.GetSingleton<SurvivorRoot>();

        public void OnSingletonInit()
        {
            
        }


        public override void Awake()
        {
            base.Awake();
            Utility.Unity.AddUpdateListener(OnUpdate);
            AddModel<GameModel>();
            AddModel<CharacterModel>();
            
            
            InitUnit(null, "SurvivorRoot");
            AddSystem<SurvivorProcedureSystem>();
            AddSystem<InputSystem>();
            AddSystem<MoveSystem>();
            AddSystem<CharacterSystem>();
            AddSystem<CameraSystem>();
            AddSystem<MapSystem>();
            AddSystem<SkillSystem>();

            
            GetSystem<SurvivorProcedureSystem>().StartFSM();

        }




        public void StartGame()
        {
            Init();
        }
        
        
        public override void Init()
        {
            base.Init();
            GetModel<CharacterModel>().Init();
            
            GetSystem<InputSystem>().Init();
            GetSystem<MoveSystem>().Init();
            GetSystem<CharacterSystem>().Init();
            GetSystem<CameraSystem>().Init();
            GetSystem<MapSystem>().Init();
            GetSystem<SkillSystem>().Init();
            
            
            GetSystem<SkillSystem>().CreateSkill(SkillType.Sword);

        }

        public override void Release()
        {
            base.Release();
            GetModel<CharacterModel>().Release();
            
            GetSystem<InputSystem>().Release();
            GetSystem<MoveSystem>().Release();
            GetSystem<CharacterSystem>().Release();
            GetSystem<CameraSystem>().Release();
            GetSystem<MapSystem>().Release();
            GetSystem<SkillSystem>().Release();
        }

        public override void Destroy()
        {
            base.Destroy();
            Utility.Unity.RemoveUpdateListener(OnUpdate);
            RemoveAllModel();
            RemoveAllSystem();
            DestroyUnit();
        }
        
        private void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameModule.UI.ShowUI<UI_Result>();
            }
            
        }
    }
}
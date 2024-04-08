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
            InitUnit(null, "SurvivorRoot");
            AddSystem<SurvivorProcedureSystem>();

            AddModel<GameModel>();
            AddModel<CharacterMode>();
            
            GetSystem<SurvivorProcedureSystem>().Init();

        }




        public void StartGame()
        {
            Init();
        }
        
        
        public override void Init()
        {
            base.Init();
            GetModel<CharacterMode>().Init();

        }

        public override void Release()
        {
            base.Release();
            GetModel<CharacterMode>().Release();
        }

        public override void Destroy()
        {
            base.Destroy();
            Utility.Unity.RemoveUpdateListener(OnUpdate);
            Release();
            DestroyUnit();
            RemoveAllSystem();
            RemoveAllModel();
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
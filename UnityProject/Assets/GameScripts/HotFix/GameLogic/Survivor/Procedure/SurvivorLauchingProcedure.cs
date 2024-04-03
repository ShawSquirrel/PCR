using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class SurvivorLaunchingProcedure : SurvivorProcedureBase
    {
        public bool _IsDie = false;
        public SurvivorLaunchingProcedure(FSM<Enum_SurvivorProcedure> fsm, SurvivorGameRoot target) : base(fsm, target)
        {
        }

        protected override void AddListen()
        {
            base.AddListen();
            GameEvent.AddEventListener(EventID_Survivor.Survivor_Die, OnDie);
        }

        protected override void RemoveListen()
        {
            base.RemoveListen();
            GameEvent.RemoveEventListener(EventID_Survivor.Survivor_Die, OnDie);
        }

        private void OnDie()
        {
            _IsDie = true;
            GameModule.UI.ShowUI<UI_Result>();
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            mTarget.Start("佩可");
            Game._GameRoot.CloseVideoUI();
            GameModule.UI.ShowUI<UI_SurvivorStick>();
            GameModule.UI.ShowUI<UI_Infomation>();

            LevelSystem level = mTarget.GetLevel();
            UI_LevelData uiLevelData = new UI_LevelData
            {
                _ExpMax = level.LevelExpMax,
                _CurExp = level.CurLevelExp,
                _Level = level.Level
            };
            GameModule.UI.ShowUI<UI_Level>(uiLevelData);
            
            
            Time.timeScale = 1;
            _IsDie = false;
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            if (_IsDie) return;
            mTarget.CreateEnemy();
        }
    }
}
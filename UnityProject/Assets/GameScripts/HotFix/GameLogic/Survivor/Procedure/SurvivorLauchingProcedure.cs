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
            Game._GameRoot.CloseVideoUI();
            GameModule.UI.ShowUI<UI_SurvivorStick>();
            GameModule.UI.ShowUI<UI_Infomation>();
            Game._SurvivorGameRoot._Skill.OpenUpdateSkillTowards();
            mTarget.Start("佩可");
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
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class SurvivorLaunchingProcedure : SurvivorProcedureBase
    {
        private float lastGenTime = 0;

        public SurvivorLaunchingProcedure(FSM<Enum_SurvivorProcedure> fsm, SurvivorGameRoot target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            Game._GameRoot.CloseVideoUI();
            GameModule.UI.ShowUI<UI_SurvivorStick>();
            GameModule.UI.ShowUI<UI_Blood>();
            Time.timeScale = 1;
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            if (lastGenTime > 5f)
            {
                Game._SurvivorGameRoot._Enemy.CreateEnemy();
                lastGenTime = 0;
            }

            lastGenTime += Time.deltaTime;
        }
        
        
    }
}
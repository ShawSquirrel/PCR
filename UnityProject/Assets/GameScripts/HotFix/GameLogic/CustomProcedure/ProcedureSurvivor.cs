using System.Collections.Generic;
using GameLogic.Sokoban;
using GameLogic.Survivor;
using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class ProcedureSurvivor : CustomProcedureBase
    {
        private FSM<Enum_SurvivorProcedure> _fsm = new FSM<Enum_SurvivorProcedure>();
        public SurvivorGameRoot Root => Game._SurvivorGameRoot;

        public ProcedureSurvivor(FSM<Enum_Procedure> fsm, CustomProcedureModule target) : base(fsm, target)
        {
            Game._SurvivorGameRoot = new GameObject("SurvivorGameRoot").AddComponent<SurvivorGameRoot>();

            _fsm.AddState(Enum_SurvivorProcedure.Menu, new SurvivorMenuProcedure(_fsm, this));
            _fsm.AddState(Enum_SurvivorProcedure.GameLaunching, new SurvivorLaunchingProcedure(_fsm, this));
            _fsm.StartState(Enum_SurvivorProcedure.Menu);

            GameRoot._Instance.OpenVideoUI(); // 打开视频背景
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            _fsm.Update();
        }
    }
}
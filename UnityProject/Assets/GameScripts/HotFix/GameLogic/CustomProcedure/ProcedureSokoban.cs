using System.Collections.Generic;
using GameLogic.Sokoban;
using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class ProcedureSokoban : CustomProcedureBase
    {
        public FSM<Enum_SokobanProcedure> _FSM = new FSM<Enum_SokobanProcedure>();
        public SokobanGameRoot _GameRoot => Game._SokobanGameRoot;

        public ProcedureSokoban(FSM<Enum_Procedure> fsm, CustomProcedureModule target) : base(fsm, target)
        {
            Game._SokobanGameRoot = new SokobanGameRoot(new GameObject("SokobanGameRoot"));

            _FSM.AddState(Enum_SokobanProcedure.GameMenu, new SokobanMenuProcedure(_FSM, this));
            _FSM.AddState(Enum_SokobanProcedure.GameLoading, new SokobanLoadingProcedure(_FSM, this));
            _FSM.AddState(Enum_SokobanProcedure.GameLaunching, new SokobanLaunchingProcedure(_FSM, this));
            _FSM.AddState(Enum_SokobanProcedure.GameSuccess, new SokobanSuccessProcedure(_FSM, this));
            _FSM.AddState(Enum_SokobanProcedure.GameMakeMap, new SokobanMakeMapProcedure(_FSM, this));
            _FSM.AddState(Enum_SokobanProcedure.GameEnterFlash, new SokobanEnterFlashProcedure(_FSM, this));
            _FSM.AddState(Enum_SokobanProcedure.GameExitFlash, new SokobanExitFlashProcedure(_FSM, this));
            _FSM.AddState(Enum_SokobanProcedure.GameCompleteFlash, new SokobanCompleteFlashProcedure(_FSM, this));
            
            _FSM.StartState(Enum_SokobanProcedure.GameMenu);

            
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            _FSM.Update();
        }
    }
}
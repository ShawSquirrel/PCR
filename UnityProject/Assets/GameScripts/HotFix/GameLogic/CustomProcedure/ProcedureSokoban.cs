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
            Game._SokobanGameRoot = new GameObject("SokobanGameRoot").AddComponent<SokobanGameRoot>();

            _FSM.AddState(Enum_SokobanProcedure.GameMenu, new MenuProcedure(_FSM, this));
            _FSM.AddState(Enum_SokobanProcedure.GameLoading, new GameLoadingProcedure(_FSM, this));
            _FSM.AddState(Enum_SokobanProcedure.GameLaunching, new GameLaunchingProcedure(_FSM, this));
            _FSM.AddState(Enum_SokobanProcedure.GameSuccess, new GameSuccessProcedure(_FSM, this));
            _FSM.AddState(Enum_SokobanProcedure.GameMakeMap, new GameMakeMapProcedure(_FSM, this));
            
            _FSM.StartState(Enum_SokobanProcedure.GameMenu);

            
        }
    }
}
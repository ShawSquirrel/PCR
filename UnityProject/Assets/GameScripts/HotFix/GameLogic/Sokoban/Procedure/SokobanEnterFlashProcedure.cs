using TEngine;
using UnityEngine;

namespace GameLogic.Sokoban
{
    public class SokobanEnterFlashProcedure : SokobanProcedureBase
    {
        public SokobanEnterFlashProcedure(FSM<Enum_SokobanProcedure> fsm, ProcedureSokoban target) : base(fsm, target)
        {
        }

        protected override async void OnEnter()
        {
            base.OnEnter();
            
            await FlashStart();
            
            
        }

       
    }
}
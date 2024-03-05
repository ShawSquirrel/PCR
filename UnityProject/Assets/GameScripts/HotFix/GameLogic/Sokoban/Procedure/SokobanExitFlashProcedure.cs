using TEngine;
using UnityEngine;

namespace GameLogic.Sokoban
{
    public class SokobanExitFlashProcedure : SokobanProcedureBase
    {
        public SokobanExitFlashProcedure(FSM<Enum_SokobanProcedure> fsm, ProcedureSokoban target) : base(fsm, target)
        {
        }

        protected override async void OnEnter()
        {
            base.OnEnter();
            
            await FlashEnd();
            Enum_SokobanProcedure nextProcedure = (Enum_SokobanProcedure)GameModule.Setting.GetInt(Setting.NextSokobanProcedure);
            mFSM.ChangeState(nextProcedure);
        }

       
    }
}
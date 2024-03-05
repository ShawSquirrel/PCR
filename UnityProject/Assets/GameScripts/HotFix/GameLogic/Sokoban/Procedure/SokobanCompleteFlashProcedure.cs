using TEngine;
using UnityEngine;

namespace GameLogic.Sokoban
{
    public class SokobanCompleteFlashProcedure : SokobanProcedureBase
    {
        public SokobanCompleteFlashProcedure(FSM<Enum_SokobanProcedure> fsm, ProcedureSokoban target) : base(fsm, target)
        {
        }

        protected override async void OnEnter()
        {
            base.OnEnter();
            
            await FlashStart();
            await FlashEnd();
            Enum_SokobanProcedure nextProcedure = (Enum_SokobanProcedure)GameModule.Setting.GetInt(Setting.NextSokobanProcedure);
            mFSM.ChangeState(nextProcedure);
        }

       
    }
}
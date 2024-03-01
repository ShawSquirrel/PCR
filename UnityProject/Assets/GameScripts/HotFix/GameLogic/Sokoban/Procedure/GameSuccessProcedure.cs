using TEngine;

namespace GameLogic.Sokoban
{
    public class GameSuccessProcedure : SokobanProcedureBase
    {
        public GameSuccessProcedure(FSM<Enum_SokobanProcedure> fsm, ProcedureSokoban target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            GameModule.UI.ShowUI<UI_SokobanSuccess>();
        }
    }
}
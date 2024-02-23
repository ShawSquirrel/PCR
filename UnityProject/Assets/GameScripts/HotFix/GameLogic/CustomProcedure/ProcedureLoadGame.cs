using TEngine;

namespace GameLogic
{
    public class ProcedureLoadGame : CustomProcedureBase
    {
        public ProcedureLoadGame(FSM<Enum_Procedure> fsm, CustomProcedureModule target) : base(fsm, target)
        {
            
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            GameRoot._Instance.AddManager<MapManager>();
            GameRoot._Instance.AddManager<CharacterManager>();
        }
    }
}
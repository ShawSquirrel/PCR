using TEngine;

namespace GameLogic.Survivor
{
    public class CharacterProcedureBase : AbstractState<Enum_ChracterState, CharacterManager>
    {
        public CharacterProcedureBase(FSM<Enum_ChracterState> fsm, CharacterManager target) : base(fsm, target)
        {
        }
    }
}
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class CharacterProcedureBase : AbstractState<Enum_ChracterState, CharacterCtl>
    {
        public CharacterProcedureBase(FSM<Enum_ChracterState> fsm, CharacterCtl target) : base(fsm, target)
        {
        }
    }
}
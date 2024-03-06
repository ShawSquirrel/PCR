using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class CharacterProcedureBase : AbstractState<Enum_ChracterState, CharacterManager>
    {
        public CharacterCtl Controller => mTarget.CharacterCtl;
        public CharacterProcedureBase(FSM<Enum_ChracterState> fsm, CharacterManager target) : base(fsm, target)
        {
        }
    }
}
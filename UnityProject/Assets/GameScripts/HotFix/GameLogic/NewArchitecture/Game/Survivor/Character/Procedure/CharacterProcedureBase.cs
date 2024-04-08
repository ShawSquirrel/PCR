using TEngine;
using UnityEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class CharacterProcedureBase : AbstractState<Enum_ChracterState, CharacterSystem>
    {
        public CharacterProcedureBase(FSM<Enum_ChracterState> fsm, CharacterSystem target) : base(fsm, target)
        {
        }
    }
}
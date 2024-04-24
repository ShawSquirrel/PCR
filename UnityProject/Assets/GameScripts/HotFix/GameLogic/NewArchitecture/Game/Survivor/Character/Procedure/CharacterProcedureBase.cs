using TEngine;
using UnityEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class CharacterProcedureBase : AbstractState<Enum_ChracterState, ACharacter>
    {
        public CharacterProcedureBase(FSM<Enum_ChracterState> fsm, ACharacter target) : base(fsm, target)
        {
        }
    }
}
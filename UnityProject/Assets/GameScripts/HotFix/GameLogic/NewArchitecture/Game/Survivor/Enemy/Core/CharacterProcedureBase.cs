using TEngine;
using UnityEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class EnemyProcedureBase : AbstractState<Enum_EnemyState, AEnemy>
    {
        public EnemyProcedureBase(FSM<Enum_EnemyState> fsm, AEnemy target) : base(fsm, target)
        {
        }
        
    }
}
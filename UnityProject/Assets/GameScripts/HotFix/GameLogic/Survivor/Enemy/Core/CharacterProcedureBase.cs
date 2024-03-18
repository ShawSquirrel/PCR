using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class EnemyProcedureBase : AbstractState<Enum_EnemyState, EnemyCtl>
    {
        public EnemyProcedureBase(FSM<Enum_EnemyState> fsm, EnemyCtl target) : base(fsm, target)
        {
        }
    }
}
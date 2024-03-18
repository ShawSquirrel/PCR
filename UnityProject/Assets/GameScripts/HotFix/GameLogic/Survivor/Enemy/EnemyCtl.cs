﻿using System;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class EnemyCtl : EntityCtl
    {
        protected FSM<Enum_EnemyState> _fsm;
        public EnemyCtl(string characterName) : base(characterName)
        {
        }

        protected override void FSMInit()
        {
            base.FSMInit();
            _fsm = new FSM<Enum_EnemyState>();
            _fsm.AddState(Enum_EnemyState.Walk, new EnemyWalkProcedure(_fsm, this));
            _fsm.AddState(Enum_EnemyState.Idle, new EnemyIdleProcedure(_fsm, this));
            _fsm.AddState(Enum_EnemyState.Damage, new EnemyDamageProcedure(_fsm, this));
            
            _fsm.StartState(Enum_EnemyState.Walk);
        }

        protected override void Update()
        {
            
        }
    }
}
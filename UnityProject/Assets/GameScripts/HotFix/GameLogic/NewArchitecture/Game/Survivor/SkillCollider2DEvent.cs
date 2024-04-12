using System;
using GameLogic.NewArchitecture.Core;
using UnityEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class SkillCollider2DEvent : MonoBehaviour
    {
        private Action<IUnit> OnTriggerEnter;

        public void AddListen_TriggerEnter(Action<IUnit> onAction)
        {
            OnTriggerEnter += onAction;
        }

        public void RemoveListen_TriggerEnter(Action<IUnit> onAction)
        {
            OnTriggerEnter -= onAction;
        }

        public void RemoveAllListen_TriggerEnter()
        {
            OnTriggerEnter = null;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            IUnit unit = null;
            unit = other.transform.parent.gameObject.GetUnit();
            OnTriggerEnter?.Invoke(unit);
        }
    }
}
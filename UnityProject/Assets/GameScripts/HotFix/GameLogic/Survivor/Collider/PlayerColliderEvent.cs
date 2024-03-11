using System;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class PlayerColliderEvent : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Log.Info($"OnTriggerEnter2D : {other.name}");
            IDamage damage = other.GetComponent<IDamage>();
            if (damage != null)
            {
                GameEvent.Send(EventID_Survivor.Survivor_Damage, damage);
            }
        }
    }
}
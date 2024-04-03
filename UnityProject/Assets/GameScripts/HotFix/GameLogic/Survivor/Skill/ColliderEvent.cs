using System;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class ColliderEvent : MonoBehaviour
    {
        public float _Atk;
        private void OnTriggerEnter2D(Collider2D other)
        {
            
            IDamage damage = Game._SurvivorGameRoot._Enemy.GetEnemyCtlByGameObject(other.transform.parent.gameObject);
            damage.Damage(_Atk);
        }
    }
}
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
            IAtk atk = Game._SurvivorGameRoot._Enemy.GetEnemyCtlByGameObject(other.transform.parent.gameObject);
            Game._SurvivorGameRoot._Character.CharacterCtl.Damage(atk.GetAtk());
        }
    }
}
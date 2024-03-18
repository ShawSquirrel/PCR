using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class CharacterCtl : EntityCtl
    {
        public CharacterCtl(string characterName) : base(characterName)
        {
        }


        protected override void AddListen()
        {
            GameEvent.AddEventListener<Vector2>(EventID_Survivor.Survivor_Move, OnMove);
            GameEvent.AddEventListener<Vector2>(EventID_Survivor.Survivor_MoveStop, OnMove);
            GameEvent.AddEventListener<IDamage>(EventID_Survivor.Survivor_Damage, OnDamage);
        }
        
        protected override void Update()
        {
            GameEvent.Send(UIEventID_Survivor.SetBlood, _entityData._HP / 100);
        }

        protected override void OnDamage(IDamage damage)
        {
            base.OnDamage(damage);
            if (_entityData._HP <= 0)
            {
                return;
            }

            _entityData._HP -= damage.GetAtk();
            if (_entityData._HP <= 0)
            {
                GameEvent.Send(EventID_Survivor.Survivor_Die);
                Time.timeScale = 0;
            }
        }
    }
}
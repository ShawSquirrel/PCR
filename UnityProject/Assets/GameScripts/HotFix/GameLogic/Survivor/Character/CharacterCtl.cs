using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    /// <summary>
    /// 角色控制
    /// </summary>
    public class CharacterCtl : EntityCtl
    {
        public CharacterCtl(string characterName) : base(characterName)
        {
        }


        protected override void AddListen()
        {
            GameEvent.AddEventListener<Vector2>(EventID_Survivor.Survivor_Move, SetTowards);
            GameEvent.AddEventListener<Vector2>(EventID_Survivor.Survivor_MoveStop, SetTowards);
        }

        protected override void Update()
        {
            // 更新UI血条
            GameEvent.Send(UIEventID_Survivor.SetBlood, _EntityBaseData._HP / 100);
        }
        
    }
}
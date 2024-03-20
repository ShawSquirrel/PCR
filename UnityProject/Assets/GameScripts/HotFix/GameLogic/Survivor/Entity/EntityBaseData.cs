using UnityEngine;

namespace GameLogic.Survivor
{
    public class EntityBaseData
    {
        public float _MaxHp;
        public float _HP;
        public float _Atk;
        public float _Def;
        public float _Speed;

        public EntityBaseData(string name)
        {
            var data = Game._SurvivorGameRoot._Config.GetAttributeByName(name);
            _HP    = data._HP;
            _Atk   = data._Atk;
            _Def   = data._Def;
            _Speed = data._Speed;
            _MaxHp = _HP;
        }
    }
}
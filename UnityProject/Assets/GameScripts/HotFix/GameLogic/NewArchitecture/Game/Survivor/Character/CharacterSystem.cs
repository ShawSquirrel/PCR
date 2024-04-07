using GameLogic.NewArchitecture.Core;
using TEngine;
using UnityEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class CharacterSystem : Core.System
    {
        private Unit _characterUnit;

        public override void Awake()
        {
            base.Awake();
        }

        public override void Init()
        {
            base.Init();
            var id = SurvivorRoot.Instance.GetModel<GameModel>().SelectCharacter.Value;
            var sCharacter = ConfigSystem.Instance.Tables.SCharacter.DataList.Find(a => a.CharacterType == id);
            GameObject obj = GameModule.Resource.LoadAsset<GameObject>(sCharacter.Name);
            _characterUnit = new Unit(obj, Unit._TF);
        }

        public override void Release()
        {
            base.Release();
            if (_characterUnit == null) return;
            _characterUnit.Destroy();
            _characterUnit = null;
        }
    }
}
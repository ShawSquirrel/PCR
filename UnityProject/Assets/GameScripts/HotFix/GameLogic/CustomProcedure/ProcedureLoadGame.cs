using Cysharp.Threading.Tasks;
using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class ProcedureLoadGame : CustomProcedureBase
    {
        public CharacterManager _CharacterManager;
        public MapManager _MapManager;

        public ProcedureLoadGame(FSM<Enum_Procedure> fsm, CustomProcedureModule target) : base(fsm, target)
        {
            GameRoot._Instance.AddManager<MapManager>();
            GameRoot._Instance.AddManager<CharacterManager>();

            _CharacterManager = GameRoot._Instance.GetManager<CharacterManager>();
            _MapManager = GameRoot._Instance.GetManager<MapManager>();
        }

        protected override void RegisterEvent()
        {
            base.RegisterEvent();
            GameEvent.AddEventListener<string>(UIEvent.CharacterActionEventID, OnCharacterActionEvent);
        }

        private async void OnCharacterActionEvent(string name)
        {
            Log.Info(name);

            await UniTask.Delay(3000);

        }

        protected override void OnEnter()
        {
            base.OnEnter();




            Character character1 = CreateCharacter("优衣");
            Character character2 = CreateCharacter("镜华");
        }

        public Character CreateCharacter(string characterName)
        {
            Character character = GameModule.Resource.LoadAsset<GameObject>(characterName).AddComponent<Character>();
            character.name = characterName;
            return character;
        }

        public void SetCharacterPos(Character character, Vector2Int pos)
        {
            
            character.SetPos(pos);
        }
    }
}
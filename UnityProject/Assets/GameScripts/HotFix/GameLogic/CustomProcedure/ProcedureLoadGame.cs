using Cysharp.Threading.Tasks;
using TEngine;
using UnityEngine;

namespace GameLogic
{
    public class ProcedureLoadGame : CustomProcedureBase
    {
        private UI_ActionBar _actionBar;

        public ProcedureLoadGame(FSM<Enum_Procedure> fsm, CustomProcedureModule target) : base(fsm, target)
        {
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

            _actionBar.ResetCharacterPercentByName(name);
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            GameRoot._Instance.AddManager<MapManager>();
            GameRoot._Instance.AddManager<CharacterManager>();


            _actionBar = GameModule.UI.ShowUI<UI_ActionBar>().Window as UI_ActionBar;
            CharacterManager characterManager = GameRoot._Instance.GetManager<CharacterManager>();
            MapManager mapManager = GameRoot._Instance.GetManager<MapManager>();

            _actionBar.AddActionBarItem("优衣", null, 30, 0);
            _actionBar.AddActionBarItem("镜华", null, 20, 0);

            characterManager.AddCharacter(new Class_CharacterData() { _Str_CharacterName = "优衣" });
            characterManager.AddCharacter(new Class_CharacterData() { _Str_CharacterName = "镜华" });

            Character character1 = CreateCharacter("优衣");
            Character character2 = CreateCharacter("镜华");
        }

        public Character CreateCharacter(string characterName)
        {
            Character character = GameModule.Resource.LoadAsset<GameObject>(characterName).AddComponent<Character>();
            character.name = characterName;
            return character;
        }
    }
}
using Cysharp.Threading.Tasks;
using TEngine;

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
            _actionBar.AddActionBarItem("优衣", null, 30, 0);
            _actionBar.AddActionBarItem("镜华", null, 15, 0);
        }
        
        
    }
}
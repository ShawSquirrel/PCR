using TEngine;

namespace GameLogic.Sokoban
{
    public class MenuProcedure : SokobanProcedureBase
    {
        public MenuProcedure(FSM<Enum_SokobanProcedure> fsm, ProcedureSokoban target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            UI_SelectLevel ui = GameModule.UI.ShowUI<UI_SelectLevel>().Window as UI_SelectLevel;

            var list = _Root._Level._List_Level;
            foreach (SokobanLevelItem levelItem in list)
            {
                ui.AddBtn(levelItem._Str_Name);
            }
        }
        protected override void RegisterEvent()
        {
            base.RegisterEvent();
            GameEvent.AddEventListener<string>(UIEvent.Sokoban_SelectLevel, OnSelectLevelEvent);
        }

        protected override void RemoveEvent()
        {
            base.RemoveEvent();
            GameEvent.RemoveEventListener<string>(UIEvent.Sokoban_SelectLevel, OnSelectLevelEvent);
        }

        private void OnSelectLevelEvent(string levelName)
        {
            if (_Root._Level.SetCurLoadLevel(levelName))
            {
                mFSM.ChangeState(Enum_SokobanProcedure.GameLoading);
            }
        }

    }
}
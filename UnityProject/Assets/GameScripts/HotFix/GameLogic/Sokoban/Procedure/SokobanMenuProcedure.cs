using TEngine;

namespace GameLogic.Sokoban
{
    public class SokobanMenuProcedure : SokobanProcedureBase
    {
        public SokobanMenuProcedure(FSM<Enum_SokobanProcedure> fsm, ProcedureSokoban target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            UI_SelectLevel ui = GameModule.UI.ShowUI<UI_SelectLevel>().Window as UI_SelectLevel;

            _Root._Level.LoadAllMap();
            
            var list = _Root._Level._List_Level;
            foreach (SokobanLevelItem levelItem in list)
            {
                ui.AddBtn(levelItem._Str_Name);
            }
            
            GameRoot._Instance.OpenVideoUI();
        }
        protected override void RegisterEvent()
        {
            base.RegisterEvent();
            GameEvent.AddEventListener<string>(UIEvent.Sokoban_SelectLevel, OnSelectLevelEvent);
            GameEvent.AddEventListener(UIEvent.Sokoban_MakeMap, OnMakeMap);
        }
        

        protected override void RemoveEvent()
        {
            base.RemoveEvent();
            GameEvent.RemoveEventListener<string>(UIEvent.Sokoban_SelectLevel, OnSelectLevelEvent);
            GameEvent.RemoveEventListener(UIEvent.Sokoban_MakeMap, OnMakeMap);
        }



    }
}
using System.Collections.Generic;
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

            List<string> list = new List<string>();
            foreach (SokobanLevelItem levelItem in _Root._Level._List_Level)
            {
                list.Add(levelItem._Str_Name);
            }
            GameModule.UI.ShowUI<UI_SelectLevel>(list);

            _Root._Level.LoadAllMap();


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
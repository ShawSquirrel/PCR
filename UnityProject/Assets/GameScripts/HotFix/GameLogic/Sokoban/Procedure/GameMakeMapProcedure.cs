using System;
using TEngine;

namespace GameLogic.Sokoban
{
    public class GameMakeMapProcedure : SokobanProcedureBase
    {
        public GameMakeMapProcedure(FSM<Enum_SokobanProcedure> fsm, ProcedureSokoban target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();

            GameModule.UI.ShowUI<UI_MakeMap>();
            
            _Root._Make.LoadMakeMapScene();
        }

        protected override void RegisterEvent()
        {
            base.RegisterEvent();
            GameEvent.AddEventListener<int>(UIEvent.Sokoban_MakeMapSelectType, OnMakeMapSelectType);
            GameEvent.AddEventListener<MakeMapItem>(SokobanEvent.Sokoban_MakeMapClickItem, OnMakeMapClickItem);
        }



        protected override void RemoveEvent()
        {
            base.OnExit();
            GameEvent.RemoveEventListener<int>(UIEvent.Sokoban_MakeMapSelectType, OnMakeMapSelectType);
            GameEvent.RemoveEventListener<MakeMapItem>(SokobanEvent.Sokoban_MakeMapClickItem, OnMakeMapClickItem);
        }

        private void OnMakeMapSelectType(int type)
        {
            _Root._Make._SelectType = (Enum_MaptemType)type;
        }
        
        private void OnMakeMapClickItem(MakeMapItem makeMapItem)
        {
            Enum_MaptemType type = _Root._Make._SelectType;
            
            if (type == Enum_MaptemType.Null) return;
            makeMapItem.Type = type;

        }
    }
}
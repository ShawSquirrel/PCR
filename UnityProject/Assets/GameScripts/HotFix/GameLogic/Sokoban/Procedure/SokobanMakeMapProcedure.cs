using System;
using TEngine;

namespace GameLogic.Sokoban
{
    public class SokobanMakeMapProcedure : SokobanProcedureBase
    {
        public SokobanMakeMapProcedure(FSM<Enum_SokobanProcedure> fsm, ProcedureSokoban target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();

            GameRoot._Instance.CloseVideoUI();
            
            GameModule.UI.ShowUI<UI_MakeMap>();

            _Root._Make.LoadMakeMapScene();
        }

        protected override void RegisterEvent()
        {
            base.RegisterEvent();
            GameEvent.AddEventListener<int>(UIEventID.Sokoban_MakeMapSelectType, OnMakeMapSelectType);
            GameEvent.AddEventListener<MakeMapItem>(SokobanEvent.Sokoban_MakeMapClickItem, OnMakeMapClickItem);
            GameEvent.AddEventListener(UIEventID.Sokoban_MakeMapSave, OnMakeMapSave);
            GameEvent.AddEventListener(UIEventID.Sokoban_MakeMapClose, OnMakeMapClose);
            GameEvent.AddEventListener(UIEventID.Sokoban_MakeMapRevert, OnMakeMapRevert);
        }


        protected override void RemoveEvent()
        {
            base.RemoveEvent();
            GameEvent.RemoveEventListener<int>(UIEventID.Sokoban_MakeMapSelectType, OnMakeMapSelectType);
            GameEvent.RemoveEventListener<MakeMapItem>(SokobanEvent.Sokoban_MakeMapClickItem, OnMakeMapClickItem);
            GameEvent.RemoveEventListener(UIEventID.Sokoban_MakeMapSave, OnMakeMapSave);
            GameEvent.RemoveEventListener(UIEventID.Sokoban_MakeMapClose, OnMakeMapClose);
            GameEvent.RemoveEventListener(UIEventID.Sokoban_MakeMapRevert, OnMakeMapRevert);
        }

        protected override void OnExit()
        {
            base.OnExit();
            _Root._Make.OnReset();
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

        private void OnMakeMapSave()
        {
            GameModule.UI.ShowUI<UI_GeneralWindow>(new UI_GeneralWindowData
                                                   {
                                                       OnConfirm = SaveMap,
                                                       OnCancel  = null
                                                   });
        }

        private void SaveMap(string levelName)
        {
            if (string.IsNullOrEmpty(levelName))
            {
                levelName = "自制关卡";
            }

            _Root._Make.Save(levelName);
            mFSM.ChangeState(Enum_SokobanProcedure.GameMenu);
            GameModule.UI.CloseWindow<UI_MakeMap>();
        }

        private void OnMakeMapRevert()
        {
            _Root._Make.Revert();
        }

        private void OnMakeMapClose()
        {
            mFSM.ChangeState(Enum_SokobanProcedure.GameMenu);
        }
    }
}
using System.Collections.Generic;
using GameConfig;
using GameLogic.NewArchitecture.Game.Main;
using TEngine;
using UnityEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class SurvivorProcedure_Menu : SurvivorProcedureBase
    {
        public SurvivorProcedure_Menu(FSM<SurvivorProcedureType> fsm, SurvivorRoot target) : base(fsm, target)
        {
        }

        public override void AddListen()
        {
            base.AddListen();
            GameEvent.AddEventListener(EventID.ReturnSelectGameID, OnReturnSelectGame);
            GameEvent.AddEventListener(EventID.OpenSelectCharacterPanel, OnOpenSelectCharacterPanel);
            GameEvent.AddEventListener(EventID.CloseSelectCharacterPanel, OnCloseSelectCharacterPanel);
            GameEvent.AddEventListener<TCharacterID>(EventID.SelectCharacter, OnSelectCharacter);
            GameEvent.AddEventListener(EventID.StartGame, OnStartGame);
        }

        public override void RemoveListen()
        {
            base.RemoveListen();
            GameEvent.RemoveEventListener(EventID.ReturnSelectGameID, OnReturnSelectGame);
            GameEvent.RemoveEventListener(EventID.OpenSelectCharacterPanel, OnOpenSelectCharacterPanel);
            GameEvent.RemoveEventListener(EventID.CloseSelectCharacterPanel, OnCloseSelectCharacterPanel);
            GameEvent.RemoveEventListener<TCharacterID>(EventID.SelectCharacter, OnSelectCharacter);
            GameEvent.RemoveEventListener(EventID.StartGame, OnStartGame);
        }


        protected override void OnEnter()
        {
            base.OnEnter();
            GameModule.UI.ShowUI<UI_SurvivorMenu>();
        }


        private void OnReturnSelectGame()
        {
            GameModule.UI.CloseWindow<UI_SurvivorMenu>();
            MainRoot.Instance.GetSystem<ProcedureSystem>().ChangeState(MainProcedureType.Menu);
        }

        private void OnOpenSelectCharacterPanel()
        {
            var list = ConfigSystem.Instance.Tables.SCharacter.DataList;
            List<UI_SelectCharacterData> uiSelectCharacterData = new List<UI_SelectCharacterData>();
            foreach (var character in list)
            {
                uiSelectCharacterData.Add(new UI_SelectCharacterData
                {
                    _Sprite = null,
                    _CharacterID = character.CharacterType
                });
            }

            TCharacterID characterID = (TCharacterID)PlayerPrefs.GetInt("SelectCharacter", 0);

            GameModule.UI.ShowUI<UI_SelectCharacter>(uiSelectCharacterData, characterID);
        }

        private void OnCloseSelectCharacterPanel()
        {
            GameModule.UI.CloseWindow<UI_SelectCharacter>();
        }

        private void OnSelectCharacter(TCharacterID characterID)
        {
            PlayerPrefsUtils.SetInt("SelectCharacter", (int)characterID);
            SurvivorRoot.Instance.GetModel<GameModel>().SelectCharacter.Value = characterID;
        }
        private void OnStartGame()
        {
            mFSM.ChangeState(SurvivorProcedureType.Launching);
            GameModule.UI.CloseWindow<UI_SurvivorMenu>();
            mTarget.StartGame();
        }
    }
}
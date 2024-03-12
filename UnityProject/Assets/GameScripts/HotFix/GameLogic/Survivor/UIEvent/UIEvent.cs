using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class UIEvent
    {
        public FSM<Enum_SurvivorProcedure> FSM => Game._SurvivorGameRoot._FSM;
        public void AddListen()
        {
            GameEvent.AddEventListener(UIEventID_Survivor.ReturnMenu, ReturnMenu);
            GameEvent.AddEventListener(EventID_Survivor.Survivor_StartGame, OnStartGame);

        }

        public void RemoveListen()
        {
            GameEvent.RemoveEventListener(UIEventID_Survivor.ReturnMenu, ReturnMenu);
            GameEvent.RemoveEventListener(EventID_Survivor.Survivor_StartGame, OnStartGame);
        }
        
        private void OnStartGame()
        {
            GameRoot._Instance.StartFlash(() =>
            {
                GameModule.UI.CloseWindow<UI_SurvivorMenu>();
                FSM.ChangeState(Enum_SurvivorProcedure.GameLaunching);
            });
        }
        
        private void ReturnMenu()
        {
            Time.timeScale = 1;
            GameRoot._Instance.StartFlash(() =>
                                          {
                                              GameModule.UI.CloseWindow<UI_Blood>();
                                              GameModule.UI.CloseWindow<UI_SurvivorStick>();
                                              GameModule.UI.CloseWindow<UI_Result>();
                                              GameModule.UI.ShowUI<UI_SurvivorMenu>();
                                              
                                              GameEvent.Send(EventID_Survivor.Survivor_Release);
                                          });
        }
    }
    

}
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class UIEvent
    {
        
        public void AddListen()
        {
            GameEvent.AddEventListener(UIEventID_Survivor.ReturnMenu, ReturnMenu);
        }

        public void RemoveListen()
        {
            GameEvent.RemoveEventListener(UIEventID_Survivor.ReturnMenu, ReturnMenu);
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
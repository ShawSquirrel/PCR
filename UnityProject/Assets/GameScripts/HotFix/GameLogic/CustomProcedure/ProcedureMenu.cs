using TEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace GameLogic
{
    public class ProcedureMenu : CustomProcedureBase
    {
        public ProcedureMenu(FSM<EProcedure> fsm, CustomProcedureModule target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            RegisterEvent();
            
        }

        protected override void OnExit()
        {
            base.OnExit();
            RemoveEvent();
        }

        /// <summary>
        /// 注册事件回调
        /// </summary>
        private void RegisterEvent()
        {
        }

        /// <summary>
        /// 移除事件回调
        /// </summary>
        private void RemoveEvent()
        {
        }


        private void StartGame()
        {
            GameModule.Scene.LoadScene("Level1");
            mFSM.ChangeState(EProcedure.ProcedureLevel);
        }
    }
}
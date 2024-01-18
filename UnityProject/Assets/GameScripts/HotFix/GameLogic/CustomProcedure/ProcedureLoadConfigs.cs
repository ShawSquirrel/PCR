using System.IO;
using TEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace GameLogic
{
    public class ProcedureLoadConfigs : CustomProcedureBase
    {
        public ProcedureLoadConfigs(FSM<EProcedure> fsm, CustomProcedureModule target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            ConfigSystem.Instance.Load();
            GameModule.Audio.Play(AudioType.Music, "主题音乐", true, 0.5f);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            mFSM.ChangeState(EProcedure.ProcedureMenu);
        }
    }
}
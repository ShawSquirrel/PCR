using TEngine;

namespace GameLogic.Sokoban
{
    public class SokobanLoadingProcedure : SokobanProcedureBase
    {
        public SokobanLoadingProcedure(FSM<Enum_SokobanProcedure> fsm, ProcedureSokoban target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            
            GameRoot._Instance.CloseVideoUI();
            
            SokobanLevelItem levelItem = mTarget._GameRoot._Level._CurLevel;
            
            _Root._Map.CreateMap(levelItem._Dict_Map);
            
            _Root._Player.LoadCharacter("优衣");
            
            _Root._Player.SetPos(_Root._Map._PlayerPos);
            
            _Root._Camera.SetFollowAndLookAt(_Root._Player.Character.transform);
            
            
            
            GameModule.Setting.SetInt(Setting.NextSokobanProcedure, (int)Enum_SokobanProcedure.GameLaunching);
            mFSM.ChangeState(Enum_SokobanProcedure.GameExitFlash);
        }
    }
}
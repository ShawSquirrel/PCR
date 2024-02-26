using TEngine;

namespace GameLogic
{
    public class ProcedureLoadGame : CustomProcedureBase
    {
        public ProcedureLoadGame(FSM<Enum_Procedure> fsm, CustomProcedureModule target) : base(fsm, target)
        {
            
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            GameRoot._Instance.AddManager<MapManager>();
            GameRoot._Instance.AddManager<CharacterManager>();


            UI_ActionBar bar = GameModule.UI.ShowUI<UI_ActionBar>().Window as UI_ActionBar;
            bar.AddActionBarItem(null, 5, 0);

        }
    }
}
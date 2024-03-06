using Cysharp.Threading.Tasks;
using DG.Tweening;
using TEngine;
using UnityEngine;

namespace GameLogic.Sokoban
{
    public class SokobanProcedureBase : AbstractState<Enum_SokobanProcedure, ProcedureSokoban>
    {
        public SokobanGameRoot _Root => SokobanGameRoot._Instance;

        public SokobanProcedureBase(FSM<Enum_SokobanProcedure> fsm, ProcedureSokoban target) : base(fsm, target)
        {
        }

        protected override void OnEnter()
        {
            RegisterEvent();
            Log.Info($"当前的状态 {mFSM.CurrentStateId}");
            base.OnEnter();
        }

        protected override void OnExit()
        {
            RemoveEvent();
            base.OnExit();
        }

        protected virtual void RegisterEvent()
        {
        }

        protected virtual void RemoveEvent()
        {
        }

        protected virtual void OnMenu()
        {
            mFSM.ChangeState(Enum_SokobanProcedure.GameMenu);
        }

        protected virtual void OnRestart()
        {
            mFSM.ChangeState(Enum_SokobanProcedure.GameLoading);
        }


        protected void OnNextLevel()
        {
            _Root._Level.NextLevel();
            mFSM.ChangeState(Enum_SokobanProcedure.GameLoading);
        }

        protected void OnSelectLevelEvent(string levelName)
        {
            if (_Root._Level.SetCurLoadLevel(levelName))
            {
                // GameModule.Setting.SetInt(Setting.NextSokobanProcedure, (int)Enum_SokobanProcedure.GameLoading);
                // mFSM.ChangeState(Enum_SokobanProcedure.GameEnterFlash);
                GameRoot._Instance.StartFlash(() => mFSM.ChangeState(Enum_SokobanProcedure.GameLoading));
            }
        }

        protected void OnMakeMap()
        {
            mFSM.ChangeState(Enum_SokobanProcedure.GameMakeMap);
        }


        #region Flash

        // protected override void OnUpdate()
        // {
        //     base.OnUpdate();
        //     Log.Info(_mat == null);
        // }

        private Material _mat;

        public async UniTask FlashStart()
        {
            _mat = GameModule.Resource.LoadAsset<Material>("Mat_UIFlash");
            GameModule.UI.ShowUI<UI_Flash>(_mat);

            bool isComplete = false;

            DOTween.To(() => -1f, value => _mat.SetFloat("_Add", value), 1f, 1f).OnComplete(() => isComplete = true).SetEase(Ease.Linear);

            while (!isComplete)
            {
                await UniTask.DelayFrame(1);
            }
        }

        public async UniTask FlashEnd()
        {
            _mat = GameModule.Resource.LoadAsset<Material>("Mat_UIFlash");
            bool isComplete = false;

            DOTween.To(() => 1f, value => _mat.SetFloat("_Add", value), -1f, 1f).OnComplete(() => isComplete = true).SetEase(Ease.Linear);

            while (!isComplete)
            {
                await UniTask.DelayFrame(1);
            }

            GameModule.UI.CloseWindow<UI_Flash>();
        }

        #endregion
    }
}
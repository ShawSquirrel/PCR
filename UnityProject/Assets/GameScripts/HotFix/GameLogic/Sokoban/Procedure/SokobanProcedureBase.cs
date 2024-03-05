using System.Threading.Tasks;
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
                mFSM.ChangeState(Enum_SokobanProcedure.GameLoading);
            }
        }
        
        protected void OnMakeMap()
        {
            mFSM.ChangeState(Enum_SokobanProcedure.GameMakeMap);
        }


        #region Flash

        private Material _mat;
        public async Task FlashStart()
        {
            _mat = GameModule.Resource.LoadAsset<Material>("Mat_UIFlash");
            GameModule.UI.ShowUI<UI_Flash>(new UI_FlashData() { _Material = _mat });

            bool isComplete = false;

            DOTween.To(() => -1, value => _mat.SetFloat("_Add", value), 1, 1f).OnComplete(() => isComplete = true).SetEase(Ease.Linear);

            while (!isComplete)
            {
                await UniTask.DelayFrame(1);
            }
        }
        public async Task FlashEnd()
        {
            bool isComplete = false;

            DOTween.To(() => 1, value => _mat.SetFloat("_Add", value), -1, 1f).OnComplete(() => isComplete = true).SetEase(Ease.Linear);

            while (!isComplete)
            {
                await UniTask.DelayFrame(1);
            }
        }

        #endregion

    }
}
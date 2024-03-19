using System.Collections;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class SwordSkill : Skill
    {
        public GameObject _Obj;
        public Transform _TF;
       

        public SwordSkill() : base()
        {
            _Obj = GameModule.Resource.LoadAsset<GameObject>("Sword");
            _TF = _Obj.transform;
            _TF.SetParent(Game._SurvivorGameRoot._Skill._TF);
            _Obj.AddComponent<SkillColliderEvent>();

            Start();
        }

        protected override void Update()
        {
            base.Update();
            if (_IsRunning)
            {
                Vector3 pos = Game._SurvivorGameRoot._Character.Pos;
                _TF.transform.position = pos;
            }
        }

        public void Start()
        {
            Run();
        }

        private async void Run()
        {
            while (true)
            {
                _Obj.SetActive(true);
                _IsRunning = true;
                bool isComplete = false;
                DOTween.To(() => Vector3.zero,
                    angle => _TF.localRotation = Quaternion.Euler(angle),
                    Vector3.forward * 180,
                    0.5f).OnComplete(() => { isComplete = true; });
                await UniTask.WaitUntil(() => isComplete);
                _Obj.SetActive(false);
                _IsRunning = false;
                await UniTask.Delay(3000);
            }
        }
    }
}
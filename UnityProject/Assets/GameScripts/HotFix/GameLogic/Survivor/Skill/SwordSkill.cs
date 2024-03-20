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
        private Vector3 _offset = new Vector3(0, 0.6f, 0);
       

        public SwordSkill() : base()
        {
            _Obj = GameModule.Resource.LoadAsset<GameObject>("Sword");
            _TF = _Obj.transform;
            _TF.SetParent(Game._SurvivorGameRoot._Skill._TF);
            _Obj.AddComponent<SkillColliderEvent>()._Atk = 50;

            Start();
        }

        protected override void Update()
        {
            base.Update();
            if (_IsRunning)
            {
                Vector3 pos = Game._SurvivorGameRoot._Character.Pos + _offset;
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
                Vector3 startAngle = Vector3.forward * (-180 + Game._SurvivorGameRoot._Skill.Angle);
                Vector3 endAngle = Vector3.forward * (Game._SurvivorGameRoot._Skill.Angle);
                DOTween.To(() => startAngle,
                    angle => _TF.localRotation = Quaternion.Euler(angle),
                    endAngle,
                    0.5f).OnComplete(() => { isComplete = true; });
                await UniTask.WaitUntil(() => isComplete);
                _Obj.SetActive(false);
                _IsRunning = false;
                await UniTask.Delay(3000);
            }
        }
    }
}
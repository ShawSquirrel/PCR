using System.Collections;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class SwordSkill : Skill
    {
        private Vector3 _offset = new Vector3(0, 0.6f, 0);
        public GameObject _Obj;
        public Transform _TF;
        

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

        private void Start()
        {
            Run();
        }

        public override async void Run()
        {
            while (_IsDestroy == false)
            {
                _Obj.SetActive(true);
                _IsRunning = true;
                bool isComplete = false;
                Vector3 startAngle = Vector3.forward * (-180 + Game._SurvivorGameRoot._Skill.Angle);
                Vector3 endAngle = Vector3.forward * (Game._SurvivorGameRoot._Skill.Angle);
                float elapsedTime = 0;
                while (elapsedTime < 0.5f)
                {
                    _TF.localRotation =  Quaternion.Euler(Vector3.Lerp(startAngle, endAngle, (elapsedTime / 0.5f)));
                    elapsedTime       += Time.deltaTime;
                    await UniTask.DelayFrame(1); // 等待一帧
                }

                _TF.localRotation = Quaternion.Euler(endAngle); // 确保旋转到目标角度
                _Obj.SetActive(false);
                _IsRunning = false;
                await UniTask.Delay(3000);
            }
        }
        
    }
}
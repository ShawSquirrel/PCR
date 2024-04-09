using Cysharp.Threading.Tasks;
using GameLogic.NewArchitecture.Core;
using TEngine;
using UnityEngine;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public class SwordSkill : ASKill
    {
        public override void Awake()
        {
            base.Awake();
            InitUnit("SwordSkill");
            _lastRunTime = _time;
        }

        protected override void InitUnit(string prefabName)
        {
            base.InitUnit(prefabName);
            GameObject obj = GameModule.Resource.LoadAsset<GameObject>(prefabName);
            _unit = new Unit(obj);
            _unit
               .SetParent(SurvivorRoot.Instance.GetModel<CharacterModel>()._Unit.Value)
               .Disable();
        }


        public override void Update()
        {
            base.Update();
            if (_time - _lastRunTime > 2f)
            {
                Run();
                _lastRunTime = _time;
            }
        }

        public override async void Run()
        {
            _unit.Enable();
            float angle = SurvivorRoot.Instance.GetModel<CharacterModel>()._SkillAngle.Value;
            Vector3 startAngle = Vector3.forward * (-60 + angle);
            Vector3 endAngle = Vector3.forward * (60 + angle);
            float elapsedTime = 0;
            while (elapsedTime < 0.5f)
            {
                Quaternion quaternion = Quaternion.Euler(Vector3.Lerp(startAngle, endAngle, elapsedTime / 0.5f));
                _unit.SetLocalRotation(quaternion);
                elapsedTime += Time.deltaTime;
                await UniTask.Yield();
            }

            _unit.SetLocalRotation(Quaternion.Euler(endAngle)); // 确保旋转到目标角度
            _unit.Disable();
        }
    }
}
using System.Collections;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using GameConfig;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class SwordSkill : Skill
    {
        private CharacterCtl _owner;
        private Vector3 _offset = new Vector3(0, 0.6f, 0);
        private SkillColliderEvent _skillColliderEvent;
        public GameObject _Obj;
        public Transform _TF;


        public SwordSkill() : base()
        {
            _skillType = SkillType.Sword;
            _owner = Game._SurvivorGameRoot._Character.CharacterCtl;
            _SkillAttribute = Game._SurvivorGameRoot._Skill.GetSkillBySkillType(SkillType.Sword);
            _Obj = GameModule.Resource.LoadAsset<GameObject>("Sword");
            _TF = _Obj.transform;
            _TF.SetParent(Game._SurvivorGameRoot._Skill._TF);
            _skillColliderEvent = _Obj.AddComponent<SkillColliderEvent>();
            Refresh();
            Start();
        }

        protected override void Refresh()
        {
            _BaseData = new SkillData
            {
                _Atk = _SkillAttribute._SkillData._Atk,
                _Angle = _SkillAttribute._SkillData._Angle,
                _CD = _SkillAttribute._SkillData._CD,
                _SkillDescribe = _SkillAttribute._SkillData._SkillDescribe,
                _Title = _SkillAttribute._SkillData._Title,
            };
            foreach (SkillUpgrade upgrade in _SkillAttribute._List_SkillUpgradeObtained)
            {
                _BaseData._Atk += upgrade._Atk;
                _BaseData._Angle += upgrade._Angle;
                _BaseData._CD += upgrade._CD;
            }

            _skillColliderEvent._Atk = _BaseData._Atk;
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
                float angle = Game._SurvivorGameRoot._Skill.Angle - 90;
                Vector3 startAngle = Vector3.forward * (-_BaseData._Angle / 2 + angle);
                Vector3 endAngle = Vector3.forward * (_BaseData._Angle / 2 + angle);
                float elapsedTime = 0;
                while (elapsedTime < 0.5f)
                {
                    _TF.localRotation = Quaternion.Euler(Vector3.Lerp(startAngle, endAngle, (elapsedTime / 0.5f)));
                    elapsedTime += Time.deltaTime;
                    await UniTask.Yield();
                }

                _TF.localRotation = Quaternion.Euler(endAngle); // 确保旋转到目标角度
                _Obj.SetActive(false);
                _IsRunning = false;
                await UniTask.WaitForSeconds(_BaseData._CD);
            }
        }

        public override void Release()
        {
            base.Release();
            Object.Destroy(_Obj);
        }
    }
}
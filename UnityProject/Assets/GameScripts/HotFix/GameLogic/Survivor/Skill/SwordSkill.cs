using Cysharp.Threading.Tasks;
using GameConfig;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class SwordSkill : Skill
    {
        private SurvivorGameRoot Root => Game._SurvivorGameRoot;
        private Vector3 _offset = new Vector3(0, 0.6f, 0);
        private ColliderEvent _colliderEvent;
        public GameObject _Obj;
        public Transform _TF;


        public SwordSkill() : base()
        {
            _skillType = TSkillType.Sword;
            _SkillAttribute = Game._SurvivorGameRoot._Skill.GetSkillBySkillType(TSkillType.Sword);
            _Obj = GameModule.Resource.LoadAsset<GameObject>("Sword");
            _TF = _Obj.transform;
            _TF.SetParent(Game._SurvivorGameRoot._Skill._TF);
            _colliderEvent = _Obj.AddComponent<ColliderEvent>();
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

            _colliderEvent._Atk = _BaseData._Atk;
        }

        protected override void Update()
        {
            base.Update();
            if (_IsRunning)
            {
                Transform characterTransform = Root.GetCharacterTransform();
                Vector3 pos = characterTransform == null ? Vector3.zero : characterTransform.position + _offset;
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
                float angle = Root.GetSKillTowards();
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
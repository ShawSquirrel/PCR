using System.Collections;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class SwordSkill
    {
        public GameObject _Obj;
        public Transform _TF;

        public SwordSkill()
        {
            _Obj = GameModule.Resource.LoadAsset<GameObject>("Sword");
            _TF = _Obj.transform;
            _TF.SetParent(Game._SurvivorGameRoot._Character.TFCharacter);


            Start();
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
                bool isComplete = false;
                DOTween.To(() => Vector3.zero,
                    angle => _TF.localRotation = Quaternion.Euler(angle),
                    Vector3.forward * 180,
                    0.5f).OnComplete(() => { isComplete = true; });
                await UniTask.WaitUntil(() => isComplete);
                // Log.Info("Run");
                _Obj.SetActive(false);
                await UniTask.Delay(3000);
                // Log.Info("Wait3");
            }
        }
    }
}
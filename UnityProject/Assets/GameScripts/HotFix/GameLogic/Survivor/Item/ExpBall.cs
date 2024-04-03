using GameBase;
using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class ExpBall : Item
    {
        public ExpBall(Vector3 pos)
        {
            _Obj = GameModule.Resource.LoadAsset<GameObject>("ExpBall1");
            _TF = _Obj.transform;
            _TF.transform.position = pos;
        }

        public override void Using()
        {
            Log.Info($"捡起了 {$"{_Obj.name}".SetColor(Color.green)}");
            GameEvent.Send(EventID_Survivor.Survivor_UsingItem, this);
            Release();
        }
    }
}
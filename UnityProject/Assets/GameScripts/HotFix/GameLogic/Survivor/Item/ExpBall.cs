using TEngine;
using UnityEngine;

namespace GameLogic.Survivor
{
    public class ExpBall : Item
    {
        public ExpBall()
        {
            _Obj = GameModule.Resource.LoadAsset<GameObject>("ExpBall1");
        }
    }
}
using GameLogic.NewArchitecture.Core;
using UnityEngine;

namespace GameLogic.NewArchitecture.Game
{
    public static class GameObjectHelper
    {
        public static IUnit GetUnit(this GameObject gameObject)
        {
            IUnit unit = null;
            Unit.S_GameObjectToUnitDict.TryGetValue(gameObject, out unit);
            return unit;

        }
    }
}
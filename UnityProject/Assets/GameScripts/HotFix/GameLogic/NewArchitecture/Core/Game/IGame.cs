using System;

namespace GameLogic.NewArchitecture.Core
{
    public interface IGame
    {
        void Awake();
        void Destroy();
        void ExecuteEmpty();
        T GetSystem<T>() where T : System, new();
        T AddSystem<T>(bool hasUnit) where T : System, new();
    }
}
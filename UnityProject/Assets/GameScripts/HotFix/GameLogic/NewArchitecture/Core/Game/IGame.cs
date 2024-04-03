using System;

namespace GameLogic.NewArchitecture.Core
{
    public interface IGame
    {
        void Init();
        T GetSystem<T>() where T : System, new();
        T AddSystem<T>(bool hasUnit) where T : System, new();
    }
}
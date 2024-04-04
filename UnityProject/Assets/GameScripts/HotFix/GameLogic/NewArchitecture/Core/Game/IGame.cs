using System;

namespace GameLogic.NewArchitecture.Core
{
    public interface IGame
    {
        void Init();
        void Release();
        void ExecuteEmpty();
        T GetSystem<T>() where T : System, new();
        T AddSystem<T>(bool hasUnit) where T : System, new();
        void RemoveSystem<T>() where T : System, new();
        void RemoveAllSystem();
        T GetModel<T>() where T : Model, new();
        T AddModel<T>() where T : Model, new();

    }
}
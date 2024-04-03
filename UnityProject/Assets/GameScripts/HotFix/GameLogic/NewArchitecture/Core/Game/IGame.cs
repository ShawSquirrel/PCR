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
        T GetModel<T>() where T : Model, new();
        T AddModel<T>() where T : Model, new();

    }
}
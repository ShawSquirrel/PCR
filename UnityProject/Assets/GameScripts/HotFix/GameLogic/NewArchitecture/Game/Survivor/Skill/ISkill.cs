using GameLogic.NewArchitecture.Core;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public interface ISkill : IInit
    {
        void Run();
        void Awake();
        void Destroy();
        void Update();
        void FixedUpdate();
    }
}
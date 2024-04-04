
namespace GameLogic.NewArchitecture.Core
{
    public interface ISystem : IInit
    {
        void Awake();
        void Destroy();
    }
}

namespace GameLogic.NewArchitecture.Core
{
    public interface ISystem : IInit
    {
        void Create();
        void Destroy();
    }
}
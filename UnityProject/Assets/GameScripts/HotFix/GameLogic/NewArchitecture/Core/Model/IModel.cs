namespace GameLogic.NewArchitecture.Core
{
    public interface IModel : IInit
    {
        void Awake();
        void Destroy();
    }
}
using NotImplementedException = System.NotImplementedException;

namespace GameLogic.NewArchitecture.Core
{
    public abstract class Model : IModel
    {
        public virtual void Awake()
        {
        }
        public virtual void Destroy()
        {
        }
         
    }
}
using GameLogic.NewArchitecture.Core;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public interface IEnemy : IEntity, IInit, IAwake
    {
        void Move();
        void Atk();
        void Damage(float damage);
        void Die();
    }
}
using GameLogic.NewArchitecture.Core;

namespace GameLogic.NewArchitecture.Game.Survivor
{
    public interface IEnemy : IInit, IAwake
    {
        void Move();
        void Atk();
        void Damage(float damage);
        IUnit GetUnit();

        void Die();
    }
}
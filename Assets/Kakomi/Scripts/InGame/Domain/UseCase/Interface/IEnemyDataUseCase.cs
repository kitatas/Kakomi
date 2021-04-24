using Kakomi.InGame.Data.Entity.Interface;
using UniRx;

namespace Kakomi.InGame.Domain.UseCase.Interface
{
    public interface IEnemyDataUseCase
    {
        ICharacterEntity enemyEntity { get; }
        IReadOnlyReactiveProperty<int> EnemyHpModel();
        void RecoverEnemy(int recoverValue);
        void DamageEnemy(int damageValue);
        bool IsAliveEnemy();
    }
}
using UniRx;

namespace Kakomi.InGame.Domain.UseCase.Interface
{
    public interface IEnemyHpUseCase
    {
        void Initialize(int maxHpValue);
        IReadOnlyReactiveProperty<int> HpModel();
        void Damage(int damageValue);
    }
}
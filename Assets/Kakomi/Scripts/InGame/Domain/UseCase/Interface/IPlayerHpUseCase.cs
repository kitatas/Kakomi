using UniRx;

namespace Kakomi.InGame.Domain.UseCase.Interface
{
    public interface IPlayerHpUseCase
    {
        void Initialize(int maxHpValue);
        IReadOnlyReactiveProperty<int> HpModel();
        void Recover(int recoverValue);
        void Damage(int damageValue);
        bool IsAlive();
    }
}
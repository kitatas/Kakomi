using UniRx;

namespace Kakomi.InGame.Domain.UseCase.Interface
{
    public interface IHpUseCase
    {
        IReadOnlyReactiveProperty<int> HpModel();
        void Recover(int recoverValue);
        void Damage(int damageValue);
        bool IsAlive();
    }
}
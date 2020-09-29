using UniRx;

namespace Kakomi.InGame.Domain.UseCase.Interface
{
    public interface IPlayerHpUseCase
    {
        IReadOnlyReactiveProperty<int> HpModel();
        void Recover(int recoverValue);
        void Damage(int damageValue);
    }
}
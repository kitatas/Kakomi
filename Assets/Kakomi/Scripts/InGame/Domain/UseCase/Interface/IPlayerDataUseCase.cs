using Kakomi.InGame.Data.Entity.Interface;
using UniRx;

namespace Kakomi.InGame.Domain.UseCase.Interface
{
    public interface IPlayerDataUseCase
    {
        ICharacterEntity playerEntity { get; }
        IReadOnlyReactiveProperty<int> PlayerHpModel();
        void RecoverPlayer(int recoverValue);
        void DamagePlayer(int damageValue);
        bool IsAlivePlayer();
    }
}
using Kakomi.InGame.Application;
using Kakomi.InGame.Domain.Model.Interface;
using Kakomi.InGame.Domain.UseCase.Interface;
using UniRx;

namespace Kakomi.InGame.Domain.UseCase
{
    public sealed class PlayerHpUseCase : IPlayerHpUseCase
    {
        private readonly IPlayerHpModel _playerHpModel;

        public PlayerHpUseCase(IPlayerHpModel playerHpModel)
        {
            _playerHpModel = playerHpModel.Initialize(PlayerStatus.MAX_HP);
        }

        public IReadOnlyReactiveProperty<int> HpModel() => _playerHpModel.HpModel;

        public void Recover(int recoverValue)
        {
            _playerHpModel.UpdatePlayerHp(recoverValue);
        }

        public void Damage(int damageValue)
        {
            _playerHpModel.UpdatePlayerHp(-damageValue);
        }
    }
}
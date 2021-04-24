using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.InGame.Presentation.View;
using UniRx;

namespace Kakomi.InGame.Presentation.Presenter
{
    public sealed class PlayerHpPresenter
    {
        public PlayerHpPresenter(IPlayerDataUseCase playerDataUseCase, PlayerHpView playerHpView)
        {
            playerHpView.Initialize(playerDataUseCase.playerEntity.GetHp());

            playerDataUseCase.PlayerHpModel()
                .Subscribe(playerHpView.UpdateHpSlider)
                .AddTo(playerHpView);
        }
    }
}
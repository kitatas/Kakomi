using Kakomi.InGame.Application;
using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.InGame.Presentation.View;
using UniRx;

namespace Kakomi.InGame.Presentation.Presenter
{
    public sealed class PlayerHpPresenter
    {
        public PlayerHpPresenter(IPlayerHpUseCase playerHpUseCase, PlayerHpView playerHpView)
        {
            playerHpView.Initialize(PlayerStatus.MAX_HP);
            playerHpUseCase.HpModel()
                .Subscribe(playerHpView.UpdateHpSlider)
                .AddTo(playerHpView);
        }
    }
}
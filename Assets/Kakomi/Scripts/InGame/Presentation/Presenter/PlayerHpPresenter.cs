using Kakomi.InGame.Application;
using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.InGame.Presentation.View;
using UniRx;
using Zenject;

namespace Kakomi.InGame.Presentation.Presenter
{
    public sealed class PlayerHpPresenter
    {
        public PlayerHpPresenter([Inject(Id = IdType.Player)] IHpUseCase hpUseCase, PlayerHpView playerHpView)
        {
            playerHpView.Initialize(PlayerStatus.MAX_HP);

            hpUseCase.HpModel()
                .Subscribe(playerHpView.UpdateHpSlider)
                .AddTo(playerHpView);
        }
    }
}
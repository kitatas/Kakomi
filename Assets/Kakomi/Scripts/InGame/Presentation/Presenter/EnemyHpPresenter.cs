using Kakomi.InGame.Application;
using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.InGame.Presentation.View;
using UniRx;
using Zenject;

namespace Kakomi.InGame.Presentation.Presenter
{
    public sealed class EnemyHpPresenter
    {
        public EnemyHpPresenter([Inject(Id = IdType.Enemy)] IHpUseCase hpUseCase, EnemyHpView enemyHpView)
        {
            enemyHpView.Initialize(EnemyStatus.MAX_HP);

            hpUseCase.HpModel()
                .Subscribe(enemyHpView.UpdateHpSlider)
                .AddTo(enemyHpView);
        }
    }
}
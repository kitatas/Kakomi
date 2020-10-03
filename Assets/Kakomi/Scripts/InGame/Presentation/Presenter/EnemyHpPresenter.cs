using Kakomi.InGame.Application;
using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.InGame.Presentation.View;
using UniRx;

namespace Kakomi.InGame.Presentation.Presenter
{
    public sealed class EnemyHpPresenter
    {
        public EnemyHpPresenter(IEnemyHpUseCase enemyHpUseCase, EnemyHpView enemyHpView)
        {
            enemyHpUseCase.Initialize(EnemyStatus.MAX_HP);
            enemyHpView.Initialize(EnemyStatus.MAX_HP);

            enemyHpUseCase.HpModel()
                .Subscribe(enemyHpView.UpdateHpSlider)
                .AddTo(enemyHpView);
        }
    }
}
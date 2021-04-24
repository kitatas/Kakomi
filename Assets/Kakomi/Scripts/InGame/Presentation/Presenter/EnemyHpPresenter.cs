using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.InGame.Presentation.View;
using UniRx;

namespace Kakomi.InGame.Presentation.Presenter
{
    public sealed class EnemyHpPresenter
    {
        public EnemyHpPresenter(IEnemyDataUseCase enemyDataUseCase, EnemyHpView enemyHpView)
        {
            enemyHpView.Initialize(enemyDataUseCase.enemyEntity.GetHp());

            enemyDataUseCase.EnemyHpModel()
                .Subscribe(enemyHpView.UpdateHpSlider)
                .AddTo(enemyHpView);
        }
    }
}
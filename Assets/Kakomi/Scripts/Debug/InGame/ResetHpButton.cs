using Kakomi.InGame.Domain.UseCase.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine.EventSystems;
using Zenject;

namespace Kakomi.Debug.InGame
{
    public sealed class ResetHpButton : UIBehaviour
    {
        private IPlayerDataUseCase _playerDataUseCase;
        private IEnemyDataUseCase _enemyDataUseCase;

        [Inject]
        private void Construct(IPlayerDataUseCase playerDataUseCase, IEnemyDataUseCase enemyDataUseCase)
        {
            _playerDataUseCase = playerDataUseCase;
            _enemyDataUseCase = enemyDataUseCase;
        }

        protected override void Start()
        {
            this.OnPointerDownAsObservable()
                .Subscribe(_ =>
                {
                    _playerDataUseCase.RecoverPlayer(1000);
                    _enemyDataUseCase.RecoverEnemy(1000);
                })
                .AddTo(this);
        }
    }
}
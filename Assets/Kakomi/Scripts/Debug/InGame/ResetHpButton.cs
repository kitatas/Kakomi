using Kakomi.InGame.Application;
using Kakomi.InGame.Domain.UseCase.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine.EventSystems;
using Zenject;

namespace Kakomi.Debug.InGame
{
    public sealed class ResetHpButton : UIBehaviour
    {
        private IPlayerHpUseCase _playerHpUseCase;
        private IEnemyHpUseCase _enemyHpUseCase;

        [Inject]
        private void Construct(IPlayerHpUseCase playerHpUseCase, IEnemyHpUseCase enemyHpUseCase)
        {
            _playerHpUseCase = playerHpUseCase;
            _enemyHpUseCase = enemyHpUseCase;
        }

        protected override void Start()
        {
            this.OnPointerDownAsObservable()
                .Subscribe(_ =>
                {
                    _playerHpUseCase.Recover(PlayerStatus.MAX_HP);
                    _enemyHpUseCase.Recover(EnemyStatus.MAX_HP);
                })
                .AddTo(this);
        }
    }
}
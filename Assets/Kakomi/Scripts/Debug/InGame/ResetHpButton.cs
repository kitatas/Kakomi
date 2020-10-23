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
        private IHpUseCase _playerHpUseCase;
        private IHpUseCase _enemyHpUseCase;

        [Inject]
        private void Construct(
            [Inject(Id = IdType.Player)] IHpUseCase playerHpUseCase,
            [Inject(Id = IdType.Enemy)] IHpUseCase enemyHpUseCase)
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
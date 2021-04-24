using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kakomi.InGame.Application;
using Kakomi.InGame.Domain.UseCase.Interface;
using Zenject;

namespace Kakomi.InGame.Presentation.View.State
{
    public sealed class AttackView : BaseState
    {
        private IEnclosureObjectUseCase _enclosureObjectUseCase;
        private IHpUseCase _playerHpUseCase;
        private IHpUseCase _enemyHpUseCase;
        private StockPositionCommander _stockPositionCommander;

        [Inject]
        private void Construct(IEnclosureObjectUseCase enclosureObjectUseCase,
            [Inject(Id = IdType.Player)] IHpUseCase playerHpUseCase,
            [Inject(Id = IdType.Enemy)] IHpUseCase enemyHpUseCase,
            StockPositionCommander stockPositionCommander)
        {
            _enclosureObjectUseCase = enclosureObjectUseCase;
            _playerHpUseCase = playerHpUseCase;
            _enemyHpUseCase = enemyHpUseCase;
            _stockPositionCommander = stockPositionCommander;
        }

        public override GameState GetState() => GameState.Attack;

        public override UniTask InitAsync(CancellationToken token)
        {
            _stockPositionCommander.ResetStockPosition();
            return base.InitAsync(token);
        }

        public override UniTask ResetAsync(GameState state, CancellationToken token)
        {
            return base.ResetAsync(state, token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);

            await _enclosureObjectUseCase.AttackAsync(token, data =>
            {
                switch (data.enclosureObjectType)
                {
                    case EnclosureObjectType.Bullet:
                        _enemyHpUseCase.Damage(data.effectValue);
                        break;
                    case EnclosureObjectType.Bomb:
                        _playerHpUseCase.Damage(data.effectValue);
                        break;
                    case EnclosureObjectType.Heart:
                        _playerHpUseCase.Recover(data.effectValue);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });
            _stockPositionCommander.ResetStockPosition();

            await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);

            if (_playerHpUseCase.IsAlive() == false)
            {
                return GameState.Failed;
            }
            else if (_enemyHpUseCase.IsAlive())
            {
                return GameState.Damage;
            }
            else
            {
                return GameState.Clear;
            }
        }

        public override UniTask DisposeAsync(CancellationToken token)
        {
            return base.DisposeAsync(token);
        }
    }
}
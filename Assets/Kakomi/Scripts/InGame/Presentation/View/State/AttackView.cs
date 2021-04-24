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
        private IPlayerDataUseCase _playerDataUseCase;
        private IEnemyDataUseCase _enemyDataUseCase;
        private IEnclosureObjectUseCase _enclosureObjectUseCase;
        private StockPositionCommander _stockPositionCommander;

        [Inject]
        private void Construct(IPlayerDataUseCase playerDataUseCase, IEnemyDataUseCase enemyDataUseCase,
            IEnclosureObjectUseCase enclosureObjectUseCase, StockPositionCommander stockPositionCommander)
        {
            _playerDataUseCase = playerDataUseCase;
            _enemyDataUseCase = enemyDataUseCase;
            _enclosureObjectUseCase = enclosureObjectUseCase;
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
                // TODO: PlayerのStatusを反映させる
                switch (data.enclosureObjectType)
                {
                    case EnclosureObjectType.Bullet:
                        _enemyDataUseCase.DamageEnemy(data.effectValue);
                        break;
                    case EnclosureObjectType.Bomb:
                        _playerDataUseCase.DamagePlayer(data.effectValue);
                        break;
                    case EnclosureObjectType.Heart:
                        _playerDataUseCase.RecoverPlayer(data.effectValue);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            });
            _stockPositionCommander.ResetStockPosition();

            await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);

            if (_playerDataUseCase.IsAlivePlayer() == false)
            {
                return GameState.Failed;
            }
            else if (_enemyDataUseCase.IsAliveEnemy())
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
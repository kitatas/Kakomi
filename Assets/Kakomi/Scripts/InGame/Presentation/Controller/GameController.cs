using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kakomi.InGame.Application;
using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.InGame.Presentation.View;
using UniRx;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.Controller
{
    public sealed class GameController : MonoBehaviour
    {
        [SerializeField] private bool isMoveObject = default;
        public bool IsMoveObject => isMoveObject;

        private CancellationToken _token;

        private IGameStateUseCase _gameStateUseCase;
        private ICursorPointsUseCase _cursorPointsUseCase;
        private IPlayerHpUseCase _playerHpUseCase;
        private IEnemyHpUseCase _enemyHpUseCase;
        private TurnCountView _turnCountView;
        private FinishView _finishView;

        [Inject]
        private void Construct(IGameStateUseCase gameStateUseCase, ICursorPointsUseCase cursorPointsUseCase,
            IPlayerHpUseCase playerHpUseCase, IEnemyHpUseCase enemyHpUseCase,
            TurnCountView turnCountView, FinishView finishView)
        {
            _token = this.GetCancellationTokenOnDestroy();
            _gameStateUseCase = gameStateUseCase;
            _cursorPointsUseCase = cursorPointsUseCase;
            _playerHpUseCase = playerHpUseCase;
            _enemyHpUseCase = enemyHpUseCase;
            _turnCountView = turnCountView;
            _finishView = finishView;

            _finishView.Initialize();
        }

        private void Start()
        {
            isMoveObject = false;

            _gameStateUseCase.GameState()
                .Subscribe(state =>
                {
                    try
                    {
                        DoStateAction(state);
                    }
                    catch (Exception)
                    {
                        UnityEngine.Debug.LogError("game state error.");
                        throw;
                    }
                })
                .AddTo(this);
        }

        private void DoStateAction(GameState state)
        {
            switch (state)
            {
                case GameState.Ready:
                    DoReadyAsync().Forget();
                    break;
                case GameState.Draw:
                    DoDrawAsync().Forget();
                    break;
                case GameState.Attack:
                    DoAttackAsync().Forget();
                    break;
                case GameState.Damage:
                    DoDamageAsync().Forget();
                    break;
                case GameState.Clear:
                case GameState.Failed:
                    _finishView.SetFinish(state);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        private async UniTaskVoid DoReadyAsync()
        {
            await _turnCountView.TweenTurnTextAsync(_token);

            isMoveObject = true;
            _gameStateUseCase.SetGameState(GameState.Draw);
        }

        private async UniTaskVoid DoDrawAsync()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(10f), cancellationToken: _token);

            isMoveObject = false;
            _cursorPointsUseCase.ClearLine();
            _gameStateUseCase.SetGameState(GameState.Attack);
        }

        private async UniTaskVoid DoAttackAsync()
        {
            // TODO : 囲み攻撃処理
            await UniTask.DelayFrame(1, cancellationToken: _token);

            if (_playerHpUseCase.IsAlive() == false)
            {
                _gameStateUseCase.SetGameState(GameState.Failed);
            }
            else if (_enemyHpUseCase.IsAlive())
            {
                _gameStateUseCase.SetGameState(GameState.Damage);
            }
            else
            {
                _gameStateUseCase.SetGameState(GameState.Clear);
            }
        }

        private async UniTaskVoid DoDamageAsync()
        {
            // TODO : 敵の攻撃処理
            await UniTask.DelayFrame(1, cancellationToken: _token);

            if (_playerHpUseCase.IsAlive())
            {
                _gameStateUseCase.SetGameState(GameState.Ready);
            }
            else
            {
                _gameStateUseCase.SetGameState(GameState.Failed);
            }
        }
    }
}
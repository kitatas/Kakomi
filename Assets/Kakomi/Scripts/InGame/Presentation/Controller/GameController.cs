using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kakomi.InGame.Application;
using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.InGame.Factory;
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
        private IEnclosureObjectUseCase _enclosureObjectUseCase;
        private IHpUseCase _playerHpUseCase;
        private IHpUseCase _enemyHpUseCase;
        private StockFactory _stockFactory;
        private TurnCountView _turnCountView;
        private FinishView _finishView;

        [Inject]
        private void Construct(IGameStateUseCase gameStateUseCase, ICursorPointsUseCase cursorPointsUseCase,
            IEnclosureObjectUseCase enclosureObjectUseCase,
            [Inject(Id = IdType.Player)] IHpUseCase playerHpUseCase,
            [Inject(Id = IdType.Enemy)] IHpUseCase enemyHpUseCase,
            StockFactory stockFactory, TurnCountView turnCountView, FinishView finishView)
        {
            _token = this.GetCancellationTokenOnDestroy();
            _gameStateUseCase = gameStateUseCase;
            _cursorPointsUseCase = cursorPointsUseCase;
            _enclosureObjectUseCase = enclosureObjectUseCase;
            _playerHpUseCase = playerHpUseCase;
            _enemyHpUseCase = enemyHpUseCase;
            _stockFactory = stockFactory;
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
            await _enclosureObjectUseCase.Attack(_token, data =>
            {
                _stockFactory.Burst(data.enclosureObjectType);
                switch (data.enclosureObjectType)
                {
                    case EnclosureObjectType.None:
                        break;
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
            _enclosureObjectUseCase.ResetStockData();
            _stockFactory.ClearStockData();

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
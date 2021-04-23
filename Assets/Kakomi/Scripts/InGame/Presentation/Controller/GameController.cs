using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kakomi.Common.Application;
using Kakomi.InGame.Application;
using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.InGame.Presentation.View;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.Controller
{
    public sealed class GameController : MonoBehaviour
    {
        [SerializeField] private GameStateView gameStateView = default;
        [SerializeField] private StockPositionCommander stockPositionCommander = default;

        private bool _isMoveObject;
        public bool IsMoveObject => _isMoveObject;

        private CancellationToken _token;

        private int _level;
        private IGameStateUseCase _gameStateUseCase;
        private ICursorPointsUseCase _cursorPointsUseCase;
        private IEnclosureObjectUseCase _enclosureObjectUseCase;
        private IEnclosureFactoryUseCase _enclosureFactoryUseCase;
        private IHpUseCase _playerHpUseCase;
        private IHpUseCase _enemyHpUseCase;

        [Inject]
        private void Construct(int level, IGameStateUseCase gameStateUseCase, ICursorPointsUseCase cursorPointsUseCase,
            IEnclosureObjectUseCase enclosureObjectUseCase, IEnclosureFactoryUseCase enclosureFactoryUseCase,
            [Inject(Id = IdType.Player)] IHpUseCase playerHpUseCase,
            [Inject(Id = IdType.Enemy)] IHpUseCase enemyHpUseCase)
        {
            _token = this.GetCancellationTokenOnDestroy();
            _level = level;
            _gameStateUseCase = gameStateUseCase;
            _cursorPointsUseCase = cursorPointsUseCase;
            _enclosureObjectUseCase = enclosureObjectUseCase;
            _enclosureFactoryUseCase = enclosureFactoryUseCase;
            _playerHpUseCase = playerHpUseCase;
            _enemyHpUseCase = enemyHpUseCase;

            gameStateView.Initialize();
            stockPositionCommander.ResetStockPosition();
        }

        private void Start()
        {
            _isMoveObject = false;

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
            
            this.UpdateAsObservable()
                .ThrottleFirst(TimeSpan.FromSeconds(FieldParameter.INTERVAL * 4))
                .Where(_ => IsMoveObject)
                .Subscribe(_ =>
                {
                    // TODO : 仮のタイミング
                    _enclosureFactoryUseCase.Activate();
                })
                .AddTo(this);
        }

        private void DoStateAction(GameState state)
        {
            switch (state)
            {
                case GameState.Ready:
                    DoReadyAsync(_token).Forget();
                    break;
                case GameState.Draw:
                    DoDrawAsync(_token).Forget();
                    break;
                case GameState.Attack:
                    DoAttackAsync(_token).Forget();
                    break;
                case GameState.Damage:
                    DoDamageAsync(_token).Forget();
                    break;
                case GameState.Clear:
                    ES3.Save(SaveKey.STAGE + _level, true);
                    gameStateView.SetFinish(state);
                    break;
                case GameState.Failed:
                    gameStateView.SetFinish(state);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        private async UniTaskVoid DoReadyAsync(CancellationToken token)
        {
            await gameStateView.TweenTurnTextAsync(token);

            _isMoveObject = true;
            _gameStateUseCase.SetGameState(GameState.Draw);
        }

        private async UniTaskVoid DoDrawAsync(CancellationToken token)
        {
            await gameStateView.CountAsync(token);

            _isMoveObject = false;
            _cursorPointsUseCase.ClearLine();
            _gameStateUseCase.SetGameState(GameState.Attack);
        }

        private async UniTaskVoid DoAttackAsync(CancellationToken token)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);

            await _enclosureObjectUseCase.AttackAsync(token, data =>
            {
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
            stockPositionCommander.ResetStockPosition();

            await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);

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

        private async UniTaskVoid DoDamageAsync(CancellationToken token)
        {
            await gameStateView.AttackPlayerAsync(token, () => _playerHpUseCase.Damage(EnemyStatus.ATTACK));

            await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);

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
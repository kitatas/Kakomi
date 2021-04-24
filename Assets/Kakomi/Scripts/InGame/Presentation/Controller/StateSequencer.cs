using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kakomi.InGame.Application;
using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.InGame.Presentation.View.State;
using UniRx;

namespace Kakomi.InGame.Presentation.Controller
{
    public sealed class StateSequencer
    {
        private readonly List<BaseState> _states;
        private readonly CompositeDisposable _disposable;
        private readonly CancellationTokenSource _tokenSource;

        private readonly IGameStateUseCase _gameStateUseCase;

        public StateSequencer(IGameStateUseCase gameStateUseCase, IEnclosureFactoryUseCase enclosureFactoryUseCase,
            ReadyView readyView, DrawView drawView, AttackView attackView, DamageView damageView, ClearView clearView,
            FailView failView)
        {
            _states = new List<BaseState>
            {
                readyView,
                drawView,
                attackView,
                damageView,
                clearView,
                failView,
            };

            _disposable = new CompositeDisposable();
            _tokenSource = new CancellationTokenSource();

            foreach (var state in _states)
            {
                state.InitAsync(_tokenSource.Token).Forget();
            }

            _gameStateUseCase = gameStateUseCase;
            _gameStateUseCase.GameState()
                .Subscribe(gameState =>
                {
                    Reset(gameState);
                    TickAsync(gameState, _tokenSource.Token).Forget();
                })
                .AddTo(_disposable);
        }

        ~StateSequencer()
        {
            _disposable?.Dispose();
            _tokenSource?.Cancel();
            _tokenSource?.Dispose();
        }

        private void Reset(GameState gameState)
        {
            foreach (var state in _states)
            {
                state.ResetAsync(gameState, _tokenSource.Token).Forget();
            }
        }

        private async UniTask TickAsync(GameState gameState, CancellationToken token)
        {
            if (gameState == GameState.None)
            {
                return;
            }

            var currentState = _states.Find(x => x.GetState() == gameState);
            var nextState = await currentState.TickAsync(token);
            _gameStateUseCase.SetGameState(nextState);
        }
    }
}
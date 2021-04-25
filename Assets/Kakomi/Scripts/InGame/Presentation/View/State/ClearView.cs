using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kakomi.InGame.Application;
using Kakomi.InGame.Domain.UseCase.Interface;
using Zenject;

namespace Kakomi.InGame.Presentation.View.State
{
    public sealed class ClearView : BaseState
    {
        private IStageDataUseCase _stageDataUseCase;
        private GameFinishView _gameFinishView;

        [Inject]
        private void Construct(IStageDataUseCase stageDataUseCase, GameFinishView gameFinishView)
        {
            _stageDataUseCase = stageDataUseCase;
            _gameFinishView = gameFinishView;
            _gameFinishView.Init();
        }

        public override GameState GetState() => GameState.Clear;

        public override UniTask InitAsync(CancellationToken token)
        {
            return base.InitAsync(token);
        }

        public override UniTask ResetAsync(GameState state, CancellationToken token)
        {
            return base.ResetAsync(state, token);
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            _stageDataUseCase.Save();
            _gameFinishView.SetFinishText("Clear");

            await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);

            _gameFinishView.ActivateSceneLoad(true);

            return GameState.None;
        }

        public override UniTask DisposeAsync(CancellationToken token)
        {
            return base.DisposeAsync(token);
        }
    }
}
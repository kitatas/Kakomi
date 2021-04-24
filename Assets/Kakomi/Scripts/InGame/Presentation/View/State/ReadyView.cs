using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Kakomi.InGame.Application;
using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.Utility;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Kakomi.InGame.Presentation.View.State
{
    public sealed class ReadyView : BaseState
    {
        [SerializeField] private Image turnCountBackground = default;

        private ITurnCountUseCase _turnCountUseCase;
        private TurnCountView _turnCountView;

        [Inject]
        private void Construct(ITurnCountUseCase turnCountUseCase, TurnCountView turnCountView)
        {
            _turnCountUseCase = turnCountUseCase;
            _turnCountView = turnCountView;
        }

        public override GameState GetState() => GameState.Ready;

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
            _turnCountUseCase.CountUpTurn(1);

            Activate(true);

            await DOTween.Sequence()
                .Append(turnCountBackground
                    .DOFade(1.0f, 0.1f)
                    .SetEase(Ease.Linear))
                .Join(turnCountBackground.rectTransform
                    .DOScaleY(1.0f, 0.5f)
                    .SetEase(Ease.Linear))
                .WithCancellation(token);

            await _turnCountView.TweenAsync(token);

            ResetView();

            return GameState.Draw;
        }

        public override UniTask DisposeAsync(CancellationToken token)
        {
            return base.DisposeAsync(token);
        }

        private void Activate(bool value)
        {
            turnCountBackground.enabled = value;
        }

        private void ResetView()
        {
            Activate(false);
            turnCountBackground.color = turnCountBackground.color.SetAlpha(0.1f);
            turnCountBackground.rectTransform.localPosition = new Vector3(1.0f, 0.1f, 1.0f);
        }
    }
}
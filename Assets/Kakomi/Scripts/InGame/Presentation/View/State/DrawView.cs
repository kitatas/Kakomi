using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Kakomi.InGame.Application;
using Kakomi.InGame.Domain.UseCase.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Kakomi.InGame.Presentation.View.State
{
    public sealed class DrawView : BaseState
    {
        [SerializeField] private Image image = default;

        private ICursorPointsUseCase _cursorPointsUseCase;

        [Inject]
        private void Construct(ICursorPointsUseCase cursorPointsUseCase)
        {
            _cursorPointsUseCase = cursorPointsUseCase;
        }

        public override GameState GetState() => GameState.Draw;

        public override UniTask InitAsync(CancellationToken token)
        {
            return base.InitAsync(token);
        }

        public override async UniTask ResetAsync(GameState state, CancellationToken token)
        {
            switch (state)
            {
                case GameState.None:
                    break;
                case GameState.Ready:
                    await DOTween.To(
                            () => image.fillAmount,
                            count => image.fillAmount = count,
                            1.0f,
                            0.5f)
                        .WithCancellation(token);
                    break;
                case GameState.Draw:
                    break;
                case GameState.Attack:
                    break;
                case GameState.Damage:
                    break;
                case GameState.Clear:
                    break;
                case GameState.Failed:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }

        public override async UniTask<GameState> TickAsync(CancellationToken token)
        {
            await DOTween.To(
                    () => image.fillAmount,
                    count => image.fillAmount = count,
                    0.0f,
                    DrawParameter.DRAW_TIME)
                .WithCancellation(token);

            _cursorPointsUseCase.ClearLine();

            return GameState.Attack;
        }

        public override UniTask DisposeAsync(CancellationToken token)
        {
            return base.DisposeAsync(token);
        }
    }
}
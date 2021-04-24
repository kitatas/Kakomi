using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Kakomi.InGame.Application;
using Kakomi.InGame.Domain.UseCase.Interface;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Kakomi.InGame.Presentation.View.State
{
    public sealed class DamageView : BaseState
    {
        [SerializeField] private Image enemyImage = default;

        private readonly float _animationTime = 0.5f;

        private IHpUseCase _playerHpUseCase;

        [Inject]
        private void Construct([Inject(Id = IdType.Player)] IHpUseCase playerHpUseCase)
        {
            _playerHpUseCase = playerHpUseCase;
        }

        public override GameState GetState() => GameState.Damage;

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
            await DOTween.Sequence()
                .Append(enemyImage.rectTransform
                    .DOAnchorPosY(-900f, _animationTime)
                    .SetEase(Ease.Linear))
                .Join(enemyImage.rectTransform
                    .DOScale(Vector3.one * 1.25f, _animationTime)
                    .SetEase(Ease.OutBack))
                .WithCancellation(token);

            _playerHpUseCase.Damage(EnemyStatus.ATTACK);

            await DOTween.Sequence()
                .Append(enemyImage.rectTransform
                    .DOAnchorPosY(-25f, _animationTime)
                    .SetEase(Ease.Linear))
                .Join(enemyImage.rectTransform
                    .DOScale(Vector3.one, _animationTime))
                .WithCancellation(token);

            await UniTask.Delay(TimeSpan.FromSeconds(1f), cancellationToken: token);

            if (_playerHpUseCase.IsAlive())
            {
                return GameState.Ready;
            }
            else
            {
                return GameState.Failed;
            }
        }

        public override UniTask DisposeAsync(CancellationToken token)
        {
            return base.DisposeAsync(token);
        }
    }
}
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class EnemyView : MonoBehaviour
    {
        [SerializeField] private Image enemyImage = default;

        private readonly float _animationTime = 0.5f;

        public async UniTask AttackPlayer(CancellationToken token, Action action)
        {
            await DOTween.Sequence()
                .Append(enemyImage.rectTransform
                    .DOAnchorPosY(-900f, _animationTime)
                    .SetEase(Ease.Linear))
                .Join(enemyImage.rectTransform
                    .DOScale(Vector3.one * 1.25f, _animationTime)
                    .SetEase(Ease.OutBack))
                .AppendCallback(action.Invoke)
                .Append(enemyImage.rectTransform
                    .DOAnchorPosY(-25f, _animationTime)
                    .SetEase(Ease.Linear))
                .Join(enemyImage.rectTransform
                    .DOScale(Vector3.one, _animationTime))
                .WithCancellation(token);
        }
    }
}
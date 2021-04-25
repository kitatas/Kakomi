using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class TurnCountView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI turnCountText = default;

        public void Init()
        {
            turnCountText.rectTransform.anchoredPosition = new Vector2(-800.0f, 0.0f);
        }

        public void Display(int turnCount)
        {
            turnCountText.text = $"Turn {turnCount}";
        }

        public async UniTask TweenAsync(CancellationToken token)
        {
            await turnCountText.rectTransform
                .DOAnchorPosX(0.0f, 0.5f)
                .SetEase(Ease.Linear)
                .WithCancellation(token);

            await UniTask.Delay(TimeSpan.FromSeconds(1.0f), cancellationToken: token);

            await turnCountText.rectTransform
                .DOAnchorPosX(800.0f, 0.5f)
                .SetEase(Ease.Linear)
                .WithCancellation(token);

            Init();
        }
    }
}
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Kakomi.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class TurnCountView : MonoBehaviour
    {
        [SerializeField] private Image turnCountBackImage = default;
        [SerializeField] private TextMeshProUGUI turnCountText = default;

        private int _turnCount = 0;

        private void Initialize()
        {
            turnCountBackImage.enabled = true;
            turnCountBackImage.color = turnCountBackImage.color.SetAlpha(0.1f);
            turnCountBackImage.rectTransform.localScale = new Vector3(1f, 0.1f, 1f);

            _turnCount++;
            turnCountText.text = $"Turn {_turnCount}";
            turnCountText.rectTransform.anchoredPosition = new Vector2(-800f, 0f);
        }

        public async UniTask TweenTurnTextAsync(CancellationToken token)
        {
            Initialize();

            await DOTween.Sequence()
                .Append(turnCountBackImage
                    .DOFade(1.0f, 0.1f)
                    .SetEase(Ease.Linear))
                .Join(turnCountBackImage.rectTransform
                    .DOScaleY(1f, 0.5f)
                    .SetEase(Ease.Linear))
                .Append(turnCountText.rectTransform
                    .DOAnchorPosX(0f, 0.5f)
                    .SetEase(Ease.Linear))
                .WithCancellation(token);

            await UniTask.Delay(TimeSpan.FromSeconds(1.0f), cancellationToken: token);

            await turnCountText.rectTransform
                .DOAnchorPosX(800f, 0.5f)
                .SetEase(Ease.Linear)
                .WithCancellation(token);

            turnCountBackImage.enabled = false;
        }
    }
}
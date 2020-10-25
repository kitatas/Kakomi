using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Kakomi.Utility;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Kakomi.InGame.Presentation.View
{
    [RequireComponent(typeof(Image))]
    public sealed class StockObject : MonoBehaviour
    {
        [SerializeField] private Image image = default;
        private RectTransform RectTransform => transform as RectTransform;

        private CancellationToken _token;
        private Camera _uiCamera;
        private Canvas _uiCanvas;

        public void Initialize(Camera uiCamera, Canvas uiCanvas, RectTransform rectTransform)
        {
            _token = this.GetCancellationTokenOnDestroy();
            _uiCamera = uiCamera;
            _uiCanvas = uiCanvas;

            transform.SetParent(rectTransform);
            transform.localScale = Vector3.one;
        }

        public async UniTask SetSprite(Sprite sprite, Vector2 localPosition)
        {
            image.sprite = sprite;
            RectTransform.localPosition = _uiCanvas.GetWorldPosition(_uiCamera, localPosition);

            await UniTask.Delay(TimeSpan.FromSeconds(0.5f), cancellationToken: _token);
        }

        public async UniTask TweenStockPosition(Vector2 position)
        {
            await image.rectTransform
                .DOAnchorPos(position, 0.25f)
                .WithCancellation(_token);
        }

        public void TweenAttackPosition(Vector2 position, Action<StockObject> action)
        {
            image.rectTransform
                .DOMove(position, 0.1f)
                .OnComplete(() =>
                {
                    action?.Invoke(this);
                });
        }

        public class Factory : PlaceholderFactory<StockObject>
        {
        }
    }
}
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kakomi.InGame.Application;
using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.Utility;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.View
{
    [RequireComponent(typeof(LineRenderer))]
    public sealed class LineView : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer = default;

        public bool IsEnclose { get; private set; }

        private CancellationToken _token;
        private ILineUseCase _lineUseCase;

        [Inject]
        private void Construct(ILineUseCase lineUseCase)
        {
            _token = this.GetCancellationTokenOnDestroy();
            _lineUseCase = lineUseCase;

            lineRenderer.SetWidth(DrawParameter.LINE_WIDTH);
            lineRenderer.positionCount = 2;
        }

        public void DrawLine(Action action)
        {
            IsEnclose = false;
            _lineUseCase.DrawLine(points =>
            {
                var (startPoint, endPoint) = points;
                lineRenderer.SetPosition(0, startPoint);
                lineRenderer.SetPosition(1, endPoint);

                UniTask.Void(async _ =>
                {
                    await UniTask.WhenAny(
                        UniTask.Delay(TimeSpan.FromSeconds(DrawParameter.DELETE_TIME), cancellationToken: _token),
                        UniTask.WaitUntil(() => IsEnclose, cancellationToken: _token));

                    _lineUseCase.DeleteLinePoint(startPoint);

                    // poolに返却
                    action?.Invoke();
                }, this);
            });
        }

        public void SetEnclose()
        {
            IsEnclose = true;
        }

        public class Factory : PlaceholderFactory<LineView>
        {
        }
    }
}
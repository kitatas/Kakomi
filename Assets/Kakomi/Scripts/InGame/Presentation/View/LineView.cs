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

        private ILineUseCase _lineUseCase;

        [Inject]
        private void Construct(ILineUseCase lineUseCase)
        {
            _lineUseCase = lineUseCase;

            Initialize();
        }

        private void Initialize()
        {
            lineRenderer.SetWidth(DrawParameter.LINE_WIDTH);
            lineRenderer.positionCount = 2;
        }

        public void DrawLine()
        {
            _lineUseCase.DrawLine(points =>
            {
                var (startPoint, endPoint) = points;
                lineRenderer.SetPosition(0, startPoint);
                lineRenderer.SetPosition(1, endPoint);

                var token = this.GetCancellationTokenOnDestroy();
                DeleteLineAsync(token, startPoint).Forget();
            });
        }

        private async UniTaskVoid DeleteLineAsync(CancellationToken token, Vector2 startPoint)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(DrawParameter.DELETE_TIME), cancellationToken: token);

            _lineUseCase.DeleteLinePoint(startPoint);
            Destroy(gameObject);
        }
    }
}
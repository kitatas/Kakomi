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

        [Inject]
        private void Construct(ILineUseCase lineUseCase)
        {
            lineRenderer.SetWidth(DrawParameter.LINE_WIDTH);
            lineRenderer.positionCount = 2;

            lineUseCase.DrawLine(points =>
            {
                var (startPoint, endPoint) = points;
                lineRenderer.SetPosition(0, startPoint);
                lineRenderer.SetPosition(1, endPoint);

                var token = this.GetCancellationTokenOnDestroy();
                DeleteLineAsync(token, () =>
                {
                    lineUseCase.DeleteLinePoint(startPoint);
                    Destroy(gameObject);
                }).Forget();
            });
        }

        private async UniTaskVoid DeleteLineAsync(CancellationToken token, Action action)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(DrawParameter.DELETE_TIME), cancellationToken: token);

            action?.Invoke();
        }
    }
}
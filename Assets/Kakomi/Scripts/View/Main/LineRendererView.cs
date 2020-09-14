using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kakomi.Scripts.UseCase.Main.Interface;
using UnityEngine;
using Zenject;

namespace Kakomi.Scripts.View.Main
{
    [RequireComponent(typeof(LineRenderer))]
    public sealed class LineRendererView : MonoBehaviour
    {
        private readonly float _deleteTime = 2.0f;

        private ILineRendererUseCase _lineRendererUseCase;

        [Inject]
        private void Construct(ILineRendererUseCase lineRendererUseCase)
        {
            _lineRendererUseCase = lineRendererUseCase;
        }

        public void DrawLine()
        {
            _lineRendererUseCase.DrawLine();

            var token = this.GetCancellationTokenOnDestroy();
            DeleteLineAsync(token).Forget();
        }

        private async UniTaskVoid DeleteLineAsync(CancellationToken token)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_deleteTime), cancellationToken: token);

            _lineRendererUseCase.DeleteLine();
            Destroy(gameObject);
        }
    }
}
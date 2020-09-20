using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kakomi.Scripts.UseCase.Main.Interface;
using UnityEngine;
using Zenject;

namespace Kakomi.Scripts.View.Main
{
    [RequireComponent(typeof(LineRenderer))]
    public sealed class LineView : MonoBehaviour
    {
        private readonly float _deleteTime = 2.0f;

        private ILineUseCase _lineUseCase;

        [Inject]
        private void Construct(ILineUseCase lineUseCase)
        {
            _lineUseCase = lineUseCase;
        }

        public void DrawLine()
        {
            _lineUseCase.DrawLine();

            var token = this.GetCancellationTokenOnDestroy();
            DeleteLineAsync(token).Forget();
        }

        private async UniTaskVoid DeleteLineAsync(CancellationToken token)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_deleteTime), cancellationToken: token);

            _lineUseCase.DeleteLine();
            Destroy(gameObject);
        }
    }
}
using Cysharp.Threading.Tasks;
using Kakomi.InGame.Domain.UseCase.Interface;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.View
{
    [RequireComponent(typeof(LineRenderer))]
    public sealed class LineView : MonoBehaviour
    {
        private ILineUseCase _lineUseCase;

        [Inject]
        private void Construct(ILineUseCase lineUseCase)
        {
            _lineUseCase = lineUseCase;
        }

        public void DrawLine()
        {
            var token = this.GetCancellationTokenOnDestroy();
            _lineUseCase.DrawLine(token);
        }
    }
}
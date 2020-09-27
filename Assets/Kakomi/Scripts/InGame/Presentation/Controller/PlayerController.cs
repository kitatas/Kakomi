using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.InGame.Presentation.View;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.Controller
{
    public sealed class PlayerController : MonoBehaviour
    {
        [SerializeField] private CursorView cursorView = default;

        private IInputUseCase _inputUseCase;

        [Inject]
        private void Construct(IInputUseCase inputUseCase)
        {
            _inputUseCase = inputUseCase;
        }

        private void Start()
        {
            this.UpdateAsObservable()
                .Where(_ => _inputUseCase.InputMouseButton())
                .Subscribe(_ =>
                {
                    // カーソル移動
                    var mousePosition = _inputUseCase.GetInputPosition();
                    cursorView.Move(mousePosition);
                })
                .AddTo(this);
        }
    }
}
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
        private ICursorPointsUseCase _cursorPointsUseCase;

        [Inject]
        private void Construct(IInputUseCase inputUseCase, ICursorPointsUseCase cursorPointsUseCase)
        {
            _inputUseCase = inputUseCase;
            _cursorPointsUseCase = cursorPointsUseCase;
        }

        private void Start()
        {
            this.UpdateAsObservable()
                .Where(_ => _inputUseCase.InputMouseButton())
                .Subscribe(_ =>
                {
                    // カーソル移動
                    var mousePosition = _inputUseCase.GetInputPosition();
                    var cursorPoint = cursorView.Move(mousePosition);

                    // カーソル位置の追加
                    _cursorPointsUseCase.AddCursorPoint(cursorPoint);
                })
                .AddTo(this);
        }
    }
}
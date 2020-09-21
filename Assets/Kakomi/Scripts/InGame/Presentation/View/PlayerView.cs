using Kakomi.InGame.Domain.UseCase.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class PlayerView : MonoBehaviour
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
                    cursorView.Move(mousePosition);

                    // マウス位置が前フレームの値と近しい値であるか
                    if (_cursorPointsUseCase.IsAddCursorPoint(mousePosition) == false)
                    {
                        return;
                    }

                    // 線の描画
                    var cursorPoint = cursorView.GetPosition();
                    _cursorPointsUseCase.AddCursorPoint(cursorPoint);

                    // 線が交差している場合
                    _cursorPointsUseCase.DoEnclosureAction();
                })
                .AddTo(this);
        }
    }
}
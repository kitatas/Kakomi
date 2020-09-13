using Kakomi.Scripts.UseCase.Main.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Kakomi.Scripts.View.Main
{
    public sealed class PlayerView : MonoBehaviour
    {
        [SerializeField] private CursorView cursorView = default;
        [SerializeField] private LineView lineView = default;

        private IInputUseCase _inputUseCase;
        private ICursorPointListUseCase _cursorPointListUseCase;

        [Inject]
        private void Construct(
            IInputUseCase inputUseCase,
            ICursorPointListUseCase cursorPointListUseCase)
        {
            _inputUseCase = inputUseCase;
            _cursorPointListUseCase = cursorPointListUseCase;
        }

        private void Start()
        {
            this.UpdateAsObservable()
                .Where(_ => _inputUseCase.InputMouseButton())
                .Subscribe(_ =>
                {
                    // カーソル移動
                    var mousePosition = _inputUseCase.GetMousePosition();
                    cursorView.Move(mousePosition);

                    // マウス位置が前フレームの値と近しい値であるか
                    if (_cursorPointListUseCase.IsAddCursorPoint(mousePosition) == false)
                    {
                        return;
                    }

                    // 線の描画
                    var cursorPosition = cursorView.GetPosition();
                    lineView.DrawLine(cursorPosition);
                    _cursorPointListUseCase.AddCursorPoint(cursorPosition);

                    // 線が交差している場合
                    if (_cursorPointListUseCase.IsCrossLine())
                    {
                        lineView.ResetLine();

                        // TODO : 囲んだ時のアクション
                    }
                })
                .AddTo(this);
        }
    }
}
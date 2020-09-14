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
        private ICursorPointsUseCase _cursorPointsUseCase;

        [Inject]
        private void Construct(
            IInputUseCase inputUseCase,
            ICursorPointsUseCase cursorPointsUseCase)
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
                    var mousePosition = _inputUseCase.GetMousePosition();
                    cursorView.Move(mousePosition);

                    // マウス位置が前フレームの値と近しい値であるか
                    if (_cursorPointsUseCase.IsAddCursorPoint(mousePosition) == false)
                    {
                        return;
                    }

                    // 線の描画
                    var cursorPosition = cursorView.GetPosition();
                    _cursorPointsUseCase.AddCursorPoint(cursorPosition);
                    lineView.DrawLine();

                    // 線が交差している場合
                    if (_cursorPointsUseCase.IsCrossLine())
                    {
                        lineView.DeleteLine();

                        // TODO : 囲んだ時のアクション
                    }
                })
                .AddTo(this);
        }
    }
}
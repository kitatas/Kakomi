using System.Collections.Generic;
using System.Linq;
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

        private List<LineView> _lineViews;

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
            _lineViews = new List<LineView>();

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
                    var line = Instantiate(lineView, transform);
                    line.DrawLine();
                    _lineViews.Add(line);

                    // 線が交差している場合
                    if (_cursorPointsUseCase.IsCrossLine())
                    {
                        ResetLine();

                        // TODO : 囲んだ時のアクション
                    }
                })
                .AddTo(this);
        }

        private void ResetLine()
        {
            foreach (var line in _lineViews.Where(line => line != null))
            {
                Destroy(line.gameObject);
            }

            _lineViews.Clear();
        }
    }
}
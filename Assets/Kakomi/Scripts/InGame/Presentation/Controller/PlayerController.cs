using Kakomi.InGame.Application;
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
        private IGameStateUseCase _gameStateUseCase;

        [Inject]
        private void Construct(IInputUseCase inputUseCase, IGameStateUseCase gameStateUseCase)
        {
            _inputUseCase = inputUseCase;
            _gameStateUseCase = gameStateUseCase;
        }

        private void Start()
        {
            this.UpdateAsObservable()
                .Where(_ => _gameStateUseCase.GetCurrentGameState() == GameState.Draw)
                .Where(_ => _inputUseCase.IsInputScreen())
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
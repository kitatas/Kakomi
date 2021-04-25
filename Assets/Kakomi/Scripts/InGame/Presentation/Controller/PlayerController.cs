using Kakomi.InGame.Application;
using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.InGame.Presentation.View;
using Zenject;

namespace Kakomi.InGame.Presentation.Controller
{
    public sealed class PlayerController : ITickable
    {
        private readonly IInputUseCase _inputUseCase;
        private readonly IGameStateUseCase _gameStateUseCase;
        private readonly CursorView _cursorView;

        public PlayerController(IInputUseCase inputUseCase, IGameStateUseCase gameStateUseCase, CursorView cursorView)
        {
            _inputUseCase = inputUseCase;
            _gameStateUseCase = gameStateUseCase;
            _cursorView = cursorView;
        }

        public void Tick()
        {
            if (_gameStateUseCase.IsEqual(GameState.Draw) && _inputUseCase.IsInputScreen())
            {
                // カーソル移動
                var mousePosition = _inputUseCase.GetInputPosition();
                _cursorView.Move(mousePosition);
            }
        }
    }
}
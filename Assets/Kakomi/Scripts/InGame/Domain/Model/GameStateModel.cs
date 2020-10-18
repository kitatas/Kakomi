using Kakomi.InGame.Application;
using Kakomi.InGame.Domain.Model.Interface;
using UniRx;

namespace Kakomi.InGame.Domain.Model
{
    public sealed class GameStateModel : IGameStateModel
    {
        private readonly ReactiveProperty<GameState> _gameState;

        public GameStateModel(GameState gameState)
        {
            _gameState = new ReactiveProperty<GameState>(gameState);
        }

        public IReadOnlyReactiveProperty<GameState> GameState => _gameState;

        public void SetGameState(GameState gameState)
        {
            _gameState.Value = gameState;
        }
    }
}
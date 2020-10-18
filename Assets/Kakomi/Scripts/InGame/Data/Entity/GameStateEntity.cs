using Kakomi.InGame.Application;
using Kakomi.InGame.Data.Entity.Interface;

namespace Kakomi.InGame.Data.Entity
{
    public sealed class GameStateEntity : IGameStateEntity
    {
        private GameState _gameState;

        public GameStateEntity(GameState gameState)
        {
            _gameState = gameState;
        }

        public void SetGameState(GameState gameState) => _gameState = gameState;

        public GameState GetCurrentGameState() => _gameState;
    }
}
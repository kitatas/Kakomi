using Kakomi.InGame.Application;
using Kakomi.InGame.Data.Entity.Interface;
using Kakomi.InGame.Domain.Model.Interface;
using Kakomi.InGame.Domain.UseCase.Interface;
using UniRx;

namespace Kakomi.InGame.Domain.UseCase
{
    public sealed class GameStateUseCase : IGameStateUseCase
    {
        private readonly IGameStateEntity _gameStateEntity;
        private readonly IGameStateModel _gameStateModel;

        public GameStateUseCase(IGameStateEntity gameStateEntity, IGameStateModel gameStateModel)
        {
            _gameStateEntity = gameStateEntity;
            _gameStateModel = gameStateModel;
        }

        public IReadOnlyReactiveProperty<GameState> GameState() => _gameStateModel.GameState;

        public GameState GetCurrentGameState() => _gameStateEntity.GetCurrentGameState();

        public void SetGameState(GameState gameState)
        {
            _gameStateEntity.SetGameState(gameState);
            _gameStateModel.SetGameState(GetCurrentGameState());
        }
    }
}
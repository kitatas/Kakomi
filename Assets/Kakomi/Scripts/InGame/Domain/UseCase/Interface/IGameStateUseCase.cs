using Kakomi.InGame.Application;
using UniRx;

namespace Kakomi.InGame.Domain.UseCase.Interface
{
    public interface IGameStateUseCase
    {
        IReadOnlyReactiveProperty<GameState> GameState();
        GameState GetCurrentGameState();
        void SetGameState(GameState gameState);
        bool IsEqual(GameState gameState);
    }
}
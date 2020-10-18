using Kakomi.InGame.Application;

namespace Kakomi.InGame.Data.Entity.Interface
{
    public interface IGameStateEntity
    {
        void SetGameState(GameState gameState);
        GameState GetCurrentGameState();
    }
}
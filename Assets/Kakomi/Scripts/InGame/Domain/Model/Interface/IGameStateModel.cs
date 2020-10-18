using Kakomi.InGame.Application;
using UniRx;

namespace Kakomi.InGame.Domain.Model.Interface
{
    public interface IGameStateModel
    {
        IReadOnlyReactiveProperty<GameState> GameState { get; }
        void SetGameState(GameState gameState);
    }
}
using UniRx;

namespace Kakomi.InGame.Domain.Model.Interface
{
    public interface ITurnCountModel
    {
        IReadOnlyReactiveProperty<int> TurnCount { get; }
        void SetTurnCount(int turnCount);
    }
}
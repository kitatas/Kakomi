using Kakomi.InGame.Domain.Model.Interface;
using UniRx;

namespace Kakomi.InGame.Domain.Model
{
    public sealed class TurnCountModel : ITurnCountModel
    {
        private readonly ReactiveProperty<int> _turnCount;

        public TurnCountModel(int turnCount)
        {
            _turnCount = new ReactiveProperty<int>(turnCount);
        }

        public IReadOnlyReactiveProperty<int> TurnCount => _turnCount;

        public void SetTurnCount(int turnCount)
        {
            _turnCount.Value = turnCount;
        }
    }
}
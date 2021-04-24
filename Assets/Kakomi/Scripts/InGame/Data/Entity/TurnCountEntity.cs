using Kakomi.InGame.Data.Entity.Interface;

namespace Kakomi.InGame.Data.Entity
{
    public sealed class TurnCountEntity : ITurnCountEntity
    {
        private int _turnCount;

        public TurnCountEntity(int turnCount)
        {
            _turnCount = turnCount;
        }

        public void SetTurnCount(int turnCount) => _turnCount = turnCount;

        public int GetTurnCount() => _turnCount;
    }
}
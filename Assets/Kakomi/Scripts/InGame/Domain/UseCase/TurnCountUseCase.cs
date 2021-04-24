using Kakomi.InGame.Data.Entity.Interface;
using Kakomi.InGame.Domain.Model.Interface;
using Kakomi.InGame.Domain.UseCase.Interface;
using UniRx;

namespace Kakomi.InGame.Domain.UseCase
{
    public sealed class TurnCountUseCase : ITurnCountUseCase
    {
        private readonly ITurnCountEntity _turnCountEntity;
        private readonly ITurnCountModel _turnCountModel;

        public TurnCountUseCase(ITurnCountEntity turnCountEntity, ITurnCountModel turnCountModel)
        {
            _turnCountEntity = turnCountEntity;
            _turnCountModel = turnCountModel;
        }

        public IReadOnlyReactiveProperty<int> TurnCount() => _turnCountModel.TurnCount;

        public int GetCurrentTurnCount() => _turnCountEntity.GetTurnCount();

        public void CountUpTurn(int countUpValue)
        {
            var nextTurnCount = GetCurrentTurnCount() + countUpValue;
            _turnCountEntity.SetTurnCount(nextTurnCount);
            _turnCountModel.SetTurnCount(nextTurnCount);
        }
    }
}
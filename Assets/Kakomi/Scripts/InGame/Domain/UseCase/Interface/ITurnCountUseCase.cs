using UniRx;

namespace Kakomi.InGame.Domain.UseCase.Interface
{
    public interface ITurnCountUseCase
    {
        public IReadOnlyReactiveProperty<int> TurnCount();
        public int GetCurrentTurnCount();
        public void CountUpTurn(int countUpValue);
    }
}
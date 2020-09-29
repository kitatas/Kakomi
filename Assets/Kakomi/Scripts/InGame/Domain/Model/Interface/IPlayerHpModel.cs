using UniRx;

namespace Kakomi.InGame.Domain.Model.Interface
{
    public interface IPlayerHpModel
    {
        IReadOnlyReactiveProperty<int> HpModel { get; }
        IPlayerHpModel Initialize(int maxHpValue);
        void UpdatePlayerHp(int addValue);
    }
}
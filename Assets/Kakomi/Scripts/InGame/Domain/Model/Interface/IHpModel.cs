using UniRx;

namespace Kakomi.InGame.Domain.Model.Interface
{
    public interface IHpModel
    {
        IReadOnlyReactiveProperty<int> HpValue { get; }
        void SetPlayerHp(int setValue);
    }
}
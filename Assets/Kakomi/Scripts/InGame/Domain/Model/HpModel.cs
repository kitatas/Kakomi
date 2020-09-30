using Kakomi.InGame.Domain.Model.Interface;
using UniRx;

namespace Kakomi.InGame.Domain.Model
{
    public sealed class HpModel : IHpModel
    {
        private readonly ReactiveProperty<int> _hpValue;

        public HpModel(int maxHpValue)
        {
            _hpValue = new ReactiveProperty<int>(maxHpValue);
        }

        public IReadOnlyReactiveProperty<int> HpValue => _hpValue;

        public void SetPlayerHp(int setValue)
        {
            _hpValue.Value = setValue;
        }
    }
}
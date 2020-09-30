using Kakomi.InGame.Data.Entity.Interface;

namespace Kakomi.InGame.Data.Entity
{
    public sealed class HpEntity : IHpEntity
    {
        private int _hpValue;

        public HpEntity(int maxHpValue)
        {
            _hpValue = maxHpValue;
        }

        public int GetHpValue() => _hpValue;

        public void SetHpValue(int setHpValue) => _hpValue = setHpValue;

        public int GetCalculateHpValue(int addValue) => _hpValue + addValue;
    }
}
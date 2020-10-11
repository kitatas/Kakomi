using Kakomi.InGame.Data.Entity.Interface;

namespace Kakomi.InGame.Data.Entity
{
    public sealed class EnclosureObjectValueEntity : IEnclosureObjectValueEntity
    {
        public int BulletTotalValue { get; private set; }
        public int BombTotalValue { get; private set; }
        public int HeartTotalValue { get; private set; }

        public EnclosureObjectValueEntity()
        {
            ResetAllValue();
        }

        public void SetAttackValue(int setValue) => BulletTotalValue = setValue;

        public void SetDamageValue(int setValue) => BombTotalValue = setValue;

        public void SetRecoverValue(int setValue) => HeartTotalValue = setValue;

        public void AddAttackValue(int addValue) => SetAttackValue(BulletTotalValue + addValue);

        public void AddDamageValue(int addValue) => SetDamageValue(BombTotalValue + addValue);

        public void AddRecoverValue(int addValue) => SetRecoverValue(HeartTotalValue + addValue);

        public void ResetAllValue()
        {
            SetAttackValue(0);
            SetDamageValue(0);
            SetRecoverValue(0);
        }
    }
}
namespace Kakomi.InGame.Data.Entity.Interface
{
    public interface IEnclosureObjectValueEntity
    {
        int BulletTotalValue { get; }
        int BombTotalValue { get; }
        int HeartTotalValue { get; }
        void SetAttackValue(int setValue);
        void SetDamageValue(int setValue);
        void SetRecoverValue(int setValue);
        void AddAttackValue(int addValue);
        void AddDamageValue(int addValue);
        void AddRecoverValue(int addValue);
        void ResetAllValue();
    }
}
namespace Kakomi.InGame.Data.Entity.Interface
{
    public interface IHpEntity
    {
        int GetHpValue();
        void SetHpValue(int setHpValue);
        int GetCalculateHpValue(int addValue);
    }
}
namespace Kakomi.InGame.Data.Entity.Interface
{
    public interface ICharacterEntity
    {
        int GetHp();
        int GetAttack();
        void AddHp(int addValue);
    }
}
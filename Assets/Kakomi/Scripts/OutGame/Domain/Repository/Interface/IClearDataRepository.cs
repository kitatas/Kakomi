namespace Kakomi.OutGame.Domain.Repository.Interface
{
    public interface IClearDataRepository
    {
        bool LoadClearData(int level);
        void DeleteClearData(int level);
    }
}
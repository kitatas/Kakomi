namespace Kakomi.OutGame.Domain.Repository.Interface
{
    public interface IClearDataRepository
    {
        bool[] LoadClearData();
        void DeleteClearData();
    }
}
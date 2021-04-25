namespace Kakomi.OutGame.Domain.UseCase.Interface
{
    public interface IClearDataUseCase
    {
        bool[] LoadClearData();
        void DeleteAllClearData();
    }
}
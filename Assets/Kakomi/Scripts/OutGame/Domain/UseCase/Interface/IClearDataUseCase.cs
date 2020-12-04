namespace Kakomi.OutGame.Domain.UseCase.Interface
{
    public interface IClearDataUseCase
    {
        bool LoadClearData(int level);
        void DeleteAllClearData(int stageDataCount);
    }
}
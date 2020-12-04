using Kakomi.OutGame.Domain.Repository.Interface;
using Kakomi.OutGame.Domain.UseCase.Interface;

namespace Kakomi.OutGame.Domain.UseCase
{
    public sealed class ClearDataUseCase : IClearDataUseCase
    {
        private readonly IClearDataRepository _clearDataRepository;

        public ClearDataUseCase(IClearDataRepository clearDataRepository)
        {
            _clearDataRepository = clearDataRepository;
        }

        public bool LoadClearData(int level)
        {
            return _clearDataRepository.LoadClearData(level);
        }

        public void DeleteAllClearData(int stageDataCount)
        {
            for (int i = 0; i < stageDataCount; i++)
            {
                _clearDataRepository.DeleteClearData(i + 1);
            }
        }
    }
}
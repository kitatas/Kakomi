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

        public bool[] LoadClearData()
        {
            return _clearDataRepository.LoadClearData();
        }

        public void DeleteAllClearData()
        {
            _clearDataRepository.DeleteClearData();
        }
    }
}
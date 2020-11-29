using Kakomi.Common.Domain.Repository;
using Kakomi.Common.Domain.Repository.Interface;
using Kakomi.Common.Domain.UseCase.Interface;
using Kakomi.Common.Presentation.Controller.Interface;

namespace Kakomi.Common.Domain.UseCase
{
    public sealed class SoundUseCase : ISoundUseCase
    {
        private readonly ISoundRepository _soundRepository;

        public SoundUseCase()
        {
            _soundRepository = new SoundRepository();
        }

        public void LoadSound(IVolumeUpdatable bgm, IVolumeUpdatable se)
        {
            _soundRepository.LoadSound(bgm, se);
        }

        public void SaveSound(IVolumeUpdatable bgm, IVolumeUpdatable se)
        {
            _soundRepository.SaveSound(bgm, se);
        }
    }
}
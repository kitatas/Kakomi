using Kakomi.Common.Presentation.Controller.Interface;

namespace Kakomi.Common.Domain.UseCase.Interface
{
    public interface ISoundUseCase
    {
        void LoadSound(IVolumeUpdatable bgm, IVolumeUpdatable se);
        void SaveSound(IVolumeUpdatable bgm, IVolumeUpdatable se);
    }
}
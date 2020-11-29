using Kakomi.Common.Presentation.Controller.Interface;

namespace Kakomi.Common.Domain.Repository.Interface
{
    public interface ISoundRepository
    {
        void LoadSound(IVolumeUpdatable bgm, IVolumeUpdatable se);
        void SaveSound(IVolumeUpdatable bgm, IVolumeUpdatable se);
    }
}
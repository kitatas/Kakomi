using Kakomi.Common.Data.Entity.Interface;

namespace Kakomi.Common.Presentation.Controller.Interface
{
    public interface IVolumeUpdatable
    {
        void SetMute(bool value);
        bool IsMute();
        void SetVolume(float value);
        float GetVolume();
        ISoundEntity soundEntity { get; }
    }
}
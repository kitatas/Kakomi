namespace Kakomi.Common.Data.Entity.Interface
{
    public interface ISoundEntity
    {
        float GetVolume();
        bool IsMute();
        void SetVolume(float value);
        void SetMute(bool value);
    }
}
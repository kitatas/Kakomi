using Kakomi.Common.Data.Entity.Interface;

namespace Kakomi.Common.Data.Entity
{
    public sealed class SoundEntity : ISoundEntity
    {
        private float _volume;
        private bool _isMute;

        public SoundEntity(float volume, bool isMute)
        {
            _volume = volume;
            _isMute = isMute;
        }

        public float GetVolume() => _volume;
        public bool IsMute() => _isMute;

        public void SetVolume(float value) => _volume = value;
        public void SetMute(bool value) => _isMute = value;
    }
}
using Kakomi.Common.Data.Entity;
using Kakomi.Common.Data.Entity.Interface;
using Kakomi.Common.Presentation.Controller.Interface;
using UnityEngine;

namespace Kakomi.Common.Presentation.Controller
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class BaseAudioSource : MonoBehaviour, IVolumeUpdatable
    {
        private AudioSource _audioSource;

        protected AudioSource audioSource
        {
            get
            {
                if (_audioSource == null)
                {
                    _audioSource = GetComponent<AudioSource>();
                }

                return _audioSource;
            }
        }

        public void SetMute(bool value) => audioSource.enabled = !value;

        public bool IsMute() => !audioSource.enabled;

        public void SetVolume(float value) => audioSource.volume = value;

        public float GetVolume() => audioSource.volume;

        private ISoundEntity _soundEntity;

        public ISoundEntity soundEntity => _soundEntity ?? (_soundEntity = new SoundEntity(GetVolume(), IsMute()));
    }
}
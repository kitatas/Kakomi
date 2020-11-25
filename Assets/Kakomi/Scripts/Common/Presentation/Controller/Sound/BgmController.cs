using Kakomi.Common.Application;
using Kakomi.Common.Data.DataStore;
using Kakomi.Utility;
using UnityEngine;
using Zenject;

namespace Kakomi.Common.Presentation.Controller
{
    public sealed class BgmController : BaseAudioSource
    {
        private AudioClip[] _bgmList;

        [Inject]
        private void Construct(BgmTable bgmTable)
        {
            _bgmList = bgmTable.GetBgmList();
        }

        public void PlayBgm(BgmType bgmType)
        {
            if (_bgmList.TryGetValue((int) bgmType, out var clip))
            {
                if (audioSource.clip == clip)
                {
                    return;
                }

                audioSource.clip = clip;
                audioSource.Play();
            }
        }

        public void StopBgm()
        {
            audioSource.Stop();
        }
    }
}
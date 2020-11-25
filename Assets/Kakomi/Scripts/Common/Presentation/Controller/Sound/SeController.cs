using Kakomi.Common.Application;
using Kakomi.Common.Data.DataStore;
using Kakomi.Utility;
using UnityEngine;
using Zenject;

namespace Kakomi.Common.Presentation.Controller
{
    public sealed class SeController : BaseAudioSource
    {
        private AudioClip[] _seList;

        [Inject]
        private void Construct(SeTable seTable)
        {
            _seList = seTable.GetSeList();
        }

        public void PlaySe(SeType seType)
        {
            if (_seList.TryGetValue((int) seType, out var clip))
            {
                audioSource.PlayOneShot(clip);
            }
        }
    }
}
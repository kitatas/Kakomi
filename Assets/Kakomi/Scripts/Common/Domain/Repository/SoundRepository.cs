using Kakomi.Common.Application;
using Kakomi.Common.Domain.Repository.Interface;
using Kakomi.Common.Presentation.Controller.Interface;

namespace Kakomi.Common.Domain.Repository
{
    public sealed class SoundRepository : ISoundRepository
    {
        public void LoadSound(IVolumeUpdatable bgm, IVolumeUpdatable se)
        {
            UnityEngine.Debug.Log("load!!!");

            var bgmSoundEntity = ES3.Load(SaveKey.BGM, bgm.soundEntity);
            bgm.SetVolume(bgmSoundEntity.GetVolume());
            bgm.SetMute(bgmSoundEntity.IsMute());

            var seSoundEntity = ES3.Load(SaveKey.SE, se.soundEntity);
            se.SetVolume(seSoundEntity.GetVolume());
            se.SetMute(seSoundEntity.IsMute());
        }

        public void SaveSound(IVolumeUpdatable bgm, IVolumeUpdatable se)
        {
            UnityEngine.Debug.Log("save!!!");
            ES3.Save(SaveKey.BGM, bgm.soundEntity);
            ES3.Save(SaveKey.SE, se.soundEntity);
        }
    }
}
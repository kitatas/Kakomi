using Kakomi.Common.Application;
using Kakomi.Common.Domain.Repository.Interface;
using Kakomi.Common.Presentation.Controller.Interface;

namespace Kakomi.Common.Domain.Repository
{
    public sealed class SoundRepository : ISoundRepository
    {
        public void LoadSound(IVolumeUpdatable bgm, IVolumeUpdatable se)
        {
            var bgmVolume = ES3.Load(SaveKey.BGM_VOLUME, bgm.GetVolume());
            bgm.SetVolume(bgmVolume);
            var bgmMute = ES3.Load(SaveKey.BGM_MUTE, bgm.IsMute());
            bgm.SetMute(bgmMute);

            var seVolume = ES3.Load(SaveKey.SE_VOLUME, se.GetVolume());
            se.SetVolume(seVolume);
            var seMute = ES3.Load(SaveKey.SE_MUTE, se.IsMute());
            se.SetMute(seMute);
        }

        public void SaveSound(IVolumeUpdatable bgm, IVolumeUpdatable se)
        {
            UnityEngine.Debug.Log("save!!!");
            ES3.Save(SaveKey.BGM_VOLUME, bgm.GetVolume());
            ES3.Save(SaveKey.BGM_MUTE, bgm.IsMute());

            ES3.Save(SaveKey.SE_VOLUME, se.GetVolume());
            ES3.Save(SaveKey.SE_MUTE, se.IsMute());
        }
    }
}
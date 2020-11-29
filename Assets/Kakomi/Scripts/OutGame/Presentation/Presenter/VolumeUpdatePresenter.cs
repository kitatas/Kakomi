using Kakomi.Common.Presentation.Controller;
using Kakomi.OutGame.Presentation.View;

namespace Kakomi.OutGame.Presentation.Presenter
{
    public sealed class VolumeUpdatePresenter
    {
        public VolumeUpdatePresenter(BgmController bgmController, SeController seController, VolumeUpdateView volumeUpdateView )
        {
            volumeUpdateView.UpdateBgmVolume(bgmController);
            volumeUpdateView.UpdateSeVolume(seController);
        }
    }
}
using Kakomi.OutGame.Presentation.Presenter;
using Zenject;

namespace Kakomi.OutGame.Installer
{
    public sealed class MenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<VolumeUpdatePresenter>()
                .AsCached()
                .NonLazy();
        }
    }
}
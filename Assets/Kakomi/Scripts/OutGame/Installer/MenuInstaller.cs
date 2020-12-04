using Kakomi.OutGame.Domain.Repository;
using Kakomi.OutGame.Domain.Repository.Interface;
using Kakomi.OutGame.Domain.UseCase;
using Kakomi.OutGame.Domain.UseCase.Interface;
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

            Container
                .Bind<IClearDataRepository>()
                .To<ClearDataRepository>()
                .AsCached();

            Container
                .Bind<IClearDataUseCase>()
                .To<ClearDataUseCase>()
                .AsCached();
        }
    }
}
using Kakomi.InGame.Domain.UseCase;
using Kakomi.InGame.Domain.UseCase.Interface;
using Zenject;

namespace Kakomi.InGame.Installer
{
    public sealed class EnclosureColliderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IEnclosurePointsUseCase>()
                .To<EnclosurePointsUseCase>()
                .AsCached();
        }
    }
}
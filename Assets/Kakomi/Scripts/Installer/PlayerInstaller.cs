using Kakomi.Scripts.Entity.Main;
using Kakomi.Scripts.Entity.Main.Interface;
using Kakomi.Scripts.UseCase.Main;
using Kakomi.Scripts.UseCase.Main.Interface;
using Zenject;

namespace Kakomi.Scripts.Installer
{
    public sealed class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ICursorPointsEntity>()
                .To<CursorPointsEntity>()
                .AsCached();

            Container
                .Bind<IEnclosurePointsEntity>()
                .To<EnclosurePointsEntity>()
                .AsCached();

            Container
                .Bind<ICursorPointsUseCase>()
                .To<CursorPointsUseCase>()
                .AsCached();

            Container
                .Bind<IEnclosurePointsUseCase>()
                .To<EnclosurePointsUseCase>()
                .AsCached();

            Container
                .Bind<IInputUseCase>()
                .To<InputUseCase>()
                .AsCached();
        }
    }
}
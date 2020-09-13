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
                .Bind<ICursorPointListEntity>()
                .To<CursorPointListEntity>()
                .AsCached();

            Container
                .Bind<ICursorPointListUseCase>()
                .To<CursorPointListUseCase>()
                .AsCached();

            Container
                .Bind<IInputUseCase>()
                .To<InputUseCase>()
                .AsCached();
        }
    }
}
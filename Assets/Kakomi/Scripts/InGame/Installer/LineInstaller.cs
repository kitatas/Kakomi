using Kakomi.InGame.Domain.UseCase;
using Kakomi.InGame.Domain.UseCase.Interface;
using Zenject;

namespace Kakomi.InGame.Installer
{
    public sealed class LineInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ILineUseCase>()
                .To<LineUseCase>()
                .AsCached();
        }
    }
}
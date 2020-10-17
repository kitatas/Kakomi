using Kakomi.Common.Presentation.Controller;
using Zenject;

namespace Kakomi.Common.Installer
{
    public sealed class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<SceneLoader>()
                .AsSingle();
        }
    }
}
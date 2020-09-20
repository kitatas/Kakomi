using Kakomi.Scripts.UseCase.Main;
using Kakomi.Scripts.UseCase.Main.Interface;
using UnityEngine;
using Zenject;

namespace Kakomi.Scripts.Installer
{
    public sealed class LineInstaller : MonoInstaller
    {
        [SerializeField] private LineRenderer lineRenderer = default;

        public override void InstallBindings()
        {
            Container
                .BindInstance(lineRenderer)
                .AsCached();

            Container
                .Bind<ILineUseCase>()
                .To<LineUseCase>()
                .AsCached();
        }
    }
}
using Kakomi.InGame.Domain.UseCase;
using Kakomi.InGame.Domain.UseCase.Interface;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Installer
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
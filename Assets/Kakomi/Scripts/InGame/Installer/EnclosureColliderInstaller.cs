using Kakomi.InGame.Domain.UseCase;
using Kakomi.InGame.Domain.UseCase.Interface;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Installer
{
    public sealed class EnclosureColliderInstaller : MonoInstaller
    {
        [SerializeField] private PolygonCollider2D polygonCollider = default;

        public override void InstallBindings()
        {
            Container
                .BindInstance(polygonCollider)
                .AsCached();

            Container
                .Bind<IEnclosurePointsUseCase>()
                .To<EnclosurePointsUseCase>()
                .AsCached();
        }
    }
}
using Kakomi.Scripts.UseCase.Main;
using Kakomi.Scripts.UseCase.Main.Interface;
using UnityEngine;
using Zenject;

namespace Kakomi.Scripts.Installer
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
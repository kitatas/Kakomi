using Kakomi.InGame.Data.DataStore;
using Kakomi.InGame.Data.Entity;
using Kakomi.InGame.Data.Entity.Interface;
using Kakomi.InGame.Domain.UseCase;
using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.InGame.Factory;
using Kakomi.InGame.Presentation.Presenter;
using Kakomi.InGame.Presentation.View;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Installer
{
    public sealed class InGameInstaller : MonoInstaller
    {
        [SerializeField] private LineTable lineTable = default;
        
        public override void InstallBindings()
        {
            #region Entity

            Container
                .Bind<ICursorPointsEntity>()
                .To<CursorPointsEntity>()
                .AsCached();

            Container
                .Bind<IEnclosurePointsEntity>()
                .To<EnclosurePointsEntity>()
                .AsCached();

            #endregion

            #region Factory

            Container
                .Bind<EnclosureFactory>()
                .AsCached();

            Container
                .Bind<LineFactory>()
                .AsCached();

            #endregion

            #region Model

            #endregion

            #region UseCase

            Container
                .Bind<ICursorPointsUseCase>()
                .To<CursorPointsUseCase>()
                .AsCached();

            Container
                .Bind<IEnclosurePointsUseCase>()
                .To<EnclosurePointsUseCase>()
                .AsCached();

            Container
                .Bind<ILineUseCase>()
                .To<LineUseCase>()
                .AsCached();

            Container
                .Bind<IInputUseCase>()
                .To<MouseInputUseCase>()
                .AsCached();

            Container
                .Bind<IPlayerHpUseCase>()
                .To<PlayerHpUseCase>()
                .AsCached();

            Container
                .Bind<IEnemyHpUseCase>()
                .To<EnemyHpUseCase>()
                .AsCached();

            #endregion

            #region Presenter

            Container
                .Bind<PlayerHpPresenter>()
                .AsCached()
                .NonLazy();

            Container
                .Bind<EnemyHpPresenter>()
                .AsCached()
                .NonLazy();

            #endregion

            #region View

            Container
                .BindFactory<LineView, LineView.Factory>()
                .FromComponentInNewPrefab(lineTable.LineView)
                .AsCached();

            Container
                .BindFactory<EnclosureCollider, EnclosureCollider.Factory>()
                .FromComponentInNewPrefab(lineTable.EnclosureCollider)
                .AsCached();

            #endregion
        }
    }
}
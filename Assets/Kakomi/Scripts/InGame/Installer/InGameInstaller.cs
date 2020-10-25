using Kakomi.InGame.Application;
using Kakomi.InGame.Data.DataStore;
using Kakomi.InGame.Data.Entity;
using Kakomi.InGame.Data.Entity.Interface;
using Kakomi.InGame.Domain.Model;
using Kakomi.InGame.Domain.Model.Interface;
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
        [SerializeField] private EnclosureObjectTable enclosureObjectTable = default;
        [SerializeField] private Camera mainCamera = default;
        [SerializeField] private Camera uiCamera = default;
        [SerializeField] private Canvas uiCanvas = default;
        [SerializeField] private RectTransform uiTransform = default;

        private readonly GameState _startState = GameState.Ready;

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

            Container
                .Bind<IEnclosureObjectValueEntity>()
                .To<EnclosureObjectValueEntity>()
                .AsCached();

            Container
                .Bind<IEnclosureObjectDataEntity>()
                .To<EnclosureObjectDataEntity>()
                .AsCached();

            Container
                .Bind<IGameStateEntity>()
                .To<GameStateEntity>()
                .AsCached()
                .WithArguments(_startState);

            #endregion

            #region Factory

            Container
                .Bind<EnclosureFactory>()
                .AsCached();

            Container
                .Bind<LineFactory>()
                .AsCached();

            Container
                .Bind<BombFactory>()
                .AsCached();

            Container
                .Bind<HeartFactory>()
                .AsCached();

            Container
                .Bind<BulletFactory>()
                .AsCached();

            Container
                .Bind<EffectFactory>()
                .AsCached();

            Container
                .Bind<StockFactory>()
                .AsCached()
                .WithArguments(uiCamera, uiCanvas, uiTransform);

            #endregion

            #region Model

            Container
                .Bind<IGameStateModel>()
                .To<GameStateModel>()
                .AsCached()
                .WithArguments(_startState);

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
                .AsCached()
                .WithArguments(mainCamera);

            Container
                .Bind<IHpUseCase>()
                .WithId(IdType.Player)
                .To<HpUseCase>()
                .AsCached()
                .WithArguments(new HpEntity(PlayerStatus.MAX_HP), new HpModel(PlayerStatus.MAX_HP));

            Container
                .Bind<IHpUseCase>()
                .WithId(IdType.Enemy)
                .To<HpUseCase>()
                .AsCached()
                .WithArguments(new HpEntity(EnemyStatus.MAX_HP), new HpModel(EnemyStatus.MAX_HP));

            Container
                .Bind<IEnclosureFactoryUseCase>()
                .To<EnclosureFactoryUseCase>()
                .AsCached();

            Container
                .Bind<IEnclosureObjectUseCase>()
                .To<EnclosureObjectUseCase>()
                .AsCached();

            Container
                .Bind<IGameStateUseCase>()
                .To<GameStateUseCase>()
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

            Container
                .BindFactory<BombView, BombView.Factory>()
                .FromComponentInNewPrefab(enclosureObjectTable.BombView)
                .AsCached();

            Container
                .BindFactory<HeartView, HeartView.Factory>()
                .FromComponentInNewPrefab(enclosureObjectTable.HeartView)
                .AsCached();

            Container
                .BindFactory<BulletView, BulletView.Factory>()
                .FromComponentInNewPrefab(enclosureObjectTable.BulletView)
                .AsCached();

            Container
                .BindFactory<EncloseEffectView, EncloseEffectView.Factory>()
                .FromComponentInNewPrefab(enclosureObjectTable.EncloseEffectView)
                .AsCached();

            Container
                .BindFactory<StockObject, StockObject.Factory>()
                .FromComponentInNewPrefab(enclosureObjectTable.StockObject)
                .AsCached();

            #endregion
        }
    }
}
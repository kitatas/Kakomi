using Kakomi.InGame.Application;
using Kakomi.InGame.Data.DataStore;
using Kakomi.InGame.Data.Entity;
using Kakomi.InGame.Data.Entity.Interface;
using Kakomi.InGame.Domain.Model;
using Kakomi.InGame.Domain.Model.Interface;
using Kakomi.InGame.Domain.Repository;
using Kakomi.InGame.Domain.Repository.Interface;
using Kakomi.InGame.Domain.UseCase;
using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.InGame.Factory;
using Kakomi.InGame.Presentation.Controller;
using Kakomi.InGame.Presentation.Presenter;
using Kakomi.InGame.Presentation.View;
using Kakomi.InGame.Presentation.View.State;
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
        [SerializeField] private CursorView cursorView = default;
        [SerializeField] private TurnCountView turnCountView = default;
        [SerializeField] private StockPositionCommander stockPositionCommander = default;
        [SerializeField] private ReadyView readyView = default;
        [SerializeField] private DrawView drawView = default;
        [SerializeField] private AttackView attackView = default;
        [SerializeField] private DamageView damageView = default;
        [SerializeField] private ClearView clearView = default;
        [SerializeField] private FailView failView = default;
        [SerializeField] private GameFinishView gameFinishView = default;


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

            Container
                .Bind<ITurnCountEntity>()
                .To<TurnCountEntity>()
                .AsCached()
                .WithArguments(0);

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
                .Bind<EncloseEffectFactory>()
                .AsCached();

            Container
                .Bind<AttackEffectFactory>()
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

            Container
                .Bind<ITurnCountModel>()
                .To<TurnCountModel>()
                .AsCached()
                .WithArguments(0);

            #endregion

            #region Repository

            Container
                .Bind<IStageDataRepository>()
                .To<StageDataRepository>()
                .AsCached();

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

            Container
                .Bind<ITurnCountUseCase>()
                .To<TurnCountUseCase>()
                .AsCached();

            Container
                .BindInterfacesTo<StageDataUseCase>()
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

            Container
                .Bind<TurnCountPresenter>()
                .AsCached()
                .NonLazy();

            #endregion

            #region Controller

            Container
                .BindInterfacesTo<PlayerController>()
                .AsCached()
                .NonLazy();

            Container
                .Bind<StateSequencer>()
                .AsCached()
                .NonLazy();

            Container
                .BindInterfacesTo<EnclosureObjectGenerator>()
                .AsCached()
                .NonLazy();

            #endregion

            #region View

            Container
                .Bind<CursorView>()
                .FromInstance(cursorView)
                .AsCached();

            Container
                .Bind<StockPositionCommander>()
                .FromInstance(stockPositionCommander)
                .AsCached();

            Container
                .Bind<TurnCountView>()
                .FromInstance(turnCountView)
                .AsCached();

            Container
                .Bind<ReadyView>()
                .FromInstance(readyView)
                .AsCached();

            Container
                .Bind<DrawView>()
                .FromInstance(drawView)
                .AsCached();

            Container
                .Bind<AttackView>()
                .FromInstance(attackView)
                .AsCached();

            Container
                .Bind<DamageView>()
                .FromInstance(damageView)
                .AsCached();

            Container
                .Bind<ClearView>()
                .FromInstance(clearView)
                .AsCached();

            Container
                .Bind<FailView>()
                .FromInstance(failView)
                .AsCached();

            Container
                .Bind<GameFinishView>()
                .FromInstance(gameFinishView)
                .AsCached();

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
                .BindFactory<AttackEffectView, AttackEffectView.Factory>()
                .FromComponentInNewPrefab(enclosureObjectTable.AttackEffectView)
                .AsCached();

            Container
                .BindFactory<StockObject, StockObject.Factory>()
                .FromComponentInNewPrefab(enclosureObjectTable.StockObject)
                .AsCached();

            #endregion
        }
    }
}
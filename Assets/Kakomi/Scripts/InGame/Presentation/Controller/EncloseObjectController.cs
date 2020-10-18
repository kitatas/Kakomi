using System;
using Kakomi.InGame.Application;
using Kakomi.InGame.Domain.UseCase.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.Controller
{
    public sealed class EncloseObjectController : MonoBehaviour
    {
        private GameController _gameController;
        private IEnclosureFactoryUseCase _enclosureFactoryUseCase;

        [Inject]
        private void Construct(GameController gameController, IEnclosureFactoryUseCase enclosureFactoryUseCase)
        {
            _gameController = gameController;
            _enclosureFactoryUseCase = enclosureFactoryUseCase;
        }

        private void Start()
        {
            this.UpdateAsObservable()
                .ThrottleFirst(TimeSpan.FromSeconds(FieldParameter.INTERVAL * 4))
                .Where(_ => _gameController.IsMoveObject)
                .Subscribe(_ =>
                {
                    // TODO : 仮のタイミング
                    _enclosureFactoryUseCase.Activate();
                })
                .AddTo(this);
        }
    }
}
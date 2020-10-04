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
        private IEnclosureObjectUseCase _enclosureObjectUseCase;

        [Inject]
        private void Construct(IEnclosureObjectUseCase enclosureObjectUseCase)
        {
            _enclosureObjectUseCase = enclosureObjectUseCase;
        }

        private void Start()
        {
            this.UpdateAsObservable()
                .ThrottleFirst(TimeSpan.FromSeconds(FieldParameter.INTERVAL * 4))
                .Subscribe(_ =>
                {
                    // TODO : 仮のタイミング
                    _enclosureObjectUseCase.Activate();
                })
                .AddTo(this);
        }
    }
}
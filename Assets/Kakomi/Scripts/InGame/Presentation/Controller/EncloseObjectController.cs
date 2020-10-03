using System;
using Kakomi.InGame.Domain.UseCase.Interface;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Kakomi.InGame.Presentation.Controller
{
    public sealed class EncloseObjectController : MonoBehaviour
    {
        private IEncloseObjectUseCase _encloseObjectUseCase;

        [Inject]
        private void Construct(IEncloseObjectUseCase encloseObjectUseCase)
        {
            _encloseObjectUseCase = encloseObjectUseCase;
        }

        private void Start()
        {
            this.UpdateAsObservable()
                .ThrottleFirst(TimeSpan.FromSeconds(1f))
                .Subscribe(_ =>
                {
                    // TODO : 仮のタイミング
                    _encloseObjectUseCase.Activate();
                })
                .AddTo(this);
        }
    }
}
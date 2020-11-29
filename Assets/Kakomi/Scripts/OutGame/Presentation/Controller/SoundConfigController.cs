using Kakomi.Common.Domain.UseCase;
using Kakomi.Common.Presentation.Controller;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Kakomi.OutGame.Presentation.Controller
{
    public sealed class SoundConfigController : MonoBehaviour
    {
        [Inject]
        private void Construct(BgmController bgmController, SeController seController)
        {
            var soundUseCase = new SoundUseCase();
            soundUseCase.LoadSound(bgmController, seController);

            this.OnDestroyAsObservable()
                .Subscribe(_ => soundUseCase.SaveSound(bgmController, seController))
                .AddTo(this);
        }
    }
}
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Kakomi.InGame.Application;
using UnityEngine;
using UnityEngine.UI;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class EnemyHpView : MonoBehaviour
    {
        [SerializeField] private Slider hpSlider = default;

        private CancellationToken _token;

        public void Initialize(int maxHpValue)
        {
            _token = this.GetCancellationTokenOnDestroy();

            hpSlider.maxValue = maxHpValue;
            UpdateHpSlider(maxHpValue);
        }

        public void UpdateHpSlider(int hpValue)
        {
            UpdateHpTextAsync(hpValue, _token).Forget();
        }

        private async UniTaskVoid UpdateHpTextAsync(int hpValue, CancellationToken token)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(FieldParameter.HP_ANIMATION_TIME), cancellationToken: token);

            await DOTween
                .To(() => (int) hpSlider.value,
                    value => hpSlider.value = value,
                    hpValue,
                    FieldParameter.HP_ANIMATION_TIME)
                .WithCancellation(token);
        }
    }
}
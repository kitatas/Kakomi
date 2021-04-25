using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Kakomi.InGame.Application;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class PlayerHpView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI updateHpValueText = default;
        [SerializeField] private TextMeshProUGUI hpText = default;
        [SerializeField] private Slider hpSlider = default;

        private int _maxHpValue;

        private CancellationToken _token;

        public void Initialize(int maxHpValue)
        {
            _token = this.GetCancellationTokenOnDestroy();

            _maxHpValue = maxHpValue;
            hpSlider.maxValue = _maxHpValue;
            UpdateHpSlider(_maxHpValue);
        }

        public void UpdateHpSlider(int hpValue)
        {
            UpdateHpTextAsync(hpValue, _token).Forget();
        }

        private async UniTaskVoid UpdateHpTextAsync(int hpValue, CancellationToken token)
        {
            // 回復・ダメージ量
            var countUpdateHpValue = 0;
            var updateHpValue = hpValue - (int) hpSlider.value;
            var sign = GetUpdateHpValueSign(updateHpValue);
            await DOTween
                .To(() => countUpdateHpValue,
                    value =>
                    {
                        countUpdateHpValue = value;
                        updateHpValueText.text = $"{sign}{value}";
                    },
                    updateHpValue,
                    FieldParameter.HP_ANIMATION_TIME)
                .WithCancellation(token);

            // HP値の更新
            await DOTween
                .To(() => (int) hpSlider.value,
                    value =>
                    {
                        hpSlider.value = value;
                        hpText.text = $"{value}/{_maxHpValue}";
                    },
                    hpValue,
                    FieldParameter.HP_ANIMATION_TIME)
                .WithCancellation(token);

            updateHpValueText.text = "";
        }

        private static string GetUpdateHpValueSign(int updateHpValue)
        {
            if (updateHpValue > 0)
            {
                return "+";
            }

            if (updateHpValue < 0)
            {
                return "-";
            }

            return "";
        }
    }
}
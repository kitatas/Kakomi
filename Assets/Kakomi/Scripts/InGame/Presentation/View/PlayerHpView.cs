using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class PlayerHpView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI hpText = default;
        [SerializeField] private Slider hpSlider = default;

        private int _maxHpValue;

        public void Initialize(int maxHpValue)
        {
            _maxHpValue = maxHpValue;
            hpSlider.maxValue = _maxHpValue;
            UpdateHpSlider(maxHpValue);
        }

        public void UpdateHpSlider(int hpValue)
        {
            hpText.text = $"{hpValue}/{_maxHpValue}";
            hpSlider.value = hpValue;
        }
    }
}
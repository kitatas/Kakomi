using UnityEngine;
using UnityEngine.UI;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class EnemyHpView : MonoBehaviour
    {
        [SerializeField] private Slider hpSlider = default;

        public void Initialize(int maxHpValue)
        {
            hpSlider.maxValue = maxHpValue;
            UpdateHpSlider(maxHpValue);
        }

        public void UpdateHpSlider(int hpValue)
        {
            hpSlider.value = hpValue;
        }
    }
}
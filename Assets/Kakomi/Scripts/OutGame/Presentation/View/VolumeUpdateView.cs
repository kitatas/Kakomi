using Kakomi.Common.Presentation.Controller.Interface;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Kakomi.OutGame.Presentation.View
{
    public sealed class VolumeUpdateView : MonoBehaviour
    {
        [SerializeField] private Button bgmMuteOnButton = default;
        [SerializeField] private Button bgmMuteOffButton = default;
        [SerializeField] private Slider bgmVolumeSlider = default;
        [SerializeField] private Button seMuteOnButton = default;
        [SerializeField] private Button seMuteOffButton = default;
        [SerializeField] private Slider seVolumeSlider = default;

        private readonly Color _positiveColor = new Color(0.7f, 0.4f, 0.25f);
        private readonly Color _negativeColor = new Color(0.5f, 0.2f, 0.05f);

        public void UpdateBgmVolume(IVolumeUpdatable volumeUpdatable)
        {
            bgmMuteOnButton.image.color = volumeUpdatable.IsMute() ? _positiveColor : _negativeColor;
            bgmMuteOnButton
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    volumeUpdatable.SetMute(true);
                    bgmMuteOnButton.image.color = _positiveColor;
                    bgmMuteOffButton.image.color = _negativeColor;
                })
                .AddTo(this);

            bgmMuteOffButton.image.color = volumeUpdatable.IsMute() ? _negativeColor : _positiveColor;
            bgmMuteOffButton
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    volumeUpdatable.SetMute(false);
                    bgmMuteOnButton.image.color = _negativeColor;
                    bgmMuteOffButton.image.color = _positiveColor;
                })
                .AddTo(this);

            bgmVolumeSlider.value = volumeUpdatable.GetVolume();
            bgmVolumeSlider
                .OnValueChangedAsObservable()
                .Subscribe(volumeUpdatable.SetVolume)
                .AddTo(this);
        }

        public void UpdateSeVolume(IVolumeUpdatable volumeUpdatable)
        {
            seMuteOnButton.image.color = volumeUpdatable.IsMute() ? _positiveColor : _negativeColor;
            seMuteOnButton
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    volumeUpdatable.SetMute(true);
                    seMuteOnButton.image.color = _positiveColor;
                    seMuteOffButton.image.color = _negativeColor;
                })
                .AddTo(this);

            seMuteOffButton.image.color = volumeUpdatable.IsMute() ? _negativeColor : _positiveColor;
            seMuteOffButton
                .OnClickAsObservable()
                .Subscribe(_ =>
                {
                    volumeUpdatable.SetMute(false);
                    seMuteOnButton.image.color = _negativeColor;
                    seMuteOffButton.image.color = _positiveColor;
                })
                .AddTo(this);

            seVolumeSlider.value = volumeUpdatable.GetVolume();
            seVolumeSlider
                .OnValueChangedAsObservable()
                .Subscribe(volumeUpdatable.SetVolume)
                .AddTo(this);
        }
    }
}
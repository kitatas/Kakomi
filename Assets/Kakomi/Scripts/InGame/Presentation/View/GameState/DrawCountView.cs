using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Kakomi.InGame.Application;
using UnityEngine;
using UnityEngine.UI;

namespace Kakomi.InGame.Presentation.View
{
    public sealed class DrawCountView : MonoBehaviour
    {
        [SerializeField] private Image image = default;

        public async UniTask CountDrawTimeAsync(CancellationToken token)
        {
            await DOTween.To(
                    () => image.fillAmount,
                    count => image.fillAmount = count,
                    0f,
                    DrawParameter.DRAW_TIME)
                .WithCancellation(token);
        }

        public void ResetCountDrawTime()
        {
            DOTween.To(
                () => image.fillAmount,
                count => image.fillAmount = count,
                1f,
                0.5f);
        }
    }
}
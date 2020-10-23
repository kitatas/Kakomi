using Kakomi.Common.Application;
using UnityEngine;
using Zenject;

namespace Kakomi.Common.Presentation.Controller
{
    public sealed class CameraSizeController : MonoBehaviour
    {
        [SerializeField] private RectTransform canvas = default;

        [Inject]
        private void Construct(Camera mainCamera)
        {
            var canvasSize = canvas.sizeDelta;
            var canvasHeight = ScreenSize.WIDTH * canvasSize.y / canvasSize.x;
            var sizeUpRate = canvasHeight / ScreenSize.HEIGHT;
            if (sizeUpRate > 1)
            {
                mainCamera.orthographicSize = ScreenSize.ORTHOGRAPHIC_SIZE * sizeUpRate;
            }
        }
    }
}
using Kakomi.Common.Application;
using UnityEngine;

namespace Kakomi.Common.Presentation.Controller
{
    [RequireComponent(typeof(Camera))]
    public sealed class CameraSizeController : MonoBehaviour
    {
        [SerializeField] private RectTransform canvas = default;

        private void Awake()
        {
            var canvasSize = canvas.sizeDelta;
            var canvasHeight = ScreenSize.WIDTH * canvasSize.y / canvasSize.x;
            var sizeUpRate = canvasHeight / ScreenSize.HEIGHT;
            if (sizeUpRate > 1)
            {
                var mainCamera = GetComponent<Camera>();
                mainCamera.orthographicSize = ScreenSize.ORTHOGRAPHIC_SIZE * sizeUpRate;
            }
        }
    }
}
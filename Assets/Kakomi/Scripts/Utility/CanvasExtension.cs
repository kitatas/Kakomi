using UnityEngine;

namespace Kakomi.Utility
{
    public static class CanvasExtension
    {
        public static Vector3 GetWorldPosition(this Canvas canvas, Camera camera, Vector3 localPosition)
        {
            var screenPosition = RectTransformUtility.WorldToScreenPoint(camera, localPosition);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, screenPosition,
                camera, out var result);
            return result;
        }
    }
}
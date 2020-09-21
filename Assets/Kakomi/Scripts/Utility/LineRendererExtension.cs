using UnityEngine;

namespace Kakomi.Utility
{
    public static class LineRendererExtension
    {
        public static void SetWidth(this LineRenderer lineRenderer, float width)
        {
            lineRenderer.startWidth = width;
            lineRenderer.endWidth = width;
        }
    }
}
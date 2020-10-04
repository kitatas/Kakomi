using UnityEngine;

namespace Kakomi.Utility
{
    public static class ColorExtension
    {
        public static Color SetAlpha(this Color color, float alpha)
        {
            return new Color(color.r, color.g, color.b, alpha);
        }
    }
}
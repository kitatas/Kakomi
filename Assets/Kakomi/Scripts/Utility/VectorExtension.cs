using UnityEngine;

namespace Kakomi.Scripts.Utility
{
    public static class VectorExtension
    {
        /// <summary>
        /// 交差判定
        /// 参考サイト https://setchi.hatenablog.com/entry/2017/07/12/202756
        /// </summary>
        /// <param name="startPosition1"></param>
        /// <param name="endPosition1"></param>
        /// <param name="startPosition2"></param>
        /// <param name="endPosition2"></param>
        /// <returns></returns>
        public static bool IsCrossVector(
            Vector2 startPosition1, Vector2 endPosition1,
            Vector2 startPosition2, Vector2 endPosition2)
        {
            var d = (endPosition1.x - startPosition1.x) * (endPosition2.y - startPosition2.y) -
                    (endPosition1.y - startPosition1.y) * (endPosition2.x - startPosition2.x);

            if (Mathf.Approximately(d, 0.0f))
            {
                return false;
            }

            var u = ((startPosition2.x - startPosition1.x) * (endPosition2.y - startPosition2.y) -
                     (startPosition2.y - startPosition1.y) * (endPosition2.x - startPosition2.x)) / d;
            var v = ((startPosition2.x - startPosition1.x) * (endPosition1.y - startPosition1.y) -
                     (startPosition2.y - startPosition1.y) * (endPosition1.x - startPosition1.x)) / d;

            if (u < 0.0f || u > 1.0f || v < 0.0f || v > 1.0f)
            {
                return false;
            }

            return true;
        }
    }
}
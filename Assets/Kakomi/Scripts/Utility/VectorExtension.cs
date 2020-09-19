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
        /// <param name="intersection"></param>
        /// <returns></returns>
        public static bool IsCrossVector(
            Vector2 startPosition1, Vector2 endPosition1,
            Vector2 startPosition2, Vector2 endPosition2,
            out Vector2 intersection)
        {
            intersection = Vector2.zero;

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

            intersection.x = startPosition1.x + u * (endPosition1.x - startPosition1.x);
            intersection.y = startPosition1.y + u * (endPosition1.y - startPosition1.y);

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="points3d"></param>
        /// <returns></returns>
        public static Vector2[] ConvertVector2(this Vector3[] points3d)
        {
            var points2d = new Vector2[points3d.Length];
            for (int i = 0; i < points2d.Length; i++)
            {
                points2d[i] = points3d[i];
            }

            return points2d;
        }
    }
}
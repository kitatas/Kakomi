using Kakomi.Scripts.Entity.Main.Interface;
using Kakomi.Scripts.UseCase.Main.Interface;
using Kakomi.Scripts.Utility;
using UnityEngine;

namespace Kakomi.Scripts.UseCase.Main
{
    public sealed class CursorPointsUseCase : ICursorPointsUseCase
    {
        private readonly ICursorPointsEntity _cursorPointsEntity;

        public CursorPointsUseCase(ICursorPointsEntity cursorPointsEntity)
        {
            _cursorPointsEntity = cursorPointsEntity;
        }

        /// <summary>
        /// マウス位置が前フレームでEntityに追加した位置と近似値でないか
        /// </summary>
        /// <param name="mousePosition"></param>
        /// <returns></returns>
        public bool IsAddCursorPoint(Vector3 mousePosition)
        {
            var cursorPointsCount = _cursorPointsEntity.GetCursorPointsCount();
            if (cursorPointsCount <= 1)
            {
                return true;
            }

            var lastCursorPoint = _cursorPointsEntity.GetCursorPoint(cursorPointsCount - 1);
            var distance = (mousePosition - lastCursorPoint).sqrMagnitude;
            return distance >= 0.01f;
        }

        public void AddCursorPoint(Vector3 cursorPosition)
        {
            _cursorPointsEntity.AddCursorPoint(cursorPosition);
        }

        /// <summary>
        /// 交差判定
        /// </summary>
        /// <returns></returns>
        public bool IsCrossLine()
        {
            for (int i = 1; i < _cursorPointsEntity.GetCursorPointsCount() - 3; i++)
            {
                for (int j = i + 1; j < _cursorPointsEntity.GetCursorPointsCount() - 1; j++)
                {
                    if (VectorExtension.IsCrossVector(
                        _cursorPointsEntity.GetCursorPoint(i - 1),
                        _cursorPointsEntity.GetCursorPoint(i),
                        _cursorPointsEntity.GetCursorPoint(j),
                        _cursorPointsEntity.GetCursorPoint(j + 1)))
                    {
                        _cursorPointsEntity.ClearCursorPoints();
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
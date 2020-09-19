using Kakomi.Scripts.Entity.Main.Interface;
using Kakomi.Scripts.UseCase.Main.Interface;
using Kakomi.Scripts.Utility;
using UnityEngine;

namespace Kakomi.Scripts.UseCase.Main
{
    public sealed class CursorPointsUseCase : ICursorPointsUseCase
    {
        private readonly ICursorPointsEntity _cursorPointsEntity;
        private readonly IEnclosurePointsEntity _enclosurePointsEntity;

        public CursorPointsUseCase(ICursorPointsEntity cursorPointsEntity, IEnclosurePointsEntity enclosurePointsEntity)
        {
            _cursorPointsEntity = cursorPointsEntity;
            _enclosurePointsEntity = enclosurePointsEntity;
        }

        /// <summary>
        /// 入力位置が前フレームでCursorPointsEntityに追加した位置と近似値でないか
        /// </summary>
        /// <param name="currentCursorPoint"></param>
        /// <returns></returns>
        public bool IsAddCursorPoint(Vector3 currentCursorPoint)
        {
            var cursorPointsCount = _cursorPointsEntity.GetCursorPointsCount();
            if (cursorPointsCount <= 1)
            {
                return true;
            }

            var lastCursorPoint = _cursorPointsEntity.GetCursorPoint(cursorPointsCount - 1);
            var distance = (currentCursorPoint - lastCursorPoint).sqrMagnitude;
            return distance >= 0.01f;
        }

        public void AddCursorPoint(Vector3 cursorPoint)
        {
            _cursorPointsEntity.AddCursorPoint(cursorPoint);
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
                        _cursorPointsEntity.GetCursorPoint(j + 1),
                        out var intersectPoint))
                    {
                        SetEnclosurePoints(i, j, intersectPoint);
                        _cursorPointsEntity.ClearCursorPoints();
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 囲みができた座標をEnclosurePointsEntityに保存
        /// </summary>
        private void SetEnclosurePoints(int startIndex, int endIndex, Vector2 intersectPoint)
        {
            _enclosurePointsEntity.AddEnclosurePoint(intersectPoint);

            for (int i = startIndex; i <= endIndex; i++)
            {
                _enclosurePointsEntity.AddEnclosurePoint(_cursorPointsEntity.CursorPoints[i]);
            }
        }
    }
}
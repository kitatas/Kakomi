using Kakomi.Scripts.Entity.Main.Interface;
using Kakomi.Scripts.UseCase.Main.Interface;
using Kakomi.Scripts.Utility;
using UnityEngine;

namespace Kakomi.Scripts.UseCase.Main
{
    public sealed class CursorPointListUseCase : ICursorPointListUseCase
    {
        private readonly ICursorPointListEntity _cursorPointListEntity;

        public CursorPointListUseCase(ICursorPointListEntity cursorPointListEntity)
        {
            _cursorPointListEntity = cursorPointListEntity;
        }

        /// <summary>
        /// マウス位置が前フレームでEntityに追加した位置と近似値でないか
        /// </summary>
        /// <param name="mousePosition"></param>
        /// <returns></returns>
        public bool IsAddCursorPoint(Vector3 mousePosition)
        {
            if (_cursorPointListEntity.GetCursorPointListCount() <= 1) return true;

            var distance = (mousePosition - _cursorPointListEntity.GetLastCursorPoint()).sqrMagnitude;
            return distance >= 0.01f;
        }

        public void AddCursorPoint(Vector3 cursorPosition)
        {
            _cursorPointListEntity.AddCursorPoint(cursorPosition);
        }

        /// <summary>
        /// 交差判定
        /// </summary>
        /// <returns></returns>
        public bool IsCrossLine()
        {
            for (int i = 1; i < _cursorPointListEntity.GetCursorPointListCount() - 3; i++)
            {
                for (int j = i + 1; j < _cursorPointListEntity.GetCursorPointListCount() - 1; j++)
                {
                    if (VectorExtension.IsCrossVector(
                        _cursorPointListEntity.GetCursorPoint(i - 1),
                        _cursorPointListEntity.GetCursorPoint(i),
                        _cursorPointListEntity.GetCursorPoint(j),
                        _cursorPointListEntity.GetCursorPoint(j + 1)))
                    {
                        _cursorPointListEntity.ClearCursorPointList();
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
using Kakomi.InGame.Application;
using Kakomi.InGame.Data.Entity.Interface;
using Kakomi.InGame.Domain.Repository.Interface;
using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.Utility;
using UnityEngine;

namespace Kakomi.InGame.Domain.UseCase
{
    public sealed class CursorPointsUseCase : ICursorPointsUseCase
    {
        private readonly ICursorPointsEntity _cursorPointsEntity;
        private readonly IEnclosurePointsEntity _enclosurePointsEntity;
        private readonly ILineViewsEntity _lineViewsEntity;

        private readonly ILineRepository _lineRepository;
        private readonly IEnclosureRepository _enclosureRepository;

        public CursorPointsUseCase(ICursorPointsEntity cursorPointsEntity, IEnclosurePointsEntity enclosurePointsEntity,
            ILineViewsEntity lineViewsEntity, ILineRepository lineRepository, IEnclosureRepository enclosureRepository)
        {
            _cursorPointsEntity = cursorPointsEntity;
            _enclosurePointsEntity = enclosurePointsEntity;
            _lineViewsEntity = lineViewsEntity;

            _lineRepository = lineRepository;
            _enclosureRepository = enclosureRepository;
        }

        /// <summary>
        /// 入力位置が前フレームでCursorPointsEntityに追加した位置と近似値でないか
        /// </summary>
        /// <param name="currentCursorPoint"></param>
        /// <returns></returns>
        public bool IsAddCursorPoint(Vector2 currentCursorPoint)
        {
            var cursorPointsCount = _cursorPointsEntity.GetCursorPointsCount();
            if (cursorPointsCount <= 1)
            {
                return true;
            }

            var lastCursorPoint = _cursorPointsEntity.GetCursorPoint(cursorPointsCount - 1);
            var distance = (currentCursorPoint - lastCursorPoint).sqrMagnitude;
            return distance >= DrawParameter.DIFFERENCE_DISTANCE;
        }

        public void AddCursorPoint(Vector2 cursorPoint)
        {
            _cursorPointsEntity.AddCursorPoint(cursorPoint);

            var lineView = _lineRepository.GenerateLineView();
            _lineViewsEntity.AddLineView(lineView);
            lineView.DrawLine();
        }

        public void DoEnclosureAction()
        {
            if (IsCrossLine())
            {
                // 囲むまでに追加された座標リストを削除
                _cursorPointsEntity.ClearCursorPoints();

                // 囲み判定用のコライダー生成
                _enclosureRepository.GenerateEnclosureCollider();

                // 囲みに使用した線の削除
                _lineViewsEntity.DeleteLine();
            }
        }

        /// <summary>
        /// 交差判定
        /// </summary>
        /// <returns></returns>
        private bool IsCrossLine()
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
            _enclosurePointsEntity.ClearEnclosurePoints();

            _enclosurePointsEntity.AddEnclosurePoint(intersectPoint);

            for (int i = startIndex; i <= endIndex; i++)
            {
                _enclosurePointsEntity.AddEnclosurePoint(_cursorPointsEntity.GetCursorPoint(i));
            }
        }
    }
}
using System;
using Kakomi.InGame.Data.Entity.Interface;
using Kakomi.InGame.Domain.UseCase.Interface;
using UnityEngine;

namespace Kakomi.InGame.Domain.UseCase
{
    public sealed class LineUseCase : ILineUseCase
    {
        private readonly ICursorPointsEntity _cursorPointsEntity;

        public LineUseCase(ICursorPointsEntity cursorPointsEntity)
        {
            _cursorPointsEntity = cursorPointsEntity;
        }

        public void DrawLine(Action<(Vector2, Vector2)> viewAction)
        {
            var cursorPointsCount = _cursorPointsEntity.GetCursorPointsCount();
            if (cursorPointsCount <= 1)
            {
                return;
            }

            var startPoint = _cursorPointsEntity.GetCursorPoint(cursorPointsCount - 2);
            var endPoint = _cursorPointsEntity.GetCursorPoint(cursorPointsCount - 1);

            viewAction?.Invoke((startPoint, endPoint));
        }

        public void DeleteLinePoint(Vector2 point)
        {
            _cursorPointsEntity.RemoveCursorPoint(point);
        }
    }
}
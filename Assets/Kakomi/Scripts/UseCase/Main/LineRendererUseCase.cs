using Kakomi.Scripts.Entity.Main.Interface;
using Kakomi.Scripts.UseCase.Main.Interface;
using Kakomi.Scripts.Utility;
using UnityEngine;

namespace Kakomi.Scripts.UseCase.Main
{
    public sealed class LineRendererUseCase : ILineRendererUseCase
    {
        private Vector3 _startPoint;

        private readonly LineRenderer _lineRenderer;
        private readonly ICursorPointsEntity _cursorPointsEntity;

        public LineRendererUseCase(LineRenderer lineRenderer, ICursorPointsEntity cursorPointsEntity)
        {
            _lineRenderer = lineRenderer;
            _lineRenderer.SetWidth(0.1f);
            _lineRenderer.positionCount = 2;

            _cursorPointsEntity = cursorPointsEntity;
        }

        public void DrawLine()
        {
            if (_cursorPointsEntity.GetCursorPointsCount() <= 1)
            {
                return;
            }

            var startPointIndex = _cursorPointsEntity.GetCursorPointsCount() - 2;
            _startPoint = _cursorPointsEntity.GetCursorPoint(startPointIndex);
            _lineRenderer.SetPosition(0, _startPoint);

            var endPointIndex = _cursorPointsEntity.GetCursorPointsCount() - 1;
            var endPoint = _cursorPointsEntity.GetCursorPoint(endPointIndex);
            _lineRenderer.SetPosition(1, endPoint);
        }

        public void DeleteLine()
        {
            _lineRenderer.positionCount = 0;
            _cursorPointsEntity.RemoveCursorPoint(_startPoint);
        }
    }
}
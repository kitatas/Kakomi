using Kakomi.Scripts.Entity.Main.Interface;
using Kakomi.Scripts.UseCase.Main.Interface;
using Kakomi.Scripts.Utility;
using UnityEngine;

namespace Kakomi.Scripts.UseCase.Main
{
    public sealed class LineUseCase : ILineUseCase
    {
        private Vector3 _startPoint;

        private readonly LineRenderer _lineRenderer;
        private readonly ICursorPointListEntity _cursorPointListEntity;

        public LineUseCase(LineRenderer lineRenderer, ICursorPointListEntity cursorPointListEntity)
        {
            _lineRenderer = lineRenderer;
            _lineRenderer.SetWidth(0.1f);
            _lineRenderer.positionCount = 2;

            _cursorPointListEntity = cursorPointListEntity;
        }

        public void DrawLine()
        {
            if (_cursorPointListEntity.GetCursorPointListCount() > 1)
            {
                var startPointIndex = _cursorPointListEntity.GetCursorPointListCount() - 2;
                _startPoint = _cursorPointListEntity.GetCursorPoint(startPointIndex);
                _lineRenderer.SetPosition(0, _startPoint);
                _lineRenderer.SetPosition(1, _cursorPointListEntity.GetLastCursorPoint());
            }
        }

        public void DeleteLine()
        {
            _lineRenderer.positionCount = 0;
            _cursorPointListEntity.RemoveCursorPoint(_startPoint);
        }
    }
}
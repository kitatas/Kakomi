using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Kakomi.InGame.Data.Entity.Interface;
using Kakomi.InGame.Domain.UseCase.Interface;
using Kakomi.Utility;
using UnityEngine;

namespace Kakomi.InGame.Domain.UseCase
{
    public sealed class LineUseCase : ILineUseCase
    {
        private readonly float _deleteTime = 2.0f;

        private Vector2 _startPoint;

        private readonly LineRenderer _lineRenderer;
        private readonly ICursorPointsEntity _cursorPointsEntity;

        public LineUseCase(LineRenderer lineRenderer, ICursorPointsEntity cursorPointsEntity)
        {
            _lineRenderer = lineRenderer;
            _lineRenderer.SetWidth(0.1f);
            _lineRenderer.positionCount = 2;

            _cursorPointsEntity = cursorPointsEntity;
        }

        public void DrawLine(CancellationToken token)
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

            DeleteLineAsync(token).Forget();
        }

        private async UniTaskVoid DeleteLineAsync(CancellationToken token)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_deleteTime), cancellationToken: token);

            _cursorPointsEntity.RemoveCursorPoint(_startPoint);
            UnityEngine.Object.Destroy(_lineRenderer.gameObject);
        }
    }
}
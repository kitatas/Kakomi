using System.Collections.Generic;
using Kakomi.InGame.Data.Entity.Interface;
using UnityEngine;

namespace Kakomi.InGame.Data.Entity
{
    public sealed class CursorPointsEntity : ICursorPointsEntity
    {
        private readonly List<Vector2> _cursorPoints;

        public CursorPointsEntity()
        {
            _cursorPoints = new List<Vector2>();
        }

        public void AddCursorPoint(Vector2 mousePoint) => _cursorPoints.Add(mousePoint);

        public void RemoveCursorPoint(Vector2 point) => _cursorPoints.Remove(point);

        public void ClearCursorPoints() => _cursorPoints.Clear();

        public int GetCursorPointsCount() => _cursorPoints.Count;

        public Vector2 GetCursorPoint(int index) => _cursorPoints[index];
    }
}
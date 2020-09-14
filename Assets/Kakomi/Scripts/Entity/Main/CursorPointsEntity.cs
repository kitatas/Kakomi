using System.Collections.Generic;
using Kakomi.Scripts.Entity.Main.Interface;
using UnityEngine;

namespace Kakomi.Scripts.Entity.Main
{
    public sealed class CursorPointsEntity : ICursorPointsEntity
    {
        private readonly List<Vector3> _cursorPoints;

        public CursorPointsEntity()
        {
            _cursorPoints = new List<Vector3>();
        }

        public void AddCursorPoint(Vector3 mousePoint) => _cursorPoints.Add(mousePoint);

        public void RemoveCursorPoint(Vector3 point) => _cursorPoints.Remove(point);

        public void ClearCursorPoints() => _cursorPoints.Clear();

        public int GetCursorPointsCount() => _cursorPoints.Count;

        public Vector3 GetCursorPoint(int index) => _cursorPoints[index];

        public Vector3 GetLastCursorPoint() => _cursorPoints[GetCursorPointsCount() - 1];
    }
}
using System.Collections.Generic;
using Kakomi.Scripts.Entity.Main.Interface;
using UnityEngine;

namespace Kakomi.Scripts.Entity.Main
{
    public sealed class CursorPointListEntity : ICursorPointListEntity
    {
        private readonly List<Vector3> _cursorPointList;

        public CursorPointListEntity()
        {
            _cursorPointList = new List<Vector3>();
        }

        public void AddCursorPointList(Vector3 mousePoint) => _cursorPointList.Add(mousePoint);

        public void ClearCursorPointList() => _cursorPointList.Clear();

        public int GetCursorPointListCount() => _cursorPointList.Count;

        public Vector3 GetCursorPoint(int index) => _cursorPointList[index];

        public Vector3 GetLastCursorPoint() => _cursorPointList[GetCursorPointListCount() - 1];
    }
}
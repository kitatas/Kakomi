using System.Collections.Generic;
using UnityEngine;

namespace Kakomi.Scripts.Entity.Main.Interface
{
    public interface ICursorPointsEntity
    {
        List<Vector3> CursorPoints { get; }
        void AddCursorPoint(Vector3 mousePoint);
        void RemoveCursorPoint(Vector3 point);
        void ClearCursorPoints();
        int GetCursorPointsCount();
        Vector3 GetCursorPoint(int index);
    }
}
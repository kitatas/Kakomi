using UnityEngine;

namespace Kakomi.Scripts.Entity.Main.Interface
{
    public interface ICursorPointsEntity
    {
        void AddCursorPoint(Vector3 mousePoint);
        void RemoveCursorPoint(Vector3 point);
        void ClearCursorPoints();
        int GetCursorPointsCount();
        Vector3 GetCursorPoint(int index);
        Vector3 GetLastCursorPoint();
    }
}
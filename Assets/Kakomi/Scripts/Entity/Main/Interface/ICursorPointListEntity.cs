using UnityEngine;

namespace Kakomi.Scripts.Entity.Main.Interface
{
    public interface ICursorPointListEntity
    {
        void AddCursorPoint(Vector3 mousePoint);
        void RemoveCursorPoint(Vector3 point);
        void ClearCursorPointList();
        int GetCursorPointListCount();
        Vector3 GetCursorPoint(int index);
        Vector3 GetLastCursorPoint();
    }
}
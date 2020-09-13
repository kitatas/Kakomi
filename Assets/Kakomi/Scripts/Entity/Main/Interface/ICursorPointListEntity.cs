using UnityEngine;

namespace Kakomi.Scripts.Entity.Main.Interface
{
    public interface ICursorPointListEntity
    {
        void AddCursorPointList(Vector3 mousePoint);
        void ClearCursorPointList();
        int GetCursorPointListCount();
        Vector3 GetCursorPoint(int index);
        Vector3 GetLastCursorPoint();
    }
}
using UnityEngine;

namespace Kakomi.InGame.Data.Entity.Interface
{
    public interface ICursorPointsEntity
    {
        void AddCursorPoint(Vector2 mousePoint);
        void RemoveCursorPoint(Vector2 point);
        void ClearCursorPoints();
        int GetCursorPointsCount();
        Vector2 GetCursorPoint(int index);
    }
}
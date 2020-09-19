using UnityEngine;

namespace Kakomi.Scripts.UseCase.Main.Interface
{
    public interface ICursorPointsUseCase
    {
        bool IsAddCursorPoint(Vector3 currentCursorPoint);
        void AddCursorPoint(Vector3 cursorPoint);
        bool IsCrossLine();
    }
}
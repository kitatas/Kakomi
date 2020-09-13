using UnityEngine;

namespace Kakomi.Scripts.UseCase.Main.Interface
{
    public interface ICursorPointsUseCase
    {
        bool IsAddCursorPoint(Vector3 mousePosition);
        void AddCursorPoint(Vector3 cursorPosition);
        bool IsCrossLine();
    }
}
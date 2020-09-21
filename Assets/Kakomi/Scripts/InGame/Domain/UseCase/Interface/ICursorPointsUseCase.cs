using UnityEngine;

namespace Kakomi.InGame.Domain.UseCase.Interface
{
    public interface ICursorPointsUseCase
    {
        bool IsAddCursorPoint(Vector2 currentCursorPoint);
        void AddCursorPoint(Vector2 cursorPoint);
        void DoEnclosureAction();
    }
}
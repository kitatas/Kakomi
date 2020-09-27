using UnityEngine;

namespace Kakomi.InGame.Domain.UseCase.Interface
{
    public interface ICursorPointsUseCase
    {
        void AddCursorPoint(Vector2 cursorPoint);
    }
}
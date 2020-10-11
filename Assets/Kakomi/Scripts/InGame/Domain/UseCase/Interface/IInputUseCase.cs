using UnityEngine;

namespace Kakomi.InGame.Domain.UseCase.Interface
{
    public interface IInputUseCase
    {
        bool IsInputScreen();
        Vector2 GetInputPosition();
    }
}
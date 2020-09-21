using UnityEngine;

namespace Kakomi.InGame.Domain.UseCase.Interface
{
    public interface IInputUseCase
    {
        bool InputMouseButton();
        Vector2 GetInputPosition();
    }
}
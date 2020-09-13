using UnityEngine;

namespace Kakomi.Scripts.UseCase.Main.Interface
{
    public interface IInputUseCase
    {
        bool InputMouseButton();
        Vector3 GetMousePosition();
    }
}